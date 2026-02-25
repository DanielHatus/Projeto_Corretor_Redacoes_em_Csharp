using Src.Core.Domain.ValueObjects;

namespace Src.Core.Domain.Model;
public class UserDomain{
    public long? Id{get;}
    public FullNameVo FullName{get;}
    public EmailVo Email{get;}
    public RoleVo Role{get;}
    public PasswordLoginVo PasswordLogin{get;}

    protected UserDomain(){}

    private UserDomain(long? id,FullNameVo fullName,EmailVo email,RoleVo role,PasswordLoginVo passwordLogin){
        this.Id=id;
        this.FullName=fullName;
        this.Email=email;
        this.Role=role;
        this.PasswordLogin=passwordLogin;
    }

    public static  UserDomain CreateNewUser(FullNameVo fullName,EmailVo email,PasswordLoginVo passwordLogin){
        return new UserDomain(null,fullName,email,RoleVo.CreateRoleValid("USER"),passwordLogin);
    }

    public static UserDomain ReceivedEntityFromDatabase(long? id,FullNameVo fullName,EmailVo email,RoleVo role,PasswordLoginVo passwordLogin){
        return new UserDomain(id!,fullName,email,role,passwordLogin);
    }
}