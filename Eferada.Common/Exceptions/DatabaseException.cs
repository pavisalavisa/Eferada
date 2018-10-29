using System;

namespace Eferada.Common.Exceptions
{
    public enum DatabaseErrorCode
    {
        Unknown=0,
        EntityNotFound=1,
        DeleteError
    }

    public class DatabaseException:Exception
    {
        public DatabaseErrorCode ErrorCode { get; }

        public DatabaseException(DatabaseErrorCode errorCode)
        {
            ErrorCode = errorCode;
        }

        public DatabaseException(DatabaseErrorCode errorCode,string message):base (message)
        {
            ErrorCode = errorCode;
        }

        public DatabaseException(DatabaseErrorCode errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}