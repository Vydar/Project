namespace Data.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Mark> marks { get; set; } = new List<Mark>();
        public List<Subject> subjects { get; set; } = new List<Subject>();
        
         
    }
}
