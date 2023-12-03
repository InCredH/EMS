using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingUnits
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GeneratingUnit GeneratingUnit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingUnit == null)
            {
                return NotFound();
            }

            var generatingunit = await _context.GeneratingUnit.FirstOrDefaultAsync(m => m.GeneratingUnitId == id);

            if (generatingunit == null)
            {
                return NotFound();
            }
            else 
            {
                GeneratingUnit = generatingunit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.GeneratingUnit == null)
            {
                return NotFound();
            }
            var generatingunit = await _context.GeneratingUnit.FindAsync(id);

            if (generatingunit != null)
            {
                GeneratingUnit = generatingunit;
                _context.GeneratingUnit.Remove(GeneratingUnit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
