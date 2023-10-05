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
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public FilterBank FilterBank { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FilterBank == null)
            {
                return NotFound();
            }

            var filterbank = await _context.FilterBank.FirstOrDefaultAsync(m => m.ElementId == id);
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
    }
}
