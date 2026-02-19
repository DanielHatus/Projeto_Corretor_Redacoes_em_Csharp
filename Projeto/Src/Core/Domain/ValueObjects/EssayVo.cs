using Src.Domain.Exceptions;

namespace Src.Core.Domain.ValueObjects;
public class EssayVo{
    
    public string Value{get;}

    private EssayVo(string essay){
        this.Value=essay;
    }

    public static EssayVo CreateEssayValid(string essay){
        return new EssayVo(ValidateEssay(essay));
    }
    public static string ValidateEssay(string essay){
        if (string.IsNullOrWhiteSpace(essay)){
            throw new DomainException("a redação não pode ser nula ou vazia.",400);
        }
        
        if (essay.Length > 3000){
            throw new DomainException("a redação não deve ter mais de 3000 caracteres(equivalente a 30 linhas de uma folha)",400);
        }

        return essay;
    }
    public static EssayVo ReceivedEssayFromDatabase(string essay){
        return new EssayVo(essay);
    }
}