using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGrande.Models
{
    public class Drink
    {
        [Key]
        public Guid DrinkId { get; set; }

        [Required]
        [StringLength(255)]
        public string DrinkName { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(255)]
        public string LongDescription { get; set; }


        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public Category Category { get; set; }

    }
}
