namespace WeatherApplication.Integration;

public static class ResponseHelper
{
    public static ResponseBase<T> CreateSuccess<T>(T result) => new() { IsSuccess = true, Result = result };
    public static ResponseBase<T> CreateError<T>(T result) => new() { IsSuccess = false, Result = result };
}
