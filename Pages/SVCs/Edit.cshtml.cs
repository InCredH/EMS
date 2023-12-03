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

namespace EMS.Pages.SVCs
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SVC SVC { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SVC == null)
            {
                return NotFound();
            }

            var svc =  await _context.SVC.FirstOrDefaultAsync(m => m.SVCId == id);
            if (svc == null)
            {
                return NotFound();
            }
            SVC = svc;
           ViewData["BusId"] = new SelectList(_context.Bus, "BusId", "BusId");
           ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
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

            _context.Attach(SVC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SVCExists(SVC.SVCId))
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

        private bool SVCExists(int id)
        {
          return (_context.SVC?.Any(e => e.SVCId == id)).GetValueOrDefault();
        }
    }
}
