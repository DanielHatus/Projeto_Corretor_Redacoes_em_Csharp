using Src.Core.Domain.Model;

public interface IGetVersionTokenByIdUseCase{
    Task<VersionTokenDomain> Execute(long? id);
}