using HotChocolate.Types;
using ToDoListGraphQLTag = ToDoListGraphQL.Models.Tag;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class CreateTagInputType : InputObjectType<ToDoListGraphQLTag>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ToDoListGraphQLTag> descriptor)
        {
            descriptor.Field(t => t.id)
                .Type<IdType>().Ignore();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.CreatedAt).Ignore();

            descriptor.Field(t => t.NoteTags).Ignore();
        }
    }
}
