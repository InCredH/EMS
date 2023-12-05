using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Compensators
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
            return Page();
        }

        [BindProperty]
        public Compensator Compensator { get; set; } = default!;
        [BindProperty]
       public Element? Element { get; set; } = default!;
       [BindProperty]
       public ElementOwner? ElementOwner { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Compensator == null || Compensator == null)
            {
                return Page();
            }
            Element.ElementType = "Compensator";
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
           Compensator.ElementId = lastElementId;

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

            _context.Compensator.Add(Compensator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
