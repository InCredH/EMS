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
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public Substation Substation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Substation == null)
            {
                return NotFound();
            }

            var substation = await _context.Substation.FirstOrDefaultAsync(m => m.SubstationId == id);
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
