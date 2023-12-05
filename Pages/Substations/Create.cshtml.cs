using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;

namespace EMS.Pages.Substations
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Owners"] = new SelectList(_context.Owner, "OwnerId", "OwnerName");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationName");
            ViewData["VoltageId"] = new SelectList(_context.Voltage, "VoltageId", "VoltageLevel");
            ViewData["SubstationType"] = new SelectList(new List<string> { "AC", "DC" });
            return Page();
        }

        [BindProperty]
        public Substation? Substation { get; set; } = default!;
        [BindProperty]
        public Owner? Owner { get; set; } = default!;
        [BindProperty]
        public OwnerSubstation? OwnerSubstation { get; set; } = default!;
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Substation == null || Substation == null)
            {
                return Page();
            }

            _context.Substation.Add(Substation);
            await _context.SaveChangesAsync();

            var lastSubstationId = _context.Substation.Max(e => e.SubstationId);

            foreach (var ownerId in Request.Form["Owners"]) // Assuming "Owners" is the name of the multiple select control
            {
                var ownersubstation = new OwnerSubstation
                {
                    OwnerId = Convert.ToInt32(ownerId), // Assuming OwnerId is an integer
                    SubstationId = lastSubstationId
                };

                _context.OwnerSubstation.Add(ownersubstation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
