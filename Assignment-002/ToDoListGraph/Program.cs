using ToDoListGraphQL.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
using ToDoListGraphQL.Data;
using ToDoListGraphQL.Repositories.Interfaces;
using ToDoListGraphQL.Repositories.Implementations;
using ToDoListGraphQL.GraphQL.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToDoListContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repositories
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

// add services for GraphQL
builder.Services
    .AddGraphQLServer()
    .RegisterService<INoteRepository>()
    .RegisterService<ICategoryRepository>()
    .RegisterService<IUserRepository>()
    .RegisterService<ITagRepository>()
    .AddQueryType<QueryType>()
    .AddMutationType<MutationType>();

//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.MapGraphQL();

app.Run();