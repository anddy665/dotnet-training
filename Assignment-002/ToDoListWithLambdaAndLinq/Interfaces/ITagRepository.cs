using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(int id);
    }
}
