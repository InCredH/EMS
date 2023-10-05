using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Regions
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Region Region { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Region == null)
            {
                return NotFound();
            }

            var region = await _context.Region.FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }
            else 
            {
                Region = region;
            }
            return Page();
        }
    }
}
