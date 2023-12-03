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

namespace EMS.Pages.LineReactors
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LineReactor LineReactor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LineReactor == null)
            {
                return NotFound();
            }

            var linereactor =  await _context.LineReactor.FirstOrDefaultAsync(m => m.LineReactorId == id);
            if (linereactor == null)
            {
                return NotFound();
            }
            LineReactor = linereactor;
           ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
           ViewData["LineId"] = new SelectList(_context.Line, "LineId", "LineId");
           ViewData["SubstationId"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
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

            _context.Attach(LineReactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineReactorExists(LineReactor.LineReactorId))
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

        private bool LineReactorExists(int id)
        {
          return (_context.LineReactor?.Any(e => e.LineReactorId == id)).GetValueOrDefault();
        }
    }
}
