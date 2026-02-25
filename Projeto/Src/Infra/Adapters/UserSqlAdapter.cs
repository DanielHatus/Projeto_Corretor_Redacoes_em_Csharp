using Src.Core.Domain.Model;
using Src.Core.Domain.ValueObjects;
using Src.Core.Port;
using Src.Infra.Persistence.Model;
using Src.Infra.Persistence.Repository.Contract;

public class UserSqlAdapter : UserSqlPort{
    private readonly IUserRepository _userRepository;
    private readonly UserMapper _userMapper;
    private readonly EmailValidatorPort _validatorPort;

    public UserSqlAdapter(IUserRepository userRepository,UserMapper userMapper,EmailValidatorPort validatorPort){
        this._userRepository=userRepository;
        this._userMapper=userMapper;
        this._validatorPort=validatorPort;
    }
    public async Task DeleteUserById(long id){
        await _userRepository.DeleteUserById(id);
    }
    public async Task<UserDomain> GetUserByEmail(string email){
        UserPersist entityPersist=await _userRepository.GetUserByEmail(email);
        return _userMapper.toDomain(entityPersist);
    }
    public async Task<UserDomain> GetUserById(long id){
        UserPersist entityPersist=await _userRepository.GetUserById(id);
        return _userMapper.toDomain(entityPersist); 
    }
    public async Task<UserDomain> RegisterUser(CreateAccountUserRequestDto dto){
        UserDomain entityDomain=UserDomain.CreateNewUser(
            FullNameVo.CreateFullNameValid(dto.firstName,dto.lastName),
            EmailVo.CreateEmailValid(_validatorPort,dto.email),
            PasswordLoginVo.CreatePasswordLoginValdid(dto.passwordLogin));

        UserPersist entityPersist= _userMapper.ToPersist(entityDomain);

        return _userMapper.toDomain(await _userRepository.RegisterUser(entityPersist));   
    }
    public async Task<UserDomain> UpdateUser(UpdateAccountUserRequestDto dto, UserDomain actEntity){
        UserPersist entityUpdated=await _userRepository.UpdateUser(_userMapper.ToPersist(actEntity),dto);

        UserDomain entityUpdateDomain=UserDomain.ReceivedEntityFromDatabase(
            entityUpdated.Id,
            FullNameVo.ReceivedFullNameFromPersist(entityUpdated.FullName),
            EmailVo.ReceivedEmailFromPersist(entityUpdated.Email),
            RoleVo.ReceivedRoleFromPersist(entityUpdated.Role),
            PasswordLoginVo.ReceivedPasswordLoginFromPersist(entityUpdated.PasswordLogin));

        return entityUpdateDomain;    
    }
    public async Task UpdateUserAdmin(UpdateAccountUserAdminRequestDto dto, UserDomain actEntity){
        await _userRepository.UpdateUserAdmin(_userMapper.ToPersist(actEntity),dto);
    }
}   