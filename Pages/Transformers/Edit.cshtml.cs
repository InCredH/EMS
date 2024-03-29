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

namespace EMS.Pages.Transformers
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transformer Transformer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }

            var transformer =  await _context.Transformer.FirstOrDefaultAsync(m => m.TransformerId == id);
            if (transformer == null)
            {
                return NotFound();
            }
            Transformer = transformer;
           ViewData["ElementId"] = new SelectList(_context.Element, "ElementId", "ElementId");
           ViewData["Voltage1Id"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
           ViewData["Voltage2Id"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
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

            _context.Attach(Transformer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransformerExists(Transformer.TransformerId))
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

        private bool TransformerExists(int id)
        {
          return (_context.Transformer?.Any(e => e.TransformerId == id)).GetValueOrDefault();
        }
    }
}
