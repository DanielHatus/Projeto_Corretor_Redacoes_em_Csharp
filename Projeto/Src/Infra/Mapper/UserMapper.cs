using Src.Core.Domain.Model;
using Src.Core.Domain.ValueObjects;
using Src.Infra.Persistence.Model;

public class UserMapper{
    public UserDomain toDomain(UserPersist entityPersist){
       return UserDomain.ReceivedEntityFromDatabase(
        entityPersist.Id,
        FullNameVo.ReceivedFullNameFromPersist(entityPersist.FullName),
        EmailVo.ReceivedEmailFromPersist(entityPersist.Email),
        RoleVo.ReceivedRoleFromPersist(entityPersist.Role),
        PasswordLoginVo.ReceivedPasswordLoginFromPersist(entityPersist.PasswordLogin)
       ); 
    }

    public UserPersist ToPersist(UserDomain entity){
        UserPersist persist=new UserPersist();
        persist.FullName=entity.FullName.Value;
        persist.Email=entity.Email.Value;
        persist.Id=null;
        persist.PasswordLogin=entity.PasswordLogin.Value;
        persist.Role=entity.Role.Value;
        return persist;
    }
    
}