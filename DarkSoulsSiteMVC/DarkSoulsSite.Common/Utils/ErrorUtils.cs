using DarkSoulsSite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Common.Utils
{
    class ErrorUtils
    {
        public static string ConvertExceptionToJSON(Exception exception)
        {
            string exceptionMessage = exception.Message;
            string stackTrace = exception.StackTrace != null ? exception.StackTrace : String.Empty;

            string innerExMessage = exception.InnerException != null ? exception.InnerException.Message : String.Empty;
            string innerExStackTrace = exception.InnerException != null ? exception.InnerException.StackTrace : String.Empty;

            string message = "{ " +
                 "\"ExceptionMessage\" : \"" + exceptionMessage + "\", " +
                 "\"StackTrace\": \"" + stackTrace + "\"," +
                 "\"InnerExceptionMessage\": \"" + innerExMessage + "\"," +
                 "\"InnerStackTrace\": \"" + innerExStackTrace + "\"" +
                 "}";

            return message;
        }

        public static string ConvertCustomErrorToJSON(CustomException error)
        {
            string exceptionMessage = error.OriginalException.Message;
            string stackTrace = error.OriginalException.StackTrace != null ? error.OriginalException.StackTrace : String.Empty;

            string innerExMessage = error.OriginalException.InnerException != null ? error.OriginalException.InnerException.Message : String.Empty;
            string innerExStackTrace = error.OriginalException.InnerException != null ? error.OriginalException.InnerException.StackTrace : String.Empty;

            string message = "{ " +
                 "\"Id\" : \"" + error.Id + "\"," +
                 "\"ExceptionMessage\" : \"" + exceptionMessage + "\", " +
                 "\"StackTrace\": \"" + stackTrace + "\"," +
                 "\"InnerExceptionMessage\": \"" + innerExMessage + "\"," +
                 "\"InnerStackTrace\": \"" + innerExStackTrace + "\"" +
                 "}";

            return message;
        }
    }
}
