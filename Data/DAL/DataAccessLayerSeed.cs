using Data.DAL;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class DataAccessLayerSeed
    {
        private readonly StudentsDbContext context;
        public DataAccessLayerSeed(StudentsDbContext context)
        {
            this.context = context;
        }

    }
}
