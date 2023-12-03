using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Buses
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public Bus Bus { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus.FirstOrDefaultAsync(m => m.BusId == id);
            if (bus == null)
            {
                return NotFound();
            }
            else 
            {
                Bus = bus;
            }
            return Page();
        }
    }
}
