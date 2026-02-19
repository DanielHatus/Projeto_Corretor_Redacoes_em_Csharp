using Src.Core.Domain.Model;

public interface UserCachePort{
    Task SaveUserInCache(UserDomain entity);
    Task UpdateUserInCache(UserDomain entity);
    Task DeleteUserInCacheById(long id);
    Task<UserDomain> GetUserInCacheById(long id);
}