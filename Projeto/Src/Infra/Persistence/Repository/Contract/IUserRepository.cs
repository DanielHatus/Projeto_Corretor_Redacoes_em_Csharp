using Src.Infra.Persistence.Model;

namespace Src.Infra.Persistence.Repository.Contract;
public interface IUserRepository{
    
     Task<UserPersist> RegisterUser(UserPersist entity);
     Task<UserPersist> UpdateUser(UserPersist entity,UpdateAccountUserRequestDto dto);
     Task<UserPersist> GetUserById(long id);
     Task<UserPersist> GetUserByEmail(string email);
     Task DeleteUserById(long id);
     Task UpdateUserAdmin(UserPersist actEntity,UpdateAccountUserAdminRequestDto dto);
     Task<bool> ExistsUserRegistredFromEmail(string email);
} 