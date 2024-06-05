using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
        void CreateNote(Note note, int[] tagIds);
        void UpdateNote(Note note, int[] tagIds);
        void DeleteNote(int id);
        IEnumerable<Note> GetNotesByUserId(int userId);
    }
}
