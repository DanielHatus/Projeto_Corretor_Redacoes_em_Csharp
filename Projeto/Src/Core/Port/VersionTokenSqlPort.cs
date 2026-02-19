using Src.Core.Domain.Model;

public interface VersionTokenSqlPort{
    Task<VersionTokenDomain> RegisterVersionToken(VersionTokenDomain versionToken);
    Task<VersionTokenDomain> UpdateVersionToken(VersionTokenDomain entityUpdated);
    Task DeleteVersionTokenById(long id);
    Task<VersionTokenDomain> GetVersionTokenById(long id);
}