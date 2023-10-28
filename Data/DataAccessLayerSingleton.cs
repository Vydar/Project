using Azure;
using Data.Models;


namespace Data
{
    public class DataAccessLayerSingleton
    {
        #region singleton 
        private DataAccessLayerSingleton()
        {
        }

        private static DataAccessLayerSingleton instance;
        public static DataAccessLayerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccessLayerSingleton();
                }
                return instance;
            }
        }
        #endregion

        #region seed
        public void Seed()
        {
            using var context = new StudentsDbContext();

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
        #endregion

        public IEnumerable<Student> GetAllStudents()
        {
            using var context = new StudentsDbContext();
            return context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            using var context = new StudentsDbContext();
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        //public Student CreateStudent(string name, string lastName, int age)
        //{
        //    using var context = new StudentsDbContext();
        //    var student = new Student { Name = name, LastName = lastName, Age = age };
        //    context.Add(student);
        //    context.SaveChanges();
        //    return student;
        //}
        public Student CreateStudent(Student student)
        {
            using var context = new StudentsDbContext();

            if (context.Students.Any(s => s.Id == student.Id))
            {
                throw new DuplicateStudentException("The student exists already on the Database");                                        //check for grammar
            }
            context.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            using var context = new StudentsDbContext();

            var student = context.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                throw new InvalidIdException("The student Id does not exist on the Database");
            }
            student.Address = studentToUpdate.Address;
            student.Name = studentToUpdate.Name;
            student.LastName = studentToUpdate.LastName;
            student.Age = studentToUpdate.Age;

            context.SaveChanges();
            return student;
        }

        public Address UpdateAddress(Address addressToUpdate)
        {
            using var context = new StudentsDbContext();
            var address = context.Addresses.FirstOrDefault(s => s.Id == addressToUpdate.Id);

            //if (address == null)
            //{
            //    var newAddress = new Address
            //    {
            //                            City = addressToUpdate.City,
            //        Street = addressToUpdate.Street,
            //        Number = addressToUpdate.Number
            //    };
            //    context.Add(newAddress);
            //    context.SaveChanges();
            //    return newAddress;
            //}
            //else
            //{
            //    address.City = addressToUpdate.City;
            //    address.Street = addressToUpdate.Street;
            //    address.Number = addressToUpdate.Number;
            //    context.SaveChanges();
            //    return address;
            //}

            if (address == null)
            { 
           address = new Address();
            context.Add(address);
            }


            address.City = addressToUpdate.City;
            address.Street = addressToUpdate.Street;
            address.Number = addressToUpdate.Number;
            context.SaveChanges();
            return address;



        }
    }
}
