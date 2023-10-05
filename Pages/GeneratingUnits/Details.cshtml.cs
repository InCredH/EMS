using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingUnits
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public GeneratingUnit GeneratingUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingUnit == null)
            {
                return NotFound();
            }

            var generatingunit = await _context.GeneratingUnit.FirstOrDefaultAsync(m => m.ElementId == id);
            if (generatingunit == null)
            {
                return NotFound();
            }
            else 
            {
                GeneratingUnit = generatingunit;
            }
            return Page();
        }
    }
}
