namespace MyAcademyCQRS.Core.Application.Common.Results
{
    public sealed class Result : BaseResult
    {
        private Result(bool success, string message, List<string>? errors = null)
            : base(success, message, errors) { }

        public static Result SuccessResult(string message = "İşlem başarılı")
            => new(true, message);

        public static Result Failure(string message, List<string>? errors = null)
            => new(false, message, errors);
    }
}
