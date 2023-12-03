using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.LineReactors
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public LineReactor LineReactor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LineReactor == null)
            {
                return NotFound();
            }

            var linereactor = await _context.LineReactor.FirstOrDefaultAsync(m => m.LineReactorId == id);
            if (linereactor == null)
            {
                return NotFound();
            }
            else 
            {
                LineReactor = linereactor;
            }
            return Page();
        }
    }
}
