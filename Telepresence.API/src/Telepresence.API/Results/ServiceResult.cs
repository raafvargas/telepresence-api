using System.Collections.Generic;

namespace Telepresence.API.Results
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            Errors = new string[] { };
        }

        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
