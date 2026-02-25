using Src.Domain.Exceptions;

namespace Src.Core.Domain.ValueObjects;
public class PasswordLoginVo{
    
    public string Value{get;}

    private static List<string> CHARACTER_SPECIAL_NECESSAIRY=["@","#","$","%","&","*","!"];
    private PasswordLoginVo(string password){
      this.Value=password;  
    }


    public static PasswordLoginVo CreatePasswordLoginValdid(BCryptPort bCryptPort,string password){
        string passwordValidated=bCryptPort.EncrypedPassword(ValidatePasswordLogin(password));
        return new PasswordLoginVo(passwordValidated);
    }

    public static PasswordLoginVo ReceivedPasswordLoginFromPersist(string password){
        return new PasswordLoginVo(password);
    }

    private static string ValidatePasswordLogin(string password){
       
       bool passwordContainsSpecialCharacters=false;

       if(password.Length<6|| password.Length > 25){
            throw new DomainException("o passwordLogin deve conter de 6 até no máximo 25 caracteres.",400);
        }

        foreach(char character in password){
            if(CHARACTER_SPECIAL_NECESSAIRY.Contains(character.ToString())){passwordContainsSpecialCharacters=true;}
        }

        if (!passwordContainsSpecialCharacters){
            throw new DomainException("o passwordLogin deve conter ao menos um caractere especial.",400);
        }
 
        return password;
    }
}