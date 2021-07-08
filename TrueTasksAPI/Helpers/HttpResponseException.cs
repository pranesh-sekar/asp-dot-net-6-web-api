using System;
using System.Collections;
using System.Net;
using TrueTasksAPI.Properties;

namespace TrueTasksAPI.Helpers
{
    public class HttpResponseException : Exception
    {

        public int Status { get; set; }
        public Object ResponseBody { get; set; }

        public HttpResponseException()
            : this(HttpStatusCode.InternalServerError, ErrorConstants.InternalServerError, null)
        {
        }

        public HttpResponseException(HttpStatusCode status) 
            : this(status, status.ToString(), null)
        {
        }

        public HttpResponseException(HttpStatusCode status, string message)
            : this(status, message, null)
        {

        }


        public HttpResponseException(HttpStatusCode status, string message,Object responseBody): base(message)
        {
            Status = (int) status;
            ResponseBody =  responseBody;
        }

    }
}
