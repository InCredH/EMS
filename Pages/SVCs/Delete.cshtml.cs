using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.SVCs
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SVC SVC { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SVC == null)
            {
                return NotFound();
            }

            var svc = await _context.SVC.FirstOrDefaultAsync(m => m.SVCId == id);

            if (svc == null)
            {
                return NotFound();
            }
            else 
            {
                SVC = svc;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SVC == null)
            {
                return NotFound();
            }
            var svc = await _context.SVC.FindAsync(id);

            if (svc != null)
            {
                SVC = svc;
                _context.SVC.Remove(SVC);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
