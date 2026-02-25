public class BCryptAdapter : BCryptPort{
    public string EncrypedPassword(string password){
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool PasswordsIsMatch(string passwordRequest, string passwordHash){
        return BCrypt.Net.BCrypt.Verify(passwordRequest,passwordHash);
    }
}