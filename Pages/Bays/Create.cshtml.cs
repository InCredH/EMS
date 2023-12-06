using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.Bays
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
            ViewData["ConnectingElement1Id"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementType");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["ConnectingElement2Id"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementType");
            ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
            ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageLevel");
            ViewData["BayType"] = new SelectList(Enum.GetValues(typeof(BayType)));
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            ViewData["ConnectingElement3Id"] = new SelectList(
                _context.Set<Element>()
                    .Join(_context.Set<Substation>(),
                          element => element.Substation1Id,
                          substation => substation.SubstationId,
                          (element, substation) => new
                          {
                              ElementId = element.ElementId,
                              DisplayText = $"{element.ElementType} - {substation.SubstationName} - {element.ElementNumber}"
                          }),
                "ElementId",
                "DisplayText"
            );
            return Page();
        }

        [BindProperty]
        public Bay? Bay { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; } = default!;
        [BindProperty]
        public ElementOwner? ElementOwner { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Bays == null || Bay == null)
            {
                return Page();
            }
            if(Element == null || Bay == null) {
                Console.WriteLine("Element or Bay is null");
                return Page();
            }
            var substation1IdConnectingElement1 = _context.Element
               .Where(e => e.ElementId == Bay.ConnectingElement1Id)
               .Select(e => e.Substation1Id)
               .FirstOrDefault();

            var substation1IdConnectingElement2 = _context.Element
                .Where(e => e.ElementId == Bay.ConnectingElement2Id)
                .Select(e => e.Substation1Id)
                .FirstOrDefault();
            
            if (substation1IdConnectingElement1 != substation1IdConnectingElement2)
            {
                ModelState.AddModelError("Bay.ConnectingElement2Id", "Connecting Element 1 and 2 should have the same Substation.");
                return Page();
            }
            var buscheck1id = _context.Element
                   .Where(e => e.ElementId == Bay.ConnectingElement1Id)
                   .Select(e => e.ElementType)
                   .FirstOrDefault();
            var buscheck2id = _context.Element
                   .Where(e => e.ElementId == Bay.ConnectingElement2Id)
                   .Select(e => e.ElementType)
                   .FirstOrDefault();
            if (Bay.BayType == "Tie")
            {
                
                if(buscheck1id=="Bus" || buscheck2id == "Bus")
                {
                    ModelState.AddModelError("Bay.ConnectingElement2Id", "In Type Tie, A connecting element cannot be a Bus.");
                    return Page();
                }
            }
            if (Bay.BayType == "Main")
            {
                if ((buscheck1id != "Bus" && buscheck2id != "Bus") || buscheck1id==buscheck2id)
                {
                    ModelState.AddModelError("Bay.ConnectingElement2Id", "In Type Main, exactly 1 element can be a Bus.");
                    return Page();
                }
            }
            if(Bay.BayType=="Bus_Coupler" || Bay.BayType == "Bus_Sectionalizer" || Bay.BayType == "TBC")
            {
                if (buscheck1id != "Bus" || buscheck2id != "Bus" || buscheck1id!=buscheck2id )
                {
                    ModelState.AddModelError("Bay.ConnectingElement2Id", "In Type Bus_Coupler,Bus_Sectionalizer or TBC, both connecting element should be Buses.");
                    return Page();
                }
            }
            // Set the element data
            Element.ElementType = "Bay";

            // Add the element to the context
            _context.Element.Add(Element);

            // Save changes to retrieve the ElementId
            await _context.SaveChangesAsync();

            // Fetch the last ElementId inserted
            var lastElementId = _context.Element.Max(e => e.ElementId);

            // Set the elementId in the bay
            Bay.ElementId = lastElementId;

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

            // Add the bay to the context
            _context.Bays.Add(Bay);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
