using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingUnits
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
        ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionId");
        ViewData["Substation1Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
        ViewData["Substation2Id"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
        ViewData["GeneratingStationId"] = new SelectList(_context.GeneratingStation, "GeneratingStationId", "GeneratingStationId");
        ViewData["GeneratingTransformerHVVoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
        ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
            return Page();
        }

        [BindProperty]
        public GeneratingUnit GeneratingUnit { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GeneratingUnit.Add(GeneratingUnit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
