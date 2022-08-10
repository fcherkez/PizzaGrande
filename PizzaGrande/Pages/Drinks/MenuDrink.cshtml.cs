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
    public class MenuDrinkModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public MenuDrinkModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public IList<Drink> Drink { get; set; }

        public async Task OnGetAsync()
        {
            Drink = await _context.Drink.ToListAsync();
        }
    }
}
