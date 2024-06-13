using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(t => t.id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Username)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Email)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Password)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Notes)
                .Type<ListType<NoteType>>();

        }
    }
}
