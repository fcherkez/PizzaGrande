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
    public class IndexModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public IndexModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string PizzaNameSort { get; set; }
        public string PriceSort { get; set; }
        public PaginatedList<Pizza> Pizza { get;set; }

        public async Task OnGetAsync(string sort, string searchString,
            string currentFilter, int? pageIndex)
        {
            CurrentFilter = searchString;
            CurrentSort = sort;


            PizzaNameSort = sort == "PizzaName" ? "PizzaName_desc" : "PizzaName";
            PriceSort = sort == "Price" ? "Price_desc" : "Price";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            IQueryable<Pizza> pizzaIQ = from p in _context.Pizza select p;
            

            if (!String.IsNullOrEmpty(searchString))
            {
                pizzaIQ = pizzaIQ.Where(p =>
                p.PizzaName.Contains(searchString)
                
                );

            }

            switch (sort)
            {
                case "PizzaName_desc":
                    pizzaIQ = pizzaIQ.OrderByDescending(p => p.PizzaName);
                    break;
                case "PizzaName":
                    pizzaIQ = pizzaIQ.OrderBy(p => p.PizzaName);
                    break;
                case "Price_desc":
                    pizzaIQ = pizzaIQ.OrderByDescending(p => p.Price);
                    break;
                case "Price":
                    pizzaIQ = pizzaIQ.OrderBy(p => p.Price);
                    break;

            }
            //Drink = await drinkIQ.AsNoTracking().ToListAsync();
            int pageSize = 3;
            Pizza = await PaginatedList<Pizza>.CreateAsync
                (pizzaIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
        public class PaginatedList<T> : List<T>
        {
            public int PageIndex { get; private set; }
            public int TotalPages { get; private set; }
            public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                this.AddRange(items);
            }
            public bool HasPreviousPage { get { return (PageIndex > 1); } }
            public bool HasNextPage { get { return (PageIndex < TotalPages); } }
            public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
            {
                var count = await source.CountAsync();
                var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }
        }

    }
}
