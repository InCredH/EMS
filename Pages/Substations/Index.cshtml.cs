using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Substations
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public IndexModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Substation> Substation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Substation != null)
            {
                Substation = await _context.Substation
                .Include(s => s.Location)
                .Include(s => s.Voltage).ToListAsync();
            }
        }
    }
}
