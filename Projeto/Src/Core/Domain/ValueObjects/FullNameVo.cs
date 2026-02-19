namespace Src.Core.Domain.ValueObjects;
using System.Text;
using Src.Domain.Exceptions;

public class FullNameVo{
    public string Value{get;}
    private FullNameVo(string fullName){
        this.Value=fullName;
    }
    public static FullNameVo CreateFullNameValid(string firstName,string lastName){
        string firstNameValid=ValidateName(firstName);
        string lastNameValid=ValidateName(lastName);
        return new FullNameVo(BuildFullName(firstNameValid,lastNameValid));
    }
    public static FullNameVo ReceivedFullNameFromDatabase(string fullName){
        return new FullNameVo(fullName);
    }
    private static string ValidateName(string name){
        if(string.IsNullOrWhiteSpace(name)){throw new DomainException("o nome do usuário não pode ser nulo,ou vazio.",400);}

        if(name.Length<3 || name.Length>25){throw new DomainException("o número atual de caracteres do nome é invalido. ele deve ter ao menos 3 caracteres e no máximo 25.",400);}

        return name;
    }
    private static string BuildFullName(string firstName,string lastName)=>CapitalizeAndConcatenateNames(firstName,lastName);
    private static string CapitalizeAndConcatenateNames(params string[] names){
        StringBuilder strBuilder=new StringBuilder();
        foreach(string name in names){
          string[] nameNotSpaces=name.Split(' ',StringSplitOptions.RemoveEmptyEntries);

          foreach(string nameIndividualNotSpace in nameNotSpaces){
               char firstLetterName=char.ToUpper(nameIndividualNotSpace[0]);
               strBuilder.Append(firstLetterName)
               .Append(nameIndividualNotSpace[1..].ToLower())
               .Append(" "); 
            }
        }
        return strBuilder.ToString().Trim();
    }
 
}