using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.LineReactors
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
        ViewData["LineId"] = new SelectList(_context.Line, "LineId", "LineId");
        ViewData["SubstationId"] = new SelectList(_context.Substation, "SubstationId", "SubstationId");
            return Page();
        }

        [BindProperty]
        public LineReactor LineReactor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.LineReactor == null || LineReactor == null)
            {
                return Page();
            }

            _context.LineReactor.Add(LineReactor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}