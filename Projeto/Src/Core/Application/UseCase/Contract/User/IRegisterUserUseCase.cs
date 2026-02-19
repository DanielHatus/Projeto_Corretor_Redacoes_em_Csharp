using Src.Core.Domain.Model;

public interface IRegisterUserUseCase{
    Task<UserDomain> Execute(CreateAccountUserRequestDto dto);
}