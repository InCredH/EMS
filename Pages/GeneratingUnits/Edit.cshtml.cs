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

namespace EMS.Pages.GeneratingUnits
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public EditModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GeneratingUnit GeneratingUnit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingUnit == null)
            {
                return NotFound();
            }

            var generatingunit =  await _context.GeneratingUnit.FirstOrDefaultAsync(m => m.ElementId == id);
            if (generatingunit == null)
            {
                return NotFound();
            }
            GeneratingUnit = generatingunit;
           ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionId");
           ViewData["Substation1Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["Substation2Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
           ViewData["GeneratingStationId"] = new SelectList(_context.GeneratingStation, "GeneratingStationId", "GeneratingStationId");
           ViewData["GeneratingTransformerHVVoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
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

            _context.Attach(GeneratingUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratingUnitExists(GeneratingUnit.ElementId))
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

        private bool GeneratingUnitExists(int id)
        {
          return _context.GeneratingUnit.Any(e => e.ElementId == id);
        }
    }
}
