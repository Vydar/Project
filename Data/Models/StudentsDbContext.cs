using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    internal class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public StudentsDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yardi\source\repos\Project\Data\StudentsDb.mdf;Integrated Security=True");
        }
    }
}
