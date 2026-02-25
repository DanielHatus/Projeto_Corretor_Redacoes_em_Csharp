using System.ComponentModel.DataAnnotations;
using Src.Core.Port;
using Src.Infra.Persistence.Repository.Contract;
public class EmailValidatorAdapter : EmailValidatorPort{

    private readonly IUserRepository _userRepository;

    public EmailValidatorAdapter(IUserRepository userRepository){
        this._userRepository=userRepository;
    }
    public async Task<bool> existsUserWithEmailRecivedInRequest(string email){
        return await _userRepository.ExistsUserRegistredFromEmail(email);
    }

    public bool SyntaxIsValid(string email){
       EmailAddressAttribute emailAddress=new EmailAddressAttribute();
       return emailAddress.IsValid(email);
    }
}