using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.Substations
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
        ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationName");
        ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageLevel");
            return Page();
        }

        [BindProperty]
        public Substation Substation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Substation == null || Substation == null)
            {
                return Page();
            }

            Substation.SubstationName = $"{Substation.Location?.LocationName}-{Substation.Voltage?.VoltageLevel}";

            _context.Substation.Add(Substation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
