using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.SVCs
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
        ViewData["BusId"] = new SelectList(_context.Bus, "BusId", "BusId");
        ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
            return Page();
        }

        [BindProperty]
        public SVC SVC { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SVC == null || SVC == null)
            {
                return Page();
            }

            _context.SVC.Add(SVC);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
