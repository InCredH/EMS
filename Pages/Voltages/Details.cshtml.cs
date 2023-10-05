using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Voltages
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public DetailsModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Voltage Voltage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Voltage == null)
            {
                return NotFound();
            }

            var voltage = await _context.Voltage.FirstOrDefaultAsync(m => m.VoltageId == id);
            if (voltage == null)
            {
                return NotFound();
            }
            else 
            {
                Voltage = voltage;
            }
            return Page();
        }
    }
}
