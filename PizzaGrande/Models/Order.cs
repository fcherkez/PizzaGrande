using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGrande.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }


        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public Guid PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public Guid DrinkId { get; set; }

        public Drink Drink { get; set; }

        [Required]
        [StringLength(255)]
        public decimal OrderTotal { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new Collection<OrderDetail>();
        }
    }
}
