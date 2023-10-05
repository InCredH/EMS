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
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GeneratingStation GeneratingStation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStation == null)
            {
                return NotFound();
            }

            var generatingstation = await _context.GeneratingStation.FirstOrDefaultAsync(m => m.GeneratingStationId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.GeneratingStation == null)
            {
                return NotFound();
            }
            var generatingstation = await _context.GeneratingStation.FindAsync(id);

            if (generatingstation != null)
            {
                GeneratingStation = generatingstation;
                _context.GeneratingStation.Remove(GeneratingStation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
