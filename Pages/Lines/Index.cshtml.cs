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
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Line> Line { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Line != null)
            {
                Line = await _context.Line
                .Include(l => l.Element)
                .Include(l => l.FromBus)
                .Include(l => l.ToBus)
                .Include(l => l.Voltage).ToListAsync();
            }
        }
    }
}
