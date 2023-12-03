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
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Voltage == null)
            {
                return NotFound();
            }
            var voltage = await _context.Voltage.FindAsync(id);

            if (voltage != null)
            {
                Voltage = voltage;
                _context.Voltage.Remove(Voltage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
