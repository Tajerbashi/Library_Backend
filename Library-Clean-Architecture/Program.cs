using Application.Library.Interfaces;
using Application.Library.Service;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.DbContexts;

var builder = WebApplication.CreateBuilder(args);
//  Use Model One
var conectionString = @"Data Source=.; Initial Catalog=CleanArchLibraryDb; User id=sa; Password=123123; Integrated Security=true; TrustServerCertificate=True;";

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();

//  Use Model One
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option => option.UseSqlServer(conectionString));


var app = builder.Build();
//  DataBaseContext Injection
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();


app.Run();
