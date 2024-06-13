using ToDoListGraphQL.GraphQL.Type;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.GraphQL.Queries
{
    public static class NoteQueryType
    {
        public static IObjectFieldDescriptor AddNoteQueries(this IObjectTypeDescriptor descriptor)
        {
            return descriptor
            .Field("notes")
                .Type<ListType<NoteType>>()
                .Resolve(async ctx =>
                {
                    var noteRepository = ctx.Service<INoteRepository>();
                    return await noteRepository.GetNotes();
                });

        }
    }
}
