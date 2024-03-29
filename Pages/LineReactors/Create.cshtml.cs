using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.LineReactors
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
            ViewData["LineId"] = new SelectList(_context.Line, "LineId", "LineName");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["Locations"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["LineType"] = new SelectList(new List<string> { "AC Transmission Line", "HVDC Line" });
            return Page();
        }

        [BindProperty]
        public LineReactor LineReactor { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.LineReactor == null || LineReactor == null)
            {
                return Page();
            }
            var associatedElementIds = _context.Line
                .Where(l => l.LineId == LineReactor.LineId)
                .Select(l => l.ElementId)
                .FirstOrDefault();
            var substation1Id=_context.Element
                .Where(e=>e.ElementId==associatedElementIds)
                .Select (e => e.Substation1Id)
                .FirstOrDefault();
            var substation2Id = _context.Element
                .Where(e => e.ElementId == associatedElementIds)
                .Select(e => e.Substation2Id)
                .FirstOrDefault();

            if(Element.Substation1Id!=substation1Id || Element.Substation2Id != substation2Id)
            {
                ModelState.AddModelError("Element.Substation1Id", "Substation1Id must be one of the associated Substations for the selected Line.");
                return Page();
            }
            Element.ElementType = "Line Reactor";
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;
            _context.Element.Add(Element);
            await _context.SaveChangesAsync();
            var lastElementId = _context.Element.Max(e => e.ElementId);
            LineReactor.ElementId = lastElementId;

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
            _context.LineReactor.Add(LineReactor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}