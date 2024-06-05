using ToDoListWithLambdaAndLinq.Data;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesAppContext _context;

        public NoteRepository(NotesAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public Note GetNoteById(int id)
        {
            var note = (from n in _context.Notes
                        where n.Id == id
                        select n).FirstOrDefault();

            if (note == null)
            {
                throw new Exception($"Note with ID {id} not found.");
            }
            
            return note;
        }

        public void CreateNote(Note note, int[] tagIds)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();

            foreach (var tagId in tagIds)
            {
                var noteTag = new NoteTag
                {
                    NoteId = note.Id,
                    TagId = tagId
                };
                _context.NoteTags.Add(noteTag);
            }
            _context.SaveChanges();
        }

        public void UpdateNote(Note note, int[] tagIds)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();

            var existingTags = _context.NoteTags.Where(nt => nt.NoteId == note.Id).ToList();
            _context.NoteTags.RemoveRange(existingTags);

            foreach (var tagId in tagIds)
            {
                var noteTag = new NoteTag
                {
                    NoteId = note.Id,
                    TagId = tagId
                };
                _context.NoteTags.Add(noteTag);
            }
            _context.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                var noteTags = _context.NoteTags.Where(nt => nt.NoteId == note.Id).ToList();
                _context.NoteTags.RemoveRange(noteTags);
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Note> GetNotesByUserId(int userId)
        {
            return _context.Notes.Where(n => n.UserId == userId).ToList();
        }
    }
}
