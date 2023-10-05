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

namespace EMS.Pages.Bays
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public EditModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bay Bay { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bays == null)
            {
                return NotFound();
            }

            var bay =  await _context.Bays.FirstOrDefaultAsync(m => m.ElementId == id);
            if (bay == null)
            {
                return NotFound();
            }
            Bay = bay;
           ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionId");
           ViewData["Substation1Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["Substation2Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["ConnectingElement1Id"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementType");
           ViewData["ConnectingElement2Id"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementType");
           ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId");
           ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
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

            _context.Attach(Bay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BayExists(Bay.ElementId))
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

        private bool BayExists(int id)
        {
          return _context.Bays.Any(e => e.ElementId == id);
        }
    }
}
