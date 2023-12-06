using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingUnits
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
        ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementName");
        ViewData["GeneratingStationId"] = new SelectList(_context.GeneratingStation, "GeneratingStationId", "GeneratingStationName");
        ViewData["GeneratingTransformerHVVoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageLevel");
        ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageLevel");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["Locations"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            
            return Page();
        }

        [BindProperty]
        public GeneratingUnit GeneratingUnit { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.GeneratingUnit == null || GeneratingUnit == null)
            {
                return Page();
            }
            var generatingVoltage = _context.Voltage
              .Where(v => v.VoltageId == GeneratingUnit.VoltageId)
              .Select(v => v.VoltageLevel)
              .FirstOrDefault();

            var transformerHVVoltage = _context.Voltage
                .Where(v => v.VoltageId == GeneratingUnit.GeneratingTransformerHVVoltageId)
                .Select(v => v.VoltageLevel)
                .FirstOrDefault();
            if (transformerHVVoltage <= generatingVoltage)
            {
                ModelState.AddModelError("GeneratingUnit.GeneratingTransformerHVVoltageId", "Generating Transformer HV Voltage must be greater than Voltage.");
                return Page();
            }
            Element.ElementType = "Generating Unit";
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;
            _context.Element.Add(Element);
            await _context.SaveChangesAsync();
            var lastElementId = _context.Element.Max(e => e.ElementId);
            GeneratingUnit.ElementId = lastElementId;
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
            _context.GeneratingUnit.Add(GeneratingUnit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
