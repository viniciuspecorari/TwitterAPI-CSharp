﻿namespace TwitterAPI.Errors
{
    public class Exceptions : ApplicationException
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        public Exceptions(string statusCode, string message, string details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
    }
}
