using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        //private readonly StudentsDbContext context;
        //public DataAccessLayerSubjects(StudentsDbContext context)
        //{
        //    this.context = context;
        //}
        public Subject CreateSubject(string subjectName)
        {
            //using var context = new StudentsDbContext(connectionString);
            var subject = new Subject { Name = subjectName };
            context.Subjects.Add(subject);
            context.SaveChanges();
            return subject;
        }
    }
}
