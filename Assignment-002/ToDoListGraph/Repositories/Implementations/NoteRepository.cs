using Microsoft.EntityFrameworkCore;
using ToDoListGraphQL.Data;
using ToDoListGraphQL.Models;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.Repositories.Implementations
{
    public class NoteRepository : INoteRepository
    {
        private readonly ToDoListContext _context;

        public NoteRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetNotes()
        {
            return await _context.Notes.Include(n => n.User)
                                      .Include(n => n.Category)
                                      .Include(n => n.NoteTags)
                                          .ThenInclude(nt => nt.Tag)
                                      .ToListAsync();
        }

        public async Task<Note> AddNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note> UpdateNote(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note?> DeleteNote(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
            return note;
        }
    }
}
