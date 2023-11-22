using Data.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using System.Drawing;

namespace Data.DBContext
{
   public interface IStudentsDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Mark> Marks { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

           
    }
}