using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Voltages
{
    public class EditModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public EditModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voltage Voltage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Voltage == null)
            {
                return NotFound();
            }

            var voltage =  await _context.Voltage.FirstOrDefaultAsync(m => m.VoltageId == id);
            if (voltage == null)
            {
                return NotFound();
            }
            Voltage = voltage;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Voltage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoltageExists(Voltage.VoltageId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VoltageExists(int id)
        {
          return _context.Voltage.Any(e => e.VoltageId == id);
        }
    }
}
