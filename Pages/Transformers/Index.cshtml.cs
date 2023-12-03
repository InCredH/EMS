using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Transformers
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public IndexModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Transformer> Transformer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Transformer != null)
            {
                Transformer = await _context.Transformer
                .Include(t => t.Element)
                .Include(t => t.Location)
                .Include(t => t.Voltage1)
                .Include(t => t.Voltage2).ToListAsync();
            }
        }
    }
}
