public interface BCryptPort{
    string EncrypedPassword(string password);
    bool PasswordsIsMatch(string passwordRequest,string passwordHash);
}