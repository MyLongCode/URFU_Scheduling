using Microsoft.EntityFrameworkCore;
using URFU_Scheduling.Infrastructure.Data;
using System.Drawing;
using URFU_Scheduling.Domain.Repositories;
using URFU_Scheduling.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SchedulingDB");
builder.Services.AddDbContext<SchedulingContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
