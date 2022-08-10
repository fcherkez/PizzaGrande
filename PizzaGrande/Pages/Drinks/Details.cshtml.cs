using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.Drinks
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public DetailsModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drink.FirstOrDefaultAsync(m => m.DrinkId == id);

            if (Drink == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
