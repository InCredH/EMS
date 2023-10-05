using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.States
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public State State { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.State == null)
            {
                return NotFound();
            }

            var state = await _context.State.FirstOrDefaultAsync(m => m.StateId == id);

            if (state == null)
            {
                return NotFound();
            }
            else 
            {
                State = state;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.State == null)
            {
                return NotFound();
            }
            var state = await _context.State.FindAsync(id);

            if (state != null)
            {
                State = state;
                _context.State.Remove(State);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
