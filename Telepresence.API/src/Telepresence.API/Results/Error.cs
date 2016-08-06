namespace Telepresence.API.Results
{
    /// <summary>
    /// Represents a error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error Code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Error Description
        /// </summary>
        public string Description { get; set; }
    }
}
