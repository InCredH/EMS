using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;
using Microsoft.EntityFrameworkCore;

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
            ViewData["FromBusId"] = new SelectList(_context.Bus, "BusId", "BusName");
            ViewData["ToBusId"] = new SelectList(_context.Bus, "BusId", "BusName");
            ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageLevel");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Substation2Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["Locations"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["LineType"] = new SelectList(new List<string> { "AC", "HVDC" });
            return Page();
        }

        [BindProperty]
        public Line? Line { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Line == null || Line == null)
            {
                return Page();
            }
            if (Element == null)
            {
                Console.WriteLine("Element is null");
                return Page();
            }

            //Substation1 and Substation2 should not have the same location
            var substation1Id = await _context.Substation.FindAsync(Element.Substation1Id);
            var substation2Id = await _context.Substation.FindAsync(Element.Substation2Id);

            if (substation1Id?.LocationId == substation2Id?.LocationId)
            {
                Console.WriteLine("1" + substation1Id?.LocationId + " " + substation2Id?.LocationId);
                ModelState.AddModelError("Element.Substation1Id", "Substation1 and Substation2 should not have the same location");
                ModelState.AddModelError("Element.Substation2Id", "Substation1 and Substation2 should not have the same location");
                return Page();
            }

            //FromBus and ToBus should belong to HVDC Substation and both the substations should be different with the same voltage level
            var fromBus = await _context.Bus.FindAsync(Line.FromBusId);
            var fromBusElement = await _context.Element.FindAsync(fromBus?.ElementId);
            var fromBusSubstation1Id = await _context.Substation.FindAsync(fromBusElement?.Substation1Id);

            var toBus = await _context.Bus.FindAsync(Line.ToBusId);
            var toBusElement = await _context.Element.FindAsync(toBus?.ElementId);
            var toBusSubstation1Id = await _context.Substation.FindAsync(toBusElement?.Substation1Id);

            if (fromBusSubstation1Id == toBusSubstation1Id)
            {
                Console.WriteLine("2" + fromBus?.Element?.Substation1Id + " " + toBus?.Element?.Substation1Id);
                ModelState.AddModelError("Line.FromBusId", "FromBus and ToBus should belong to different Substation");
                ModelState.AddModelError("Line.ToBusId", "FromBus and ToBus should belong to different Substation");
                return Page();
            }

            var from_bus_substationid = await _context.Substation.FindAsync(fromBus?.Element?.Substation1Id);
            var to_bus_substationid = await _context.Substation.FindAsync(toBus?.Element?.Substation1Id);

            if (Line.LineType == "HVDC")
            {
                if (to_bus_substationid?.SubstationType != "DC")
                {
                    ModelState.AddModelError("Line.ToBusId", "ToBus should belong to DC Substation");
                    return Page();
                }
                if (from_bus_substationid?.SubstationType != "DC")
                {
                    ModelState.AddModelError("Line.FromBusId", "FromBus should belong to DC Substation");
                    return Page();
                }
            }

            if (Line.LineType == "AC")
            {
                if (to_bus_substationid?.SubstationType != "AC")
                {
                    ModelState.AddModelError("Line.ToBusId", "ToBus should belong to AC Substation");
                    return Page();
                }
                if (from_bus_substationid?.SubstationType != "AC")
                {
                    ModelState.AddModelError("Line.FromBusId", "FromBus should belong to HVDC Substation");
                    return Page();
                }
            }

            if (from_bus_substationid?.VoltageId != to_bus_substationid?.VoltageId)
            {
                ModelState.AddModelError("Line.FromBusId", "FromBus and ToBus should belong to the same voltage level");
                ModelState.AddModelError("Line.ToBusId", "FromBus and ToBus should belong to the same voltage level");
                return Page();
            }

            Element.ElementType = "Line";
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;
            _context.Element.Add(Element);
            await _context.SaveChangesAsync();
            var lastElementId = _context.Element.Max(e => e.ElementId);
            Line.ElementId = lastElementId;
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

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Npgsql.PostgresException postgresException && postgresException.SqlState == "23505")
                {
                    // Display user-friendly error message
                    ModelState.AddModelError("", "Combination of From Bus, To Bus and Circuit Number should be unique");
                }
                else
                {
                    // If it's a different type of DB exception, handle it accordingly or log it
                    ModelState.AddModelError("", "An error occurred while saving data.");
                }
            }
            return Page();
        }
    }
}
