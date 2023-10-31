using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
    public class DuplicateStudentException : Exception
    {
        public DuplicateStudentException()
        {
        }

        public DuplicateStudentException(string? message) : base(message)
        {
        }

        public DuplicateStudentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateStudentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}