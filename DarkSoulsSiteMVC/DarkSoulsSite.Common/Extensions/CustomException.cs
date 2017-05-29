using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Common.Extensions
{
    class CustomException : Exception
    {
        public CustomException(Exception ex)
        {
            this.OriginalException = ex;
            this.Id = new CustomId().ToString();
        }

        [Key]
        public string Id { get; set; }

        public Exception OriginalException { get; set; }

        public string ClientErrorMessage { get { return string.Format("Unexpected error with Id: {0} has occured on the server.", this.Id); } }

    }
}
