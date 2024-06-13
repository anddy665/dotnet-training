using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class CreateNoteInputType : InputObjectType<Note>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Note> descriptor)
        {
            descriptor.Field(x => x.id)
                .Type<IdType>().Ignore();

            descriptor.Field(x => x.Title)
                .Type<NonNullType<StringType>>();

            descriptor.Field(x => x.Content)
                .Type<NonNullType<StringType>>();

            descriptor.Field(x => x.CategoryId)
                .Type<IntType>();

            descriptor.Field(t => t.UserId)
                .Type<IntType>();

            descriptor.Field(t => t.User).Ignore();

            descriptor.Field(t => t.UpdatedAt).Ignore();

            descriptor.Field(t => t.CreatedAt).Ignore();

            descriptor.Field(t => t.NoteTags).Ignore();


        }
    }
}
