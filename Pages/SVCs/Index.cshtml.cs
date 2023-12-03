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
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<SVC> SVC { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SVC != null)
            {
                SVC = await _context.SVC
                .Include(s => s.Bus)
                .Include(s => s.Element).ToListAsync();
            }
        }
    }
}
