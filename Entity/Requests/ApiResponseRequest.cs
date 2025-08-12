namespace Entity.Requests
{
    /// <summary>
    /// Represents a standardized response structure for API responses.
    /// It includes properties for the status, message, and data, allowing flexibility to return any type of data.
    /// </summary>
    /// <typeparam name="T">The type of data returned in the response.</typeparam>
    public class ApiResponseRequest<T>
    {
        /// <summary>
        /// Gets or sets the status of the request. 
        /// True if the request is successful, False otherwise.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets a custom message that provides additional information about the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data returned in the response.
        /// This can be a single entity or a list of entities depending on the generic type <typeparamref name="T"/>.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}"/> class with default values.
        /// Sets the status to true, the message to "Ok", and the data to its default value.
        /// </summary>
        /// <param name="data">The data to be included in the response (ignored in this constructor).</param>
        public ApiResponseRequest(IEnumerable<DataSelectRequest> data)
        {
            Status = true;
            Message = "Ok";
            Data = default(T);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}"/> class with the provided information.
        /// </summary>
        /// <param name="data">The data to be included in the response.</param>
        /// <param name="status">The status of the request (True or False).</param>
        /// <param name="message">A custom message providing additional information about the request.</param>
        public ApiResponseRequest(T data, bool status, string message)
        {
            Data = data;
            Status = status;
            Message = message;
        }
    }
}