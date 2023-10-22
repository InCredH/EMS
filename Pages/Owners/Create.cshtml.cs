using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Data;
using EMS.Models;

namespace EMS.Pages.Owners
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.SchoolContext _context;

        public CreateModel(EMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        // Add properties for ConstituentName and ConstituentId
        [BindProperty]
        public int SelectedConstituentId { get; set; }

        public SelectList ConstituentList { get; set; }

        public IActionResult OnGet()
        {
            ConstituentList = new SelectList(_context.Constituent, "ConstituentId", "ConstituentName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set the ConstituentId based on the selected ConstituentName
            Owner.ConstituentId = SelectedConstituentId;

            _context.Owner.Add(Owner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
