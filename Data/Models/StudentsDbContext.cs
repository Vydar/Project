using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Data.Models
{
    public class StudentsDbContext : DbContext, IStudentsDbContext
    {
        //private readonly string connectionString;
        //public StudentsDbContext(string connString)
        //{
        //    this.connectionString = connString;
        //}



        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer(connectionString);
        //}

    }
}
