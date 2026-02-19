using Src.Core.Domain.Model;
public interface UserSqlPort{
  Task<UserDomain> RegisterUser(CreateAccountUserRequestDto dto);
  Task DeleteUserById(long id);
  Task<UserDomain> UpdateUser(UpdateAccountUserRequestDto dto,UserDomain actEntity);
  Task UpdateUserAdmin(UpdateAccountUserAdminRequestDto dto,UserDomain actEntity);
  Task<UserDomain> GetUserById(long id);
  Task<UserDomain> GetUserByEmail(string email); 
}