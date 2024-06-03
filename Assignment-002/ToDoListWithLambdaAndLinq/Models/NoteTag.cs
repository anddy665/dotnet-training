using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListWithLambdaAndLinq.Models
{
    [Table("note_tag")]
    public class NoteTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("note")]
        public int NoteId { get; set; }
        public virtual Note Note { get; set; }

        [ForeignKey("tag")]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
