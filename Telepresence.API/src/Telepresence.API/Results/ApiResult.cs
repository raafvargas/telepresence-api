using System;
using System.Collections.Generic;
using System.Net;

namespace Telepresence.API.Results
{
    public class ApiResult
    {
        /// <summary>
        /// Constructor Method.
        /// </summary>
        public ApiResult()
        {
            Errors = new Error[] { };
        }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Response data object
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Actual page number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Error array
        /// </summary>
        public IEnumerable<Error> Errors { get; set; }

        /// <summary>
        /// Next page url
        /// </summary>
        public string NextPageUrl { get; set; }

        /// <summary>
        /// Previous page url
        /// </summary>
        public string PreviousPageUrl { get; set; }

        /// <summary>
        /// Request URL
        /// </summary>
        public string RequestUrl { get; set; }
    }
}
