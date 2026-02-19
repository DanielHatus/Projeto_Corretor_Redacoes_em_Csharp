using Src.Core.Domain.Model;

public interface ILoginUserUseCase{
    Task<UserDomain> Execute(LoginUserDto dto);
}