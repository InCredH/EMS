using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.SVCs
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
            ViewData["BusId"] = new SelectList(_context.Bus, "BusId", "BusName");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["Locations"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["LineType"] = new SelectList(new List<string> { "AC Transmission Line", "HVDC Line" });
            return Page();
        }

        [BindProperty]
        public SVC SVC { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SVC == null || SVC == null)
            {
                return Page();
            }

            //Bus should belong to AC Substation only
            var bus = await _context.Bus.FindAsync(SVC.BusId);
            var element = await _context.Element.FindAsync(bus.ElementId);
            var substation = await _context.Substation.FindAsync(element.Substation1Id);

            if (substation.SubstationType != "AC")
            {
                ModelState.AddModelError("SVC.BusId", "Bus should belong to AC Substation only");
                return Page();
            }

            Element.ElementType = "SVC";
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;
            _context.Element.Add(Element);
            await _context.SaveChangesAsync();
            var lastElementId = _context.Element.Max(e => e.ElementId);
            SVC.ElementId = lastElementId;
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
            _context.SVC.Add(SVC);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
