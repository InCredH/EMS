using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Substations
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Substation Substation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Substation == null)
            {
                return NotFound();
            }

            var substation = await _context.Substation
                .Include(s => s.Voltage)
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            
            if (substation == null)
            {
                return NotFound();
            }
            else 
            {
                Substation = substation;
            }
            return Page();
        }
    }
}
