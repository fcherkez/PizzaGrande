using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.OrderDetails
{
    public class EditModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public EditModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.OrderDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderDetailExists(Guid id)
        {
            return _context.OrderDetail.Any(e => e.OrderDetailId == id);
        }
    }
}
