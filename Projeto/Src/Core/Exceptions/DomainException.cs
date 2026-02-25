using Src.Domain.Exceptions.Base;

namespace Src.Domain.Exceptions;

public class DomainException : BaseDomainException{
    public DomainException(string message,int statusCode):base(message,statusCode){}
}
