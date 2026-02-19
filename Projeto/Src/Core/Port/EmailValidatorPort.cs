namespace Src.Core.Port;
public interface EmailValidatorPort{
    bool SyntaxIsValid(string email);
    bool existsUserWithEmailRecivedInRequest(string email);
}