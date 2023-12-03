using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.Locations
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
        ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionName");
        ViewData["StateId"] = new SelectList(_context.State, "StateId", "StateName");
            return Page();
        }

        [BindProperty]
        public Location? Location { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Location != null)
            {
                _context.Location.Add(Location);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
