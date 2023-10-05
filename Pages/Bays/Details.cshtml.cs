using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Bays
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Bay Bay { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bays == null)
            {
                return NotFound();
            }

            var bay = await _context.Bays.FirstOrDefaultAsync(m => m.ElementId == id);
            if (bay == null)
            {
                return NotFound();
            }
            else 
            {
                Bay = bay;
            }
            return Page();
        }
    }
}
