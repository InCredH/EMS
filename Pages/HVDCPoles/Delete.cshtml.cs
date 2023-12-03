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
    public class DeleteModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DeleteModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.HVDCPole == null)
            {
                return NotFound();
            }
            var hvdcpole = await _context.HVDCPole.FindAsync(id);

            if (hvdcpole != null)
            {
                HVDCPole = hvdcpole;
                _context.HVDCPole.Remove(HVDCPole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
