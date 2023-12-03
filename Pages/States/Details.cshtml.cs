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
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

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
    }
}
