using ToDoListGraphQL.Data;
using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class NoteType : ObjectType<Note>
    {
        protected override void Configure(IObjectTypeDescriptor<Note> descriptor)
        {
            descriptor.Field(n => n.id).
                Type<NonNullType<IdType>>();

            descriptor.Field(n => n.Title)
                .Type<NonNullType<StringType>>();

            descriptor.Field(n => n.Content)
                .Type<NonNullType<StringType>>();

            descriptor.Field(n => n.CreatedAt)
                .Type<NonNullType<DateTimeType>>();

            descriptor.Field(n => n.UpdatedAt)
                .Type<NonNullType<DateTimeType>>();

            descriptor.Field(n => n.UserId)
                .Type<NonNullType<IntType>>();

            descriptor.Field(n => n.CategoryId)
                .Type<NonNullType<IntType>>();

            descriptor.Field(n => n.NoteTags)
                .Type<ListType<NoteTagType>>();
        }
    }
}
