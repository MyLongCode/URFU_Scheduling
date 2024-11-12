using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using src.Infrastructure.Data.DAL;

namespace src.Infrastructure.Data
{
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
        }
    }
}