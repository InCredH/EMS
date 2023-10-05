using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingStationTypes
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public GeneratingStationType GeneratingStationType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStationType == null)
            {
                return NotFound();
            }

            var generatingstationtype = await _context.GeneratingStationType.FirstOrDefaultAsync(m => m.GeneratingStationTypeId == id);
            if (generatingstationtype == null)
            {
                return NotFound();
            }
            else 
            {
                GeneratingStationType = generatingstationtype;
            }
            return Page();
        }
    }
}
