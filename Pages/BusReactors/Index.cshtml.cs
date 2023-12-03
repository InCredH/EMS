using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.BusReactors
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<BusReactor> BusReactor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BusReactor != null)
            {
                BusReactor = await _context.BusReactor
                .Include(b => b.Bus)
                .Include(b => b.Element).ToListAsync();
            }
        }
    }
}
