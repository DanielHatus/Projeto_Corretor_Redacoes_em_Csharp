using Src.Core.Domain.Model;

public interface IRegisterVersionTokenUseCase{
    Task<VersionTokenDomain> Execute(long? idUser);
}