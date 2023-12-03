using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.FSCs
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
        ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
            return Page();
        }

        [BindProperty]
        public FSC FSC { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FSC == null || FSC == null)
            {
                return Page();
            }

            _context.FSC.Add(FSC);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
