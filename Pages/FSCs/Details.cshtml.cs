using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.FSCs
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public FSC FSC { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FSC == null)
            {
                return NotFound();
            }

            var fsc = await _context.FSC.FirstOrDefaultAsync(m => m.FSCId == id);
            if (fsc == null)
            {
                return NotFound();
            }
            else 
            {
                FSC = fsc;
            }
            return Page();
        }
    }
}
