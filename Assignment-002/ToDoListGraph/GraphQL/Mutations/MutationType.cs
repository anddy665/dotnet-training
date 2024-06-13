namespace ToDoListGraphQL.GraphQL.Mutations
{
    public class MutationType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor
                .AddNoteMutations();

            descriptor
                .AddCategoryMutations();

            descriptor
                .AddUserMutations();

            descriptor
                .AddTagMutations();
        }
    }
}
