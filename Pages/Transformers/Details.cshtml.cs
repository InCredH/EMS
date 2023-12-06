using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Transformers
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public Transformer Transformer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }

            var transformer = await _context.Transformer.FirstOrDefaultAsync(m => m.TransformerId == id);
            if (transformer == null)
            {
                return NotFound();
            }
            else 
            {
                Transformer = transformer;
            }
            return Page();
        }
    }
}
