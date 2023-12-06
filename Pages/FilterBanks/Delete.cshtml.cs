using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.FilterBanks
{
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FilterBank FilterBank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FilterBank == null)
            {
                return NotFound();
            }

            var filterbank = await _context.FilterBank.FirstOrDefaultAsync(m => m.FilterBankId == id);

            if (filterbank == null)
            {
                return NotFound();
            }
            else 
            {
                FilterBank = filterbank;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FilterBank == null)
            {
                return NotFound();
            }
            var filterbank = await _context.FilterBank.FindAsync(id);

            if (filterbank != null)
            {
                FilterBank = filterbank;
                _context.FilterBank.Remove(FilterBank);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
