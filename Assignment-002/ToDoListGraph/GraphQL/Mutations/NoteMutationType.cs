using ToDoListGraphQL.GraphQL.Type;
using ToDoListGraphQL.Models;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.GraphQL.Mutations
{
    public static class NoteMutationType
    {
        public static void AddNoteMutations(this IObjectTypeDescriptor descriptor)
        {
            descriptor
                .Field("addNote")
                .Argument("note", a => a.Type<NonNullType<CreateNoteInputType>>())
                .Type<NoteType>()
                .Resolve(async ctx =>
                {
                    var noteRepository = ctx.Service<INoteRepository>();
                    var note = ctx.ArgumentValue<Note>("note");
                    return await noteRepository.AddNote(note);
                });

            descriptor
                .Field("updateNote")
                .Argument("note", a => a.Type<NonNullType<CreateNoteInputType>>())
                .Type<NoteType>()
                .Resolve(async ctx =>
                {
                    var noteRepository = ctx.Service<INoteRepository>();
                    var note = ctx.ArgumentValue<Note>("note");
                    return await noteRepository.UpdateNote(note);
                });

            descriptor
                .Field("deleteNote")
                .Argument("id", a => a.Type<NonNullType<IdType>>())
                .Type<NoteType>()
                .Resolve(async ctx =>
                {
                    var noteRepository = ctx.Service<INoteRepository>();
                    var id = ctx.ArgumentValue<int>("id");
                    return await noteRepository.DeleteNote(id);
                });
        }
    }
}
