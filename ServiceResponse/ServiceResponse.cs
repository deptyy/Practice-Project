namespace WebApplicationDemo2.ServiceResponder
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public string Error { get; set; } = null;
        public List<string> ErrorMessages { get; set; } = null;
        public ServiceResponse(bool success, T data, string errorMessage = null!)
        {
            Success = success;
            Error = errorMessage;
            Data = data;
        }
    }
}
