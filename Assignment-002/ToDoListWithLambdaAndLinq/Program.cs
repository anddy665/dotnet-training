using Microsoft.EntityFrameworkCore;
using ToDoListWithLambdaAndLinq.Data;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;
using ToDoListWithLambdaAndLinq.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<NotesAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesAppContext"));
});

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
