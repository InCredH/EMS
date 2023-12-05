using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Lines
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
        ViewData["FromBusId"] = new SelectList(_context.Bus, "BusId", "BusId");
        ViewData["ToBusId"] = new SelectList(_context.Bus, "BusId", "BusId");
        ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["Locations"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["LineType"] = new SelectList(new List<string> { "AC Transmission Line", "HVDC Line" });
            return Page();
        }

        [BindProperty]
        public Line Line { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Line == null || Line == null)
            {
                return Page();
            }
            Element.ElementType = "HVDCPole";
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;
            _context.Element.Add(Element);
            await _context.SaveChangesAsync();
            var lastElementId = _context.Element.Max(e => e.ElementId);
            Line.ElementId=lastElementId;
            foreach (var ownerId in Request.Form["Owners"]) // Assuming "Owners" is the name of the multiple select control
            {
                var elementOwner = new ElementOwner
                {
                    ElementId = lastElementId,
                    OwnerId = Convert.ToInt32(ownerId) // Assuming OwnerId is an integer
                };

                _context.ElementOwner.Add(elementOwner);
                await _context.SaveChangesAsync();
            }
            _context.Line.Add(Line);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
