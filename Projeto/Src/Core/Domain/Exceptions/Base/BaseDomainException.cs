namespace Src.Domain.Exceptions.Base;
public class BaseDomainException : Exception{
    public int StatusCode{get;}

    public BaseDomainException(string message,int statusCode) : base(message){
        this.StatusCode=statusCode;
    }
}