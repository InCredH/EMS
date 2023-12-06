using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.SubFilterBanks
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<SubFilterBank> SubFilterBank { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubFilterBank != null)
            {
                SubFilterBank = await _context.SubFilterBank
                .Include(s => s.Element)
                .Include(s => s.FilterBank).ToListAsync();
            }
        }
    }
}
