using Src.Domain.Exceptions;

namespace Src.Core.Domain.ValueObjects;
public class RoleVo{
    public string Value{get;}
    private static List<string> ROLES_VALID=["USER","ADMIN"];

     private RoleVo(string role){
        this.Value=role;
    }
    public static  RoleVo CreateRoleValid(string role){
       return new RoleVo(ValidateRole(role)); 
    }

    public static RoleVo ReceivedRoleFromPersist(string role){
         return new RoleVo(role);
    } 
    private static string ValidateRole(string role){
        if (!ROLES_VALID.Contains(role)){
            throw new DomainException("A role  do usuário não pode ser diferente de USER ou ADMIN.",500);
        }
        return role;
    }
}