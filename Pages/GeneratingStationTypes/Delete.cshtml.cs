using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingStationTypes
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GeneratingStationType GeneratingStationType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStationType == null)
            {
                return NotFound();
            }

            var generatingstationtype = await _context.GeneratingStationType.FirstOrDefaultAsync(m => m.GeneratingStationTypeId == id);

            if (generatingstationtype == null)
            {
                return NotFound();
            }
            else 
            {
                GeneratingStationType = generatingstationtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.GeneratingStationType == null)
            {
                return NotFound();
            }
            var generatingstationtype = await _context.GeneratingStationType.FindAsync(id);

            if (generatingstationtype != null)
            {
                GeneratingStationType = generatingstationtype;
                _context.GeneratingStationType.Remove(GeneratingStationType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
