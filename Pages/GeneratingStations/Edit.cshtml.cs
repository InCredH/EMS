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

namespace EMS.Pages.GeneratingStations
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GeneratingStation GeneratingStation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStation == null)
            {
                return NotFound();
            }

            var generatingstation =  await _context.GeneratingStation.FirstOrDefaultAsync(m => m.GeneratingStationId == id);
            if (generatingstation == null)
            {
                return NotFound();
            }
            GeneratingStation = generatingstation;
           ViewData["FuelId"] = new SelectList(_context.Fuel, "FuelId", "FuelId");
           ViewData["GeneratingStationClassificationId"] = new SelectList(_context.GeneratingStationClassification, "GeneratingStationClassificationId", "GeneratingStationClassificationId");
           ViewData["GeneratingStationTypeId"] = new SelectList(_context.GeneratingStationType, "GeneratingStationTypeId", "GeneratingStationTypeId");
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

            _context.Attach(GeneratingStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratingStationExists(GeneratingStation.GeneratingStationId))
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

        private bool GeneratingStationExists(int id)
        {
          return (_context.GeneratingStation?.Any(e => e.GeneratingStationId == id)).GetValueOrDefault();
        }
    }
}
