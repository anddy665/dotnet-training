using ToDoListGraphQLTag = ToDoListGraphQL.Models.Tag;

namespace ToDoListGraphQL.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<List<ToDoListGraphQLTag>> GetAllTags();
        Task<ToDoListGraphQLTag?> GetTagById(int id);
        Task<ToDoListGraphQLTag> AddTag(ToDoListGraphQLTag tag);
        Task<ToDoListGraphQLTag> UpdateTag(ToDoListGraphQLTag tag);
        Task<ToDoListGraphQLTag?> DeleteTag(int id);
    }
}
