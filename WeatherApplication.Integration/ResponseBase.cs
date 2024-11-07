namespace WeatherApplication.Integration;

public class ResponseBase<TResult>
{
    public TResult? Result { get; set; }
    
    public bool IsSuccess { get; set; }
}
