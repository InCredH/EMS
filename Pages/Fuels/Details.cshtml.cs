using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Fuels
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Fuel Fuel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel.FirstOrDefaultAsync(m => m.FuelId == id);
            if (fuel == null)
            {
                return NotFound();
            }
            else 
            {
                Fuel = fuel;
            }
            return Page();
        }
    }
}
