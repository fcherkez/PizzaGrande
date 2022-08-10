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
    public class MenuPizzaModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public MenuPizzaModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get; set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizza.ToListAsync();
        }
    }
}
