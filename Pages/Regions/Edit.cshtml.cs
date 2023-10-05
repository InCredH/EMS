using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Regions
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public EditModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Region Region { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Region == null)
            {
                return NotFound();
            }

            var region =  await _context.Region.FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }
            Region = region;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(Region.RegionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RegionExists(int id)
        {
          return _context.Region.Any(e => e.RegionId == id);
        }
    }
}
