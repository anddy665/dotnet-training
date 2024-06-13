using Microsoft.EntityFrameworkCore;
using ToDoListGraphQL.Data;
using ToDoListGraphQLTag = ToDoListGraphQL.Models.Tag;
using ToDoListGraphQL.Repositories.Interfaces;


namespace ToDoListGraphQL.Repositories.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly ToDoListContext _context;

        public TagRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoListGraphQLTag>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<ToDoListGraphQLTag?> GetTagById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<ToDoListGraphQLTag> AddTag(ToDoListGraphQLTag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<ToDoListGraphQLTag> UpdateTag(ToDoListGraphQLTag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<ToDoListGraphQLTag?> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
            return tag;
        }
    }
}
