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

namespace EMS.Pages.Compensators
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public EditModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compensator Compensator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Compensator == null)
            {
                return NotFound();
            }

            var compensator =  await _context.Compensator.FirstOrDefaultAsync(m => m.ElementId == id);
            if (compensator == null)
            {
                return NotFound();
            }
            Compensator = compensator;
           ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionId");
           ViewData["Substation1Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["Substation2Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
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

            _context.Attach(Compensator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompensatorExists(Compensator.ElementId))
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

        private bool CompensatorExists(int id)
        {
          return _context.Compensator.Any(e => e.ElementId == id);
        }
    }
}
