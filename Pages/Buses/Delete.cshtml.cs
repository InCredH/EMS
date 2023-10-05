using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Buses
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bus Bus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus.FirstOrDefaultAsync(m => m.ElementId == id);

            if (bus == null)
            {
                return NotFound();
            }
            else 
            {
                Bus = bus;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }
            var bus = await _context.Bus.FindAsync(id);

            if (bus != null)
            {
                Bus = bus;
                _context.Bus.Remove(Bus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
