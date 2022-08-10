using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGrande.Models
{
    public class Pizza
    {
        [Key]
        public Guid PizzaId { get; set; }

        [Required]
        [StringLength(255)]
        public string PizzaName { get; set; }

        

        [Required]
        [StringLength(50)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(255)]
        public string LongDescription { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public Category Category { get; set; }
        

      
    }
}
