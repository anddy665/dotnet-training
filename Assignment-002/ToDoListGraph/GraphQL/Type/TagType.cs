using HotChocolate.Types;
using ToDoListGraphQLTag = ToDoListGraphQL.Models.Tag;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class TagType : ObjectType<ToDoListGraphQLTag>
    {
        protected override void Configure(IObjectTypeDescriptor<ToDoListGraphQLTag> descriptor)
        {
            descriptor.Field(x => x.id)
                .Type<IntType>();

            descriptor.Field(x => x.Name)
                .Type<StringType>();

            descriptor.Field(t => t.CreatedAt)
                .Type<DateTimeType>();

            descriptor.Field(t => t.NoteTags)
                .Type<ListType<NoteTagType>>();

        }
    }
}
