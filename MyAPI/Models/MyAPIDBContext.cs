using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyAPI.Models;

namespace MyAPI.Models
{
    public class MyAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MyAPIDBContext(DbContextOptions<MyAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("EnrollmentDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Enrollment> Enrollment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // define composite key
            builder.Entity<Enrollment>()
                .HasKey(e => new { e.CourseID, e.StudentID });
        }
    }
}
