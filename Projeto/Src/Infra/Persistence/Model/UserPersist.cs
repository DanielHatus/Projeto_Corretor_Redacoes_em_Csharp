namespace Src.Infra.Persistence.Model;
using System.ComponentModel.DataAnnotations;

public class UserPersist{

    [Key]
    public long? Id;
    public string FullName{get;set;}
    public string Role{get;set;}
    public string Email{get;set;}
    public string PasswordLogin{get;set;}
}