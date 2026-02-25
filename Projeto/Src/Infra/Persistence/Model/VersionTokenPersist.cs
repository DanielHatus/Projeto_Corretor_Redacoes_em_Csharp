using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Src.Infra.Persistence.Model;

public class VersionTokenPersist{
    [Key]
    public long? Id{get;set;}
    public long TokenVersion{get;set;}

    [ForeignKey("User")]
    public long idUser{get;set;}
    public UserPersist? User{get;set;}   
}