using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models
{
    public class Product
    {
        [Required]
        public int Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater than or equal to 0")]
        public int Stock { get; set; }

        [StringLength(100)]
        public string Category { get; set; }
    }
}
