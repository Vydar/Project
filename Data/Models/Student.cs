namespace Data.Models
{
    /// <summary>
    /// Student Model - Id, Name, LastName, Age, Address, Marks, Subjects
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
