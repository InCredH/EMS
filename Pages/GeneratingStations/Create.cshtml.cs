using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingStations
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public CreateModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FuelId"] = new SelectList(_context.Fuel, "FuelId", "FuelId");
        ViewData["GeneratingStationClassificationId"] = new SelectList(_context.GeneratingStationClassification, "GeneratingStationClassificationId", "GeneratingStationClassificationId");
        ViewData["GeneratingStationTypeId"] = new SelectList(_context.Set<GeneratingStationType>(), "GeneratingStationTypeId", "GeneratingStationTypeId");
            return Page();
        }

        [BindProperty]
        public GeneratingStation GeneratingStation { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GeneratingStation.Add(GeneratingStation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
