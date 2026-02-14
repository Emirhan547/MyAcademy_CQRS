namespace MyAcademyCQRS.Core.Application.Common.Results
{
    public abstract class BaseResult
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public List<string> Errors { get; protected set; } = new();

        protected BaseResult(bool success, string message, List<string>? errors = null)
        {
            Success = success;
            Message = message;
            if (errors != null)
                Errors = errors;
        }
    }
}