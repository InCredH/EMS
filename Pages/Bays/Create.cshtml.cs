using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Bays
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ConnectingElement1Id"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
        ViewData["ConnectingElement2Id"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
        ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
        ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageId");
            return Page();
        }

        [BindProperty]
        public Bay Bay { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bays == null || Bay == null)
            {
                return Page();
            }

            _context.Bays.Add(Bay);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
