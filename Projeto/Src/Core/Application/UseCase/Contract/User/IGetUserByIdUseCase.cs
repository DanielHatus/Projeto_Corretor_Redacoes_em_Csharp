using Src.Core.Domain.Model;

public interface IGetUserByIdUseCase{
    Task<UserDomain> Execute(long id);
}