namespace LibraryGraphQLApp.API.Utilities;

public class OperationResult<T>
{
    public bool IsSuccess { get; }
    public string Message { get; }
    public T Data { get; }

    private OperationResult(bool isSuccess, string message, T data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public static OperationResult<T> Success(T data) => new OperationResult<T>(true, string.Empty, data);

    public static OperationResult<T> Failure(string message) => new OperationResult<T>(false, message, default);
}
