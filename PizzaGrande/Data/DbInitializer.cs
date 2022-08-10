using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGrande.Data
{
    public class DbInitializer
    {
        public static void Initialize(PizzaGrandeContext context)
        {
            context.Database.EnsureCreated();
            if (context.Category.Any())
            {
                return;
            }
        //private readonly PizzaGrandeContext _db;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        //public DbInitializer(PizzaGrandeContext db, UserManager<IdentityUser> userManager,
        //    RoleManager<IdentityRole> roleManager)
        //{
        //    _db = db;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}
        //public void Initialize(PizzaGrandeContext context)
        //{
        //    try
        //    {
        //        if (_db.Database.GetPendingMigrations().Count() > 0)
        //        {
        //            _db.Database.Migrate();
        //        }
        //        if (!_roleManager.RoleExistsAsync(PizzaGrandeRoles.AdminEndUser).GetAwaiter().GetResult())
        //        {
        //            _roleManager.CreateAsync(new IdentityRole(PizzaGrandeRoles.AdminEndUser)).GetAwaiter().GetResult();
        //            _roleManager.CreateAsync(new IdentityRole(PizzaGrandeRoles.ClientEndUser)).GetAwaiter().GetResult();
        //        }
        //        else
        //        {
        //            return;
        //        }

        //        IdentityUser user = new IdentityUser()
        //        {
        //            UserName = "admin123@gmail.com",
        //            Email = "admin123@gmail.com",
        //            EmailConfirmed = true
        //        };

        //        _userManager.CreateAsync(user, "Admin_123").GetAwaiter().GetResult();
        //        _userManager.AddToRoleAsync(user, PizzaGrandeRoles.AdminEndUser).GetAwaiter().GetResult();
        //    }
            





























                ////category
                //var categories = new List<Category>()
                //{
                //    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Pizza"},
                //    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Drink" }

                //};
                //foreach (Category c in categories)
                //{
                //    context.Category.Add(c);
                //}


                ////drinks
                //var drinks = new List<Drink>()
                //{
                //    new Drink { DrinkId = Guid.NewGuid(), DrinkName = "Кока-кола", Price = ""  },
                //    new Drink { DrinkId = Guid.NewGuid(), DrinkName = "Фанта", Price = 2 },
                //    new Drink { DrinkId = Guid.NewGuid(), DrinkName = "Куинс", Price = 1 },

                //};
                //foreach (Drink d in drinks)
                //{
                //    context.Drink.Add(d);
                //}


                ////pizza
                //var pizzas = new List<Pizza>()
                //{
                //    new Pizza { PizzaId = Guid.NewGuid(), PizzaName = "Маргарита", ShortDescription="Нустоим вкус",LongDescription="Съставки: доматено пюре, кашкавал и подправки", Price =3.50 },
                //    new Pizza { PizzaId = Guid.NewGuid(), PizzaName = "Италия", ShortDescription="Нустоим вкус",LongDescription="Съставки: доматено пюре, шунка, сирене, маслини,кашкавал и подправки", Price = 4.10   },
                //    new Pizza { PizzaId = Guid.NewGuid(), PizzaName = "Пеперони", ShortDescription="Нустоим вкус",LongDescription="Съставки: доматено пюре, пеперони, маслини, кашкавал и подправки", Price = 5.20 }
                //};
                //foreach (Pizza p in pizzas)
                //{
                //    context.Pizza.Add(p);
                //}

                ////order
                //var оrders = new List<Order>()
                //{
                //    new Order { OrderId = Guid.NewGuid(), FirstName = "Иван",LastName="Иванов", Address="ул. Дунав 4",
                //        PhoneNumber = "+359895762123", Pizza = pizzas[0], Drink = drinks[0]},
                //     new Order { OrderId = Guid.NewGuid(), FirstName = "Димитър",LastName="Димитров", Address="ул. Марица 5",
                //        PhoneNumber = "+359896587321", Pizza = pizzas[1], Drink = drinks[1]},
                //      new Order { OrderId = Guid.NewGuid(), FirstName = "Петър",LastName="Петров", Address="ул. Вардар 6",
                //        PhoneNumber = "+359876352148", Pizza = pizzas[2], Drink = drinks[2]},
                //};
                //foreach (Order o in оrders)
                //{
                //    context.Order.Add(o);
                //}

                ////orderdetail
                //var оrderdetails = new List<OrderDetail>()
                //{
                //    new OrderDetail { OrderDetailId = Guid.NewGuid(), PizzaName = "Маргарита", DrinkName="Кока-Кола", Quantity=2, Price=2},

                //};
                //foreach (OrderDetail od in оrderdetails)
                //{
                //    context.OrderDetail.Add(od);
                //}
                context.SaveChanges();

        }
    }
}
