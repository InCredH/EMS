using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.BusReactors
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BusReactor BusReactor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BusReactor == null)
            {
                return NotFound();
            }

            var busreactor = await _context.BusReactor.FirstOrDefaultAsync(m => m.ElementId == id);

            if (busreactor == null)
            {
                return NotFound();
            }
            else 
            {
                BusReactor = busreactor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BusReactor == null)
            {
                return NotFound();
            }
            var busreactor = await _context.BusReactor.FindAsync(id);

            if (busreactor != null)
            {
                BusReactor = busreactor;
                _context.BusReactor.Remove(BusReactor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
