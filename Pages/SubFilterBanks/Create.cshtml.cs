using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.SubFilterBanks
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
        ViewData["FilterBankId"] = new SelectList(_context.FilterBank, "FilterBankId", "FilterBankId");
            return Page();
        }

        [BindProperty]
        public SubFilterBank SubFilterBank { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SubFilterBank == null || SubFilterBank == null)
            {
                return Page();
            }

            _context.SubFilterBank.Add(SubFilterBank);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
