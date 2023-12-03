using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.SVCs
{
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public SVC SVC { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SVC == null)
            {
                return NotFound();
            }

            var svc = await _context.SVC.FirstOrDefaultAsync(m => m.SVCId == id);
            if (svc == null)
            {
                return NotFound();
            }
            else 
            {
                SVC = svc;
            }
            return Page();
        }
    }
}
