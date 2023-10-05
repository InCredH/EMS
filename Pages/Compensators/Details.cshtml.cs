using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Compensators
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Compensator Compensator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Compensator == null)
            {
                return NotFound();
            }

            var compensator = await _context.Compensator.FirstOrDefaultAsync(m => m.ElementId == id);
            if (compensator == null)
            {
                return NotFound();
            }
            else 
            {
                Compensator = compensator;
            }
            return Page();
        }
    }
}
