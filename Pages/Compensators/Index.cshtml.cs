using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Compensators
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public IndexModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Compensator> Compensator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Compensator != null)
            {
                Compensator = await _context.Compensator
                .Include(c => c.Region)
                .Include(c => c.Substation1)
                .Include(c => c.Substation2).ToListAsync();
            }
        }
    }
}
