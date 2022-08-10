using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.Pizzas
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public DetailsModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public Pizza Pizza { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizza.FirstOrDefaultAsync(m => m.PizzaId == id);

            if (Pizza == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
