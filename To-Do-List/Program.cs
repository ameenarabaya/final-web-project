using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

var builder = WebApplication.CreateBuilder(args);
//Create Session
builder.Services.AddMemoryCache();
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ToDoContextStr")));


var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
// For Session
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
