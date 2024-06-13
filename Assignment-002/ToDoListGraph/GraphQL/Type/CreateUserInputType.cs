using HotChocolate.Types;
using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class CreateUserInputType : InputObjectType<User>
    {
        protected override void Configure(IInputObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(t => t.id)
                .Type<IdType>().Ignore();

            descriptor.Field(t => t.Username)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Email)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Password)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Notes).Ignore();
        }
    }
}
