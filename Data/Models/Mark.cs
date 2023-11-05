using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public DateTime DateTime { get; set; } 

        public double Average { get; set; } // NEW VARIABLE
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int StudentId { get; set; } //navigational property
        public Student Student { get; set; }

    }
}
