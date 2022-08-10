using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.Drinks
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
            return Page();
        }

        [BindProperty]
        public Drink Drink { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drink.Add(Drink);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
