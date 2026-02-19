using Src.Core.Port;
using Src.Domain.Exceptions;

namespace Src.Core.Domain.ValueObjects;
public class EmailVo{
    public string Value{get;}
    public EmailVo(string email){
        this.Value=email;
    }
    public static EmailVo CreateEmailValid(EmailValidatorPort emailPort,string email){
       return new EmailVo(ValidateEmail(emailPort,email));
    }

    private static string ValidateEmail(EmailValidatorPort emailPort,string email){
         if (!emailPort.SyntaxIsValid(email)){
            throw new DomainException("o email tem a sintaxe inválida. por favor inseri-lo corretamente.",400);
        }

        if (emailPort.existsUserWithEmailRecivedInRequest(email)){
            throw new DomainException("já existe um usuário cadastrado com este email. efetue o login na conta cadastrada ou insira outro email.",400);
        }

        return email;
    }
}