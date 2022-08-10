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
    public class IndexModel : PageModel
    {
        private readonly PizzaGrande.Models.PizzaGrandeContext _context;

        public IndexModel(PizzaGrande.Models.PizzaGrandeContext context)
        {
            _context = context;
        }
        public string CurrentSort {get;set;}
        public string CurrentFilter { get; set; }
        public string DrinkNameSort { get; set; }
        public string PriceSort { get; set; }
        public PaginatedList<Drink> Drink { get;set; }

        public async Task OnGetAsync(string sort, string searchString, 
            string currentFilter, int? pageIndex)
        {
            CurrentFilter = searchString;
            CurrentSort = sort;

            DrinkNameSort = sort == "DrinkName" ? "DrinkName_desc" : "DrinkName";
            PriceSort = sort == "Price" ? "Price_desc" : "Price";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            IQueryable<Drink> drinkIQ = from d in _context.Drink select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                drinkIQ = drinkIQ.Where(d =>
                d.DrinkName.Contains(searchString)

                );

            }

            switch (sort)
            {
                case "DrinkName_desc":
                    drinkIQ = drinkIQ.OrderByDescending(d => d.DrinkName);
                    break;
                case "DrinkName":
                    drinkIQ = drinkIQ.OrderBy(d => d.DrinkName);
                    break;
                case "Price_desc":
                    drinkIQ = drinkIQ.OrderByDescending(d => d.Price);
                    break;
                case "Price":
                    drinkIQ = drinkIQ.OrderBy(d => d.Price);
                    break;

            }
            //Drink = await drinkIQ.AsNoTracking().ToListAsync();
            int pageSize = 3;
            Drink = await PaginatedList<Drink>.CreateAsync
                (drinkIQ.AsNoTracking(),pageIndex ?? 1, pageSize);

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
