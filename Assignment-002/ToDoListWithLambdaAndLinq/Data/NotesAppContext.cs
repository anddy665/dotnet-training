using Microsoft.EntityFrameworkCore;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Data
{
    public class NotesAppContext : DbContext
    {
        public NotesAppContext(DbContextOptions<NotesAppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
    }
}
