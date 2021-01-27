using System;
using MySql.Data.MySqlClient;

namespace MarampaWebApi
{
    public class MySqlErrorException : Exception
    {
        private MySqlException exception;
        private string errMessage;

        public MySqlErrorException(Exception ex) : base(ex.Message)
        {
            if (ex.InnerException != null && ex.InnerException.GetType() == typeof(MySqlException))
            {
                exception = ex.InnerException as MySqlException;
                errMessage = GetErrorMessage(exception.Number) ?? ex.InnerException.Message;
                throw new Exception(errMessage, exception);
            }
        }

        private string? GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 1062:
                    return "Maaf Data Sudah Ada !";
                default:
                    return null;
            }

        }

        internal Exception Throw()
        {
            return new Exception(errMessage, exception);
        }
    }
}