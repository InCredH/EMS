using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.GeneratingStations
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }


        [BindProperty]
        public GeneratingStation? GeneratingStation { get; set; }

        [BindProperty]
        public int SelectedFuelId { get; set; }

        [BindProperty]
        public int SelectedGeneratingStationClassificationId { get; set; }

        [BindProperty]
        public int SelectedGeneratingStationTypeId { get; set; }

        public SelectList? FuelList { get; set; }

        public SelectList? GeneratingStationClassificationList { get; set; }

        public SelectList? GeneratingStationTypeList { get; set; }
        
        public IActionResult OnGet()
        {
            FuelList = new SelectList(_context.Fuel, "FuelId", "FuelName");
            GeneratingStationClassificationList = new SelectList(_context.GeneratingStationClassification, "GeneratingStationClassificationId", "Classification");
            GeneratingStationTypeList = new SelectList(_context.GeneratingStationType, "GeneratingStationTypeId", "StationType");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            if(GeneratingStation != null) {
                GeneratingStation.FuelId = SelectedFuelId;
                GeneratingStation.GeneratingStationClassificationId = SelectedGeneratingStationClassificationId;
                GeneratingStation.GeneratingStationTypeId = SelectedGeneratingStationTypeId;
                _context.GeneratingStation.Add(GeneratingStation);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToPage("./Index");
        }
    }
}
