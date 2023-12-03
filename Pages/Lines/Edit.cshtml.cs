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

namespace EMS.Pages.Lines
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Line Line { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Line == null)
            {
                return NotFound();
            }

            var line =  await _context.Line.FirstOrDefaultAsync(m => m.LineId == id);
            if (line == null)
            {
                return NotFound();
            }
            Line = line;
           ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
           ViewData["FromBusId"] = new SelectList(_context.Bus, "BusId", "BusId");
           ViewData["ToBusId"] = new SelectList(_context.Bus, "BusId", "BusId");
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

            _context.Attach(Line).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineExists(Line.LineId))
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

        private bool LineExists(int id)
        {
          return (_context.Line?.Any(e => e.LineId == id)).GetValueOrDefault();
        }
    }
}
