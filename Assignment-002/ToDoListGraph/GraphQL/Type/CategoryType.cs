using HotChocolate.Types;
using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(x => x.id)
                .Type<IntType>();

            descriptor.Field(x => x.Name)
                .Type<StringType>();

            descriptor.Field(t => t.CreatedAt)
                .Type<DateTimeType>();

            descriptor.Field(x => x.Notes)
                .Type<ListType<NoteType>>();
        }
    }
}
