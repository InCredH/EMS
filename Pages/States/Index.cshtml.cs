using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.States
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<State> State { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.State != null)
            {
                State = await _context.State.ToListAsync();
            }
        }
    }
}
