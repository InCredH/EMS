using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;
namespace EMS.Pages.Transformers
{
   public class CreateModel : PageModel
   {
       private readonly EMS.Data.DataContext _context;


       public CreateModel(EMS.Data.DataContext context)
       {
           _context = context;
       }
       //
       public IActionResult OnGet()
       {
        //    ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
           ViewData["TransformerType"] = new SelectList(Enum.GetValues(typeof(TransformerType)));
           ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
           ViewData["Voltage1Id"] = new SelectList(_context.Set<Voltage>(), "VoltageId", "VoltageLevel");
           ViewData["Voltage2Id"] = new SelectList(_context.Set<Voltage>(), "VoltageId", "VoltageLevel");
           ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
           ViewData["Substation2Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
           ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
           return Page();
       }


       [BindProperty]
       public Transformer Transformer { get; set; } = default!;
       [BindProperty]
       public Element? Element { get; set; } = default!;
       [BindProperty]
       public ElementOwner? ElementOwner { get; set; } = default!;
       
       // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
       public async Task<IActionResult> OnPostAsync()
       {
         if (!ModelState.IsValid || _context.Transformer == null || Transformer == null)
           {
               return Page();
           }
           if(Element == null) {
               Console.WriteLine("Element is null");
               return Page();
           }

            //Substation1 and Substation2 should have the same location
            var substation1Id = await _context.Substation.FindAsync(Element.Substation1Id);
            var substation2Id = await _context.Substation.FindAsync(Element.Substation2Id);

            if(substation1Id?.LocationId != substation2Id?.LocationId) {
                ModelState.AddModelError("Element.Substation1Id", "Substation1 and Substation2 should have the same location");
                ModelState.AddModelError("Element.Substation2Id", "Substation1 and Substation2 should have the same location");
                return Page();
            }

           Element.ElementType = "Transformer";
           //change dates to UTC
            DateTime Comm_utcDateTime = Element.CommissioningDate.ToUniversalTime();
            DateTime DeComm_utcDateTime = Element.DecommissioningDate.ToUniversalTime();

            Element.CommissioningDate = Comm_utcDateTime;
            Element.DecommissioningDate = DeComm_utcDateTime;
           // Add the element to the context
           _context.Element.Add(Element);


           // Save changes to retrieve the ElementId
           await _context.SaveChangesAsync();


           // Fetch the last ElementId inserted
           var lastElementId = _context.Element.Max(e => e.ElementId);


           // Set the elementId in the bay
           Transformer.ElementId = lastElementId;

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

          
           _context.Transformer.Add(Transformer);
           await _context.SaveChangesAsync();


           return RedirectToPage("./Index");
       }
   }
}


