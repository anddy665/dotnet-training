using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotes();
        Task<Note> AddNote(Note note);
        Task<Note> UpdateNote(Note note);
        Task<Note?> DeleteNote(int id);

    }
}
