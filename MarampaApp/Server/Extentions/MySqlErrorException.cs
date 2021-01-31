using System;

namespace MarampaApp
{
    // public class MySqlErrorException : Exception
    // {
    //     private string errMessage;
    //     private Exception exception;

    //     public MySqlErrorException(Exception ex) : base(ex.Message)
    //     {
    //         exception = ex.InnerException;
    //         //if (ex.InnerException != null && ex.InnerException.GetType() == typeof(MySqlException))
    //         //{
    //         //    exception = ex.InnerException as MySqlException;
    //         //    errMessage = GetErrorMessage(exception.Number) ?? ex.InnerException.Message;
    //         //    throw new Exception(errMessage, exception);
    //         //}
    //     }

    //     private string? GetErrorMessage(int errorCode)
    //     {
    //         switch (errorCode)
    //         {
    //             case 1062:
    //                 return "Maaf Data Sudah Ada !";
    //             default:
    //                 return null;
    //         }

    //     }

    //     internal Exception Throw()
    //     {
    //         return new Exception(errMessage, exception);
    //     }
    // }
}