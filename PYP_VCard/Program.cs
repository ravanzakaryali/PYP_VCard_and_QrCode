using Business.Extensions;
using Business.HttpClientService;
using Business.Services.Abstarctions;
using Business.Services.Implementations;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddRefitHttpClient<IUserClient>("https://randomuser.me/");
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVCardService, VCardService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
