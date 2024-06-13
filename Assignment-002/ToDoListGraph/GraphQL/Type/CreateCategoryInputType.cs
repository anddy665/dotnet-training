using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class CreateCategoryInputType : InputObjectType<Category>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(t => t.id)
                .Type<IdType>().Ignore();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.CreatedAt).Ignore();

            descriptor.Field(t => t.Notes).Ignore();
        }
    }
}
