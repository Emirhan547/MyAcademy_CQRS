namespace MyAcademyCQRS.Core.Application.Common.Results
{
    public sealed class DataResult<T> : BaseResult
    {
        public T? Data { get; private set; }

        private DataResult(T? data, bool success, string message, List<string>? errors = null)
            : base(success, message, errors)
        {
            Data = data;
        }

        public static DataResult<T> Success(T data, string message = "İşlem başarılı")
            => new(data, true, message);

        public static DataResult<T> Failure(string message, List<string>? errors = null)
            => new(default, false, message, errors);
    }

}
