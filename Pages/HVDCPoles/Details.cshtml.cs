using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.HVDCPoles
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public HVDCPole HVDCPole { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HVDCPole == null)
            {
                return NotFound();
            }

            var hvdcpole = await _context.HVDCPole.FirstOrDefaultAsync(m => m.HVDCPoleId == id);
            if (hvdcpole == null)
            {
                return NotFound();
            }
            else 
            {
                HVDCPole = hvdcpole;
            }
            return Page();
        }
    }
}
