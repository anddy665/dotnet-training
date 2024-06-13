using Microsoft.EntityFrameworkCore;
using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
    }
}
