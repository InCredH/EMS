using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMS.Models;

namespace EMS.Pages.Constituents
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
            return Page();
        }

        [BindProperty]
        public Constituent? Constituent { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Constituent != null)
            {
                _context.Constituent.Add(Constituent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
