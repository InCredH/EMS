using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Constituents
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Constituent Constituent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Constituent == null)
            {
                return NotFound();
            }

            var constituent = await _context.Constituent.FirstOrDefaultAsync(m => m.ConstituentId == id);

            if (constituent == null)
            {
                return NotFound();
            }
            else 
            {
                Constituent = constituent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Constituent == null)
            {
                return NotFound();
            }
            var constituent = await _context.Constituent.FindAsync(id);

            if (constituent != null)
            {
                Constituent = constituent;
                _context.Constituent.Remove(Constituent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
