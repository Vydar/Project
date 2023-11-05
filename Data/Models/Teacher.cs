using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.DAL.DataAccessLayerService;

namespace Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Rank Rank { get; set; }

        public List<Subject> Subjects { get; set; } 

    }
}
