﻿using static Data.DAL.DataAccessLayerService;

namespace Project.Dtos.Teachers
{
    public class TeacherToGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public String Address { get; set; }
        internal Rank Rank { get; set; }

    }
}
