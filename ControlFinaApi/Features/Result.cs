namespace ControlFinaApi.Features
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public int StatusCode { get; }
        public T? Content { get; }
        public IEnumerable<string> Errors { get; }

        private Result(T? content, bool isSuccess, int statusCode, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Content = content;
            Errors = errors;
            StatusCode = statusCode;
        }

        public static Result<T> Success(T content) => new Result<T>(content, true, StatusCodes.Status200OK, []);
        public static Result<T> SuccessCreate(T content) => new Result<T>(content, true, StatusCodes.Status201Created, []);
        public static Result<T> Failure(string error) => new Result<T>(default, false, StatusCodes.Status400BadRequest, [error]);
        public static Result<T> Failure(IEnumerable<string> errors) => new Result<T>(default, false, StatusCodes.Status400BadRequest, errors);
        public static Result<T> NotFound(string error) => new Result<T>(default, false, StatusCodes.Status404NotFound, [error]);
    }

}
