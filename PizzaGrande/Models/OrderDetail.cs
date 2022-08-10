using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGrande.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }

        [Required]
        [StringLength(255)]
        public string PizzaName { get; set; }

        [Required]
        [StringLength(255)]
        public string DrinkName { get; set; }

        [Required]
        [StringLength(255)]
        public int Quantity { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
