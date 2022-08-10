using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaGrande.Models;

namespace PizzaGrande.Models
{
    public class PizzaGrandeContext : IdentityDbContext
    {
        public PizzaGrandeContext (DbContextOptions<PizzaGrandeContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaGrande.Models.Category> Category { get; set; }

        public DbSet<PizzaGrande.Models.Drink> Drink { get; set; }

        public DbSet<PizzaGrande.Models.OrderDetail> OrderDetail { get; set; }

        public DbSet<PizzaGrande.Models.Order> Order { get; set; }

        public DbSet<PizzaGrande.Models.Pizza> Pizza { get; set; }
        
        
        public DbSet<PizzaGrande.Models.ApplicationUser>ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("18118057");
            base.OnModelCreating(modelBuilder);
        }
    }
}
