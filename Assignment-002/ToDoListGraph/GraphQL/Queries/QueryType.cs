using HotChocolate.Types;

namespace ToDoListGraphQL.GraphQL.Queries
{
    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor
                .AddNoteQueries();

            descriptor
                .AddCategoryQueries();

            descriptor
                .AddUserQueries();
        }
    }
}
