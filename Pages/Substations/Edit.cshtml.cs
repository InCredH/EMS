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

namespace EMS.Pages.Substations
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Substation Substation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Substation == null)
            {
                return NotFound();
            }

            var substation =  await _context.Substation.FirstOrDefaultAsync(m => m.SubstationId == id);
            if (substation == null)
            {
                return NotFound();
            }
            Substation = substation;
           ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
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

            _context.Attach(Substation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstationExists(Substation.SubstationId))
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

        private bool SubstationExists(int id)
        {
          return (_context.Substation?.Any(e => e.SubstationId == id)).GetValueOrDefault();
        }
    }
}
