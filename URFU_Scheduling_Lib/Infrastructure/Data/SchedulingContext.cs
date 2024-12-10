using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Drawing;
using System.Text.RegularExpressions;
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Infrastructure.Data;

public class SchedulingContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Notification> Notifications { get; set; } = null!;
    public virtual DbSet<Schedule> Schedules { get; set; } = null!;
    public virtual DbSet<Tag> Tags { get; set; } = null!;
    public virtual DbSet<Event> Events { get; set; } = null!;


    public SchedulingContext(DbContextOptions<SchedulingContext> options)
        : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLazyLoadingProxies();

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Color>().HaveConversion<ColorToStringConverter>();
    }

    private class ColorToStringConverter : ValueConverter<Color, string>
    {
        public ColorToStringConverter() : base(v => $"rgb({v.R},{v.G},{v.B})", v => StringToColor(v))
        {
        }

        private static Color StringToColor(string color)
        {
            var nums = Regex.Matches(color, @"\d+")
                .Select(x => Int32.Parse(x.Value))
                .ToArray();

            return Color.FromArgb(nums[0], nums[1], nums[2]);
        }
    }
}