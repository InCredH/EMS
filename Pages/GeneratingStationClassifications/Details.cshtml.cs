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
    public class DetailsModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public DetailsModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

      public GeneratingStationClassification GeneratingStationClassification { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GeneratingStationClassification == null)
            {
                return NotFound();
            }

            var generatingstationclassification = await _context.GeneratingStationClassification.FirstOrDefaultAsync(m => m.GeneratingStationClassificationId == id);
            if (generatingstationclassification == null)
            {
                return NotFound();
            }
            else 
            {
                GeneratingStationClassification = generatingstationclassification;
            }
            return Page();
        }
    }
}
