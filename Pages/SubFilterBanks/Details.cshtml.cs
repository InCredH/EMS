using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.SubFilterBanks
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public SubFilterBank SubFilterBank { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubFilterBank == null)
            {
                return NotFound();
            }

            var subfilterbank = await _context.SubFilterBank.FirstOrDefaultAsync(m => m.ElementId == id);
            if (subfilterbank == null)
            {
                return NotFound();
            }
            else 
            {
                SubFilterBank = subfilterbank;
            }
            return Page();
        }
    }
}
