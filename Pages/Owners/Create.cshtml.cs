using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.Owners
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner? Owner { get; set; }

        // Add properties for ConstituentName and ConstituentId
        [BindProperty]
        public int SelectedConstituentId { get; set; }

        public SelectList? ConstituentList { get; set; }

        public IActionResult OnGet()
        {
            ConstituentList = new SelectList(_context.Constituent, "ConstituentId", "ConstituentName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set the ConstituentId based on the selected ConstituentName
            Owner.ConstituentId = SelectedConstituentId;

            //check whether the OwnerName is unique
            if (_context.Owner.Any(o => o.OwnerName == Owner.OwnerName))
            {
                ModelState.AddModelError("Owner.OwnerName", "Owner Name must be unique");
                return Page();
            }

            _context.Owner.Add(Owner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
