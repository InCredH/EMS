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

namespace EMS.Pages.BusReactors
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public EditModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BusReactor BusReactor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BusReactor == null)
            {
                return NotFound();
            }

            var busreactor =  await _context.BusReactor.FirstOrDefaultAsync(m => m.ElementId == id);
            if (busreactor == null)
            {
                return NotFound();
            }
            BusReactor = busreactor;
           ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionId");
           ViewData["Substation1Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["Substation2Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["BusId"] = new SelectList(_context.Bus, "ElementId", "ElementType");
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

            _context.Attach(BusReactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusReactorExists(BusReactor.ElementId))
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

        private bool BusReactorExists(int id)
        {
          return _context.BusReactor.Any(e => e.ElementId == id);
        }
    }
}
