using ToDoListGraphQL.GraphQL.Type;
using ToDoListGraphQLTag = ToDoListGraphQL.Models.Tag;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.GraphQL.Mutations
{
    public static class TagMutationType
    {
        public static void AddTagMutations(this IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("addTag")
                .Argument("tag", a => a.Type<NonNullType<CreateTagInputType>>())
                .Type<TagType>()
                .Resolve(async ctx =>
                {
                    var tagRepository = ctx.Service<ITagRepository>();
                    var tag = ctx.ArgumentValue<ToDoListGraphQLTag>("tag");
                    return await tagRepository.AddTag(tag);
                });

            descriptor.Field("updateTag")
                .Argument("tag", a => a.Type<NonNullType<CreateTagInputType>>())
                .Type<TagType>()
                .Resolve(async ctx =>
                {
                    var tagRepository = ctx.Service<ITagRepository>();
                    var tag = ctx.ArgumentValue<ToDoListGraphQLTag>("tag");
                    return await tagRepository.UpdateTag(tag);
                });

            descriptor.Field("deleteTag")
                .Argument("id", a => a.Type<NonNullType<IntType>>())
                .Type<TagType>()
                .Resolve(async ctx =>
                {
                    var tagRepository = ctx.Service<ITagRepository>();
                    var id = ctx.ArgumentValue<int>("id");
                    return await tagRepository.DeleteTag(id);
                });
        }
    }
}
