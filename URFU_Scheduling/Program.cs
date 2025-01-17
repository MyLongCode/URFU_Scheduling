using Microsoft.EntityFrameworkCore;
using URFU_Scheduling_lib.Infrastructure.Data;
using URFU_Scheduling_lib.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using URFU_Scheduling.Services;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling.Utilities;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SchedulingDB");
builder.Services.AddDbContext<SchedulingContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ScheduleRepository>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<RecurrenceRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
//builder.Services.AddScoped<IScheduleExportProvider, SheetsScheduleExportProvider>();
builder.Services.AddScoped<IScheduleExportProvider, IcsScheduleExportProvider>();
builder.Services.AddScoped<IScheduleImportProvider, IcsScheduleImportProvider>();
builder.Services.AddScoped<IRecurrenceService, RecurrenceService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = new PathString("/Auth/Login");
                });
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<NotificationHub>("/ws");

app.Run();
