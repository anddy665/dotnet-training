using HotChocolate.Types;
using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.GraphQL.Type
{
    public class NoteTagType : ObjectType<NoteTag>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteTag> descriptor)
        {
            descriptor.Field(nt => nt.id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(nt => nt.NoteId)
                .Type<NonNullType<IntType>>();

            descriptor.Field(nt => nt.TagId)
                .Type<NonNullType<IntType>>();

            descriptor.Field(nt => nt.Note)
                .Type<NoteType>();

            descriptor.Field(nt => nt.Tag)
                .Type<TagType>();
        }
    }
}
