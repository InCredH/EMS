using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.FilterBanks
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public IndexModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<FilterBank> FilterBank { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FilterBank != null)
            {
                FilterBank = await _context.FilterBank
                .Include(f => f.Region)
                .Include(f => f.Substation1)
                .Include(f => f.Substation2)
                .Include(f => f.Voltage).ToListAsync();
            }
        }
    }
}
