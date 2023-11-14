namespace Project.Dtos.Marks
{
    public class StudentAverageDto
    {
        /// <summary>
        ///Student Id 
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        ///Student Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Average of all notes of a student
        /// </summary>
        public double AverageGrade { get; set; }
    }
}
