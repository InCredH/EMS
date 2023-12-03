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

namespace EMS.Pages.GeneratingStationTypes
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GeneratingStationType GeneratingStationType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStationType == null)
            {
                return NotFound();
            }

            var generatingstationtype =  await _context.GeneratingStationType.FirstOrDefaultAsync(m => m.GeneratingStationTypeId == id);
            if (generatingstationtype == null)
            {
                return NotFound();
            }
            GeneratingStationType = generatingstationtype;
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

            _context.Attach(GeneratingStationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratingStationTypeExists(GeneratingStationType.GeneratingStationTypeId))
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

        private bool GeneratingStationTypeExists(int id)
        {
          return _context.GeneratingStationType.Any(e => e.GeneratingStationTypeId == id);
        }
    }
}
