using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public CreateModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DrinkId"] = new SelectList(_context.Drink, "DrinkId", "DrinkId");
        ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "PizzaId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
