using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.HVDCPoles
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        
        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
            ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
            ViewData["PoleType"] = new SelectList(Enum.GetValues(typeof(PoleType)));
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["Locations"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            return Page();
        }

        [BindProperty]
        public HVDCPole? HVDCPole { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.HVDCPole == null || HVDCPole == null)
            {
                return Page();
            }
          if(Element==null || HVDCPole== null)
            {
                Console.WriteLine("Element or Pole null");
                return Page();
            }

            //substation should be HVDC
            var substation = await _context.Substation.FindAsync(Element.Substation1Id);
            if (substation.SubstationType != "HVDC")
            {
                ModelState.AddModelError("Element.Substation1Id", "Substation should be HVDC");
                return Page();
            }

            Element.ElementType = "HVDCPole";
            _context.Element.Add(Element);
            await _context.SaveChangesAsync();
            var lastElementId = _context.Element.Max(e => e.ElementId);
            HVDCPole.ElementId = lastElementId;
            foreach(var ownerId in Request.Form["Owners"]) // Assuming "Owners" is the name of the multiple select control
            {
                var elementOwner = new ElementOwner
                {
                    ElementId = lastElementId,
                    OwnerId = Convert.ToInt32(ownerId) // Assuming OwnerId is an integer
                };

                _context.ElementOwner.Add(elementOwner);
                await _context.SaveChangesAsync();
            }


            _context.HVDCPole.Add(HVDCPole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
