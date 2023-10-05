using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Substations
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public CreateModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
        ViewData["VoltageId"] = new SelectList(_context.Set<Voltage>(), "VoltageId", "VoltageId");
            return Page();
        }

        [BindProperty]
        public Substation Substation { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Substation.Add(Substation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
