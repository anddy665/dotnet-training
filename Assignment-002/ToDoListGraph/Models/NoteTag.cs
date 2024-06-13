using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoListGraphQL.Models
{
    [Table("note_tags")]
    public class NoteTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public Note? Note { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
