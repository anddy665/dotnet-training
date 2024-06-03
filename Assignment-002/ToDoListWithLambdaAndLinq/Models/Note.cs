using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListWithLambdaAndLinq.Models
{
    [Table("note")]
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("user")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<NoteTag> NoteTags { get; set; }
    }
}
