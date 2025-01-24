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
using Quartz;
using Quartz.Impl;
using URFU_Scheduling.Jobs;
using Quartz.Simpl;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

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
builder.Services.AddScoped<IEventImportProvider, CSVEventImportProvider>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = new PathString("/Auth/Login");
                });
builder.Services.AddSignalR();

builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddTransient<DailyEventNotificationJob>();
builder.Services.AddSingleton(provider =>
{
    var schedulerFactory = provider.GetRequiredService<ISchedulerFactory>();
    var scheduler = schedulerFactory.GetScheduler().Result;
    scheduler.JobFactory = provider.GetRequiredService<MicrosoftDependencyInjectionJobFactory>();
    return scheduler;
});
builder.Services.AddSingleton<MicrosoftDependencyInjectionJobFactory>();

builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddLogging(builder => builder.AddConsole());

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
