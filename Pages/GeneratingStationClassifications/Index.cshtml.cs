using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.GeneratingStationClassifications
{
    public class IndexModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public IndexModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<GeneratingStationClassification> GeneratingStationClassification { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GeneratingStationClassification != null)
            {
                GeneratingStationClassification = await _context.GeneratingStationClassification.ToListAsync();
            }
        }
    }
}
