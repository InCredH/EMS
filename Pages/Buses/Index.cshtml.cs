using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Buses
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Bus> Bus { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bus != null)
            {
                Bus = await _context.Bus
                .Include(b => b.Element)
                .Include(b => b.Substation).ToListAsync();
            }
        }
    }
}
