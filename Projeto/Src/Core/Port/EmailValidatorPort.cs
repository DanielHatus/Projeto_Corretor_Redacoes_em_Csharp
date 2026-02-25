namespace Src.Core.Port;
public interface EmailValidatorPort{
    bool SyntaxIsValid(string email);
    Task<bool> existsUserWithEmailRecivedInRequest(string email);
}