using System.Runtime.Serialization;

namespace Data
{
    /// <summary>
    /// Exception that handles the creation of duplicated objects in the Database
    /// </summary>
    [Serializable]
    
    public class DuplicateObjectException : Exception
    {
        public DuplicateObjectException()
        {
        }

        public DuplicateObjectException(string? message) : base(message)
        {
        }

        public DuplicateObjectException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}