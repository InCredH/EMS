using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Lines
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public Line Line { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Line == null)
            {
                return NotFound();
            }

            var line = await _context.Line.FirstOrDefaultAsync(m => m.LineId == id);
            if (line == null)
            {
                return NotFound();
            }
            else 
            {
                Line = line;
            }
            return Page();
        }
    }
}
