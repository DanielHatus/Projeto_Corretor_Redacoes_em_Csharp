using Src.Core.Domain.Model;

public interface IUpdateUserUseCase{
    
    Task<UserDomain> Execute(UpdateAccountUserRequestDto dto,UserDomain actEntity);
}