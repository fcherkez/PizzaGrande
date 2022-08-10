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
    public class DetailsModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public DetailsModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetail
                .Include(o => o.Order).FirstOrDefaultAsync(m => m.OrderDetailId == id);

            if (OrderDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
