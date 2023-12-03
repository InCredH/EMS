using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingStations
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public GeneratingStation GeneratingStation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStation == null)
            {
                return NotFound();
            }

            var generatingstation = await _context.GeneratingStation
                .Include(g => g.GeneratingStationClassification)
                .Include(g => g.GeneratingStationType)
                .Include(g => g.Fuel)
                .FirstOrDefaultAsync(m => m.GeneratingStationId == id);
            
            if (generatingstation == null)
            {
                return NotFound();
            }
            else 
            {
                GeneratingStation = generatingstation;
            }
            return Page();
        }
    }
}
