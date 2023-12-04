using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Models;
namespace EMS.Pages.Transformers
{
    public class CreateModel : PageModel
    {
        private readonly EMS.Data.DataContext _context;

        public CreateModel(EMS.Data.DataContext context)
        {
            _context = context;
        }
        // 
        public IActionResult OnGet()
        {
            ViewData["ElementId"] = new SelectList(_context.Set<Element>(), "ElementId", "ElementId");
            ViewData["TransformerType"] = new SelectList(Enum.GetValues(typeof(TransformerType)));
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "LocationId", "LocationName");
            ViewData["Voltage1Id"] = new SelectList(_context.Set<Voltage>(), "VoltageId", "VoltageLevel");
            ViewData["Voltage2Id"] = new SelectList(_context.Set<Voltage>(), "VoltageId", "VoltageLevel");
            ViewData["Substation1Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Substation2Id"] = new SelectList(_context.Set<Substation>(), "SubstationId", "SubstationName");
            ViewData["Owners"] = new SelectList(_context.Set<Owner>(), "OwnerId", "OwnerName");
            return Page();
        }

        [BindProperty]
        public Transformer Transformer { get; set; } = default!;
        [BindProperty]
        public Element? Element { get; set; } = default!;
        [BindProperty]
        public ElementOwner? ElementOwner { get; set; } = default!;
         
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Transformer == null || Transformer == null)
            {
                return Page();
            }
            if(Element == null || Transformer == null) {
                Console.WriteLine("Element or Transformer is null");
                return Page();
            }
            Element.ElementType = "Transformer";

            // Add the element to the context
            _context.Element.Add(Element);

            // Save changes to retrieve the ElementId
            await _context.SaveChangesAsync();

            // Fetch the last ElementId inserted
            var lastElementId = _context.Element.Max(e => e.ElementId);

            // Set the elementId in the bay
            Transformer.ElementId = lastElementId;
            
            _context.Transformer.Add(Transformer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
