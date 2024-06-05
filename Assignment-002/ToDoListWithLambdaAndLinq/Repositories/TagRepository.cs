using ToDoListWithLambdaAndLinq.Data;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NotesAppContext _context;

        public TagRepository(NotesAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTagById(int id)
        {
            var tag = (from t in _context.Tags
                       where t.Id == id
                       select t).FirstOrDefault();

            if (tag == null)
            {
                throw new Exception($"Tag with ID {id} not found.");
            }

            return tag;
        }

        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            _context.SaveChanges();
        }

        public void DeleteTag(int id)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.Id == id);
            if (tag != null)
            {
                var noteTags = _context.NoteTags.Where(nt => nt.TagId == tag.Id).ToList();
                _context.NoteTags.RemoveRange(noteTags);
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }
    }
}
