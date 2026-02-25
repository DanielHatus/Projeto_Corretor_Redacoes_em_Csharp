public class BaseInfraExcpetion:Exception{
    private readonly int StatusCode;   
    public BaseInfraExcpetion(string message,int statusCode) : base(message)=>this.StatusCode=statusCode;
}