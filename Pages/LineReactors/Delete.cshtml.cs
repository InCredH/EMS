using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.LineReactors
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LineReactor LineReactor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LineReactor == null)
            {
                return NotFound();
            }

            var linereactor = await _context.LineReactor.FirstOrDefaultAsync(m => m.LineReactorId == id);

            if (linereactor == null)
            {
                return NotFound();
            }
            else 
            {
                LineReactor = linereactor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LineReactor == null)
            {
                return NotFound();
            }
            var linereactor = await _context.LineReactor.FindAsync(id);

            if (linereactor != null)
            {
                LineReactor = linereactor;
                _context.LineReactor.Remove(LineReactor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
