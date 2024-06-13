using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoListGraphQL.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
