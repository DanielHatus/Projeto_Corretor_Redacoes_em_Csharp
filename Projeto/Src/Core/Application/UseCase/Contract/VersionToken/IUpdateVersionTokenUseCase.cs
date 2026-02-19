using Src.Core.Domain.Model;

public interface IUpdateVersionTokenUseCase{
   Task<VersionTokenDomain> Execute(VersionTokenDomain versionTokenUpdatedEntityData); 
}