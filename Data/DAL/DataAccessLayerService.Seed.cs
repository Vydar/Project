using Data.Models;

namespace Data.DAL
{
    internal partial class DataAccessLayerService : IDataAccessLayerService
    {
        public void Seed()
        {
            context.Add(new Student
            {
                Name = "Alexi",
                LastName = "Laiho",
                Age = 45,
                Address = new Address
                {
                    City = "Helsinki",
                    Street = "Porvoo St",
                    Number = 658
                }
            });

            context.Add(new Student
            {
                Name = "Tom",
                LastName = "Araya",
                Age = 58,
                Address = new Address
                {
                    City = "Santiago",
                    Street = "Central St",
                    Number = 66
                }
            });

            context.Add(new Student
            {
                Name = "James",
                LastName = "Hetfield",
                Age = 61,
                Address = new Address
                {
                    City = "Chicago",
                    Street = "Main St",
                    Number = 506
                }
            });

            context.Add(new Student
            {
                Name = "Dave",
                LastName = "Mustaine",
                Age = 59,
                Address = new Address
                {
                    City = "Florida",
                    Street = "White St",
                    Number = 168
                }
            });

            context.Add(new Student
            {
                Name = "Jimmy",
                LastName = "Page",
                Age = 71,
                Address = new Address
                {
                    City = "London",
                    Street = "Royal St",
                    Number = 84
                }
            });
            context.SaveChanges();
        }
    }
}
