using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Bays
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public IndexModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Bay> Bay { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bays != null)
            {
                Bay = await _context.Bays
                .Include(b => b.Region)
                .Include(b => b.Substation1)
                .Include(b => b.Substation2)
                .Include(b => b.ConnectingElement1)
                .Include(b => b.ConnectingElement2)
                .Include(b => b.Owner)
                .Include(b => b.Voltage).ToListAsync();
            }
        }
    }
}
