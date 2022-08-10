using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;

namespace PizzaGrande.Pages.Categories
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
        public string CategoryNameSort { get; set; }
        public PaginatedList<Category> Category { get;set; }

        public async Task OnGetAsync(string sort, string searchString,
            string currentFilter, int? pageIndex)
        {
            CurrentFilter = searchString;
            CurrentSort = sort;

            CategoryNameSort = sort == "CategoryName" ? "CategoryName_desc" : "CategoryName";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            IQueryable<Category> categoryIQ = from ct in _context.Category select ct;

            if (!String.IsNullOrEmpty(searchString))
            {
                categoryIQ = categoryIQ.Where(ct =>
                ct.CategoryName.Contains(searchString)

                );

            }

            switch (sort)
            {
                case "CategoryName_desc":
                    categoryIQ = categoryIQ.OrderByDescending(ct => ct.CategoryName);
                    break;
                case "CategoryName":
                    categoryIQ = categoryIQ.OrderBy(ct => ct.CategoryName);
                    break;

            }
            int pageSize = 3;
            Category = await PaginatedList<Category>.CreateAsync
                (categoryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

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
