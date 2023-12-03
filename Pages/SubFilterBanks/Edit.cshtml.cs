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

namespace EMS.Pages.SubFilterBanks
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubFilterBank SubFilterBank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubFilterBank == null)
            {
                return NotFound();
            }

            var subfilterbank =  await _context.SubFilterBank.FirstOrDefaultAsync(m => m.SubFilterBankId == id);
            if (subfilterbank == null)
            {
                return NotFound();
            }
            SubFilterBank = subfilterbank;
           ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
           ViewData["FilterBankId"] = new SelectList(_context.FilterBank, "FilterBankId", "FilterBankId");
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

            _context.Attach(SubFilterBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubFilterBankExists(SubFilterBank.SubFilterBankId))
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

        private bool SubFilterBankExists(int id)
        {
          return (_context.SubFilterBank?.Any(e => e.SubFilterBankId == id)).GetValueOrDefault();
        }
    }
}
