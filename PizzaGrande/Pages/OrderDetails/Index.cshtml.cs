using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.OrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public IndexModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; }

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.OrderDetail
                .Include(o => o.Order).ToListAsync();
        }
    }
}
