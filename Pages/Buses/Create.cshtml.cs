using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

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

            if(Element == null || Bus == null) {
                Console.WriteLine("Element or Bus is null");
                return Page();
            }
            // Set the element data
            Element.ElementType = "Bus";

            // Add the element to the context
            _context.Element.Add(Element);

            // Save changes to retrieve the ElementId
            await _context.SaveChangesAsync();

            // Fetch the last ElementId inserted
            var lastElementId = _context.Element.Max(e => e.ElementId);

            // Set the elementId in the bus
            Bus.ElementId = lastElementId;

            // Create ElementOwner objects and add to context for the many-to-many relationship
            foreach (var ownerId in Request.Form["Owners"]) // Assuming "Owners" is the name of the multiple select control
            {
                Console.WriteLine("OwnerId: "+ownerId);
                var elementOwner = new ElementOwner
                {
                    ElementId = lastElementId,
                    OwnerId = Convert.ToInt32(ownerId) // Assuming OwnerId is an integer
                };

                _context.ElementOwner.Add(elementOwner);
                await _context.SaveChangesAsync();
            }

            // Add the bus to the context
            _context.Bus.Add(Bus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
