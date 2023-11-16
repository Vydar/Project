namespace Project.Dtos.Marks
{
    public class StudentAverageDto
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Average of all notes of a student
        /// </summary>
        public double AverageGrade { get; set; }
    }
}
