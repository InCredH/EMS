using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Bays
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bay Bay { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bays == null)
            {
                return NotFound();
            }

            var bay = await _context.Bays.FirstOrDefaultAsync(m => m.BayId == id);

            if (bay == null)
            {
                return NotFound();
            }
            else 
            {
                Bay = bay;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bays == null)
            {
                return NotFound();
            }
            var bay = await _context.Bays.FindAsync(id);

            if (bay != null)
            {
                Bay = bay;
                _context.Bays.Remove(Bay);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
