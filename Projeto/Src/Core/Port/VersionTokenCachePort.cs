using Src.Core.Domain.Model;

public interface VersionTokenCachePort{
    Task SaveVersionTokenInCache(VersionTokenDomain versionToken);
    Task UpdateVersionTokenInCache(VersionTokenDomain versionToken);
    Task<UserDomain> GetVersionTokenById(long id);
    Task DeleteVersionToken(long id);
}