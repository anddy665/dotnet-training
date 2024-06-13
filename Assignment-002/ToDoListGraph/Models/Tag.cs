using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoListGraphQL.Models
{
    [Table("tags")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<NoteTag> NoteTags { get; set; } = new List<NoteTag>();
    }
}
