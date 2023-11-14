using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Data.Models
{
    public class StudentsDbContext : DbContext //implement interface to make private or internal? 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
