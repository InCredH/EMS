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
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
