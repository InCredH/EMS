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
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DeleteModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Region == null)
            {
                return NotFound();
            }
            var region = await _context.Region.FindAsync(id);

            if (region != null)
            {
                Region = region;
                _context.Region.Remove(Region);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
