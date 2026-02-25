using Src.Core.Domain.Model;

public interface IGetUserByEmailUseCase{
    public Task<UserDomain> Execute(string email);
}