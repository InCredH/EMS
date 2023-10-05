using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingUnits
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public IndexModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<GeneratingUnit> GeneratingUnit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GeneratingUnit != null)
            {
                GeneratingUnit = await _context.GeneratingUnit
                .Include(g => g.Region)
                .Include(g => g.Substation1)
                .Include(g => g.Substation2)
                .Include(g => g.GeneratingStation)
                .Include(g => g.GeneratingTransformerHVVoltage)
                .Include(g => g.Voltage).ToListAsync();
            }
        }
    }
}
