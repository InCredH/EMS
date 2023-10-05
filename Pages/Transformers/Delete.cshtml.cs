using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Transformers
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Transformer Transformer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }

            var transformer = await _context.Transformer.FirstOrDefaultAsync(m => m.ElementId == id);

            if (transformer == null)
            {
                return NotFound();
            }
            else 
            {
                Transformer = transformer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }
            var transformer = await _context.Transformer.FindAsync(id);

            if (transformer != null)
            {
                Transformer = transformer;
                _context.Transformer.Remove(Transformer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
