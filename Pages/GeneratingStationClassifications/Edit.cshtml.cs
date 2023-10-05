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

namespace EMS.Pages.GeneratingStationClassifications
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public EditModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GeneratingStationClassification GeneratingStationClassification { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStationClassification == null)
            {
                return NotFound();
            }

            var generatingstationclassification =  await _context.GeneratingStationClassification.FirstOrDefaultAsync(m => m.GeneratingStationClassificationId == id);
            if (generatingstationclassification == null)
            {
                return NotFound();
            }
            GeneratingStationClassification = generatingstationclassification;
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

            _context.Attach(GeneratingStationClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratingStationClassificationExists(GeneratingStationClassification.GeneratingStationClassificationId))
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

        private bool GeneratingStationClassificationExists(int id)
        {
          return _context.GeneratingStationClassification.Any(e => e.GeneratingStationClassificationId == id);
        }
    }
}
