using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;
//import utils.CombinationChecker;
using EMS.utils;

namespace EMS.Pages.Buses
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
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["BusType"] = new SelectList(Enum.GetValues(typeof(BusType)));
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            return Page();
        }

        [BindProperty]
        public Bus? Bus { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; } = default!;
        [BindProperty]
        public ElementOwner? ElementOwner { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Bus == null || Bus == null)
            {
                return Page();
            }

            if (Element == null || Bus == null)
            {
                Console.WriteLine("Element or Bus is null");
                return Page();
            }

            //combination of substationID1, substationID2, elementNumber,busType is unique
            // Func<Bus, bool> busPredicate = bus =>
            //     _context.Bus.Any(b =>
            //         b.Element != null && bus.Element != null &&
            //         b.Element.Substation1Id == bus.Element.Substation1Id &&
            //         b.Element.ElementNumber == bus.Element.ElementNumber &&
            //         b.BusType == bus.BusType);

            // var combinationChecker = new CombinationChecker();
            // bool isUnique = combinationChecker.IsCombinationUnique(busPredicate, _context.Bus);

            // if (!isUnique)
            // {
            //     ModelState.AddModelError("Element.Substation1Id", "combination of substationID1, substationID2, elementNumber, busType should be unique");
            //     return Page();
            // }

            // Set the element data
            Element.ElementType = "Bus";

            //Changing the dates to UTC
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;

            // Add the element to the context
            await _context.Element.AddAsync(Element);

            // Save changes to retrieve the ElementId
            await _context.SaveChangesAsync();

            // Fetch the last ElementId inserted
            var lastElementId = _context.Element.Max(e => e.ElementId);

            // Set the elementId in the bus
            Bus.ElementId = lastElementId;

            // Create ElementOwner objects and add to context for the many-to-many relationship
            var elementOwners = Request.Form["Owners"]
            .Select(ownerId => new ElementOwner
            {
                ElementId = lastElementId,
                OwnerId = Convert.ToInt32(ownerId)
            });

            await _context.ElementOwner.AddRangeAsync(elementOwners);
            await _context.SaveChangesAsync();

            // Add the bus to the context
            await _context.Bus.AddAsync(Bus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
