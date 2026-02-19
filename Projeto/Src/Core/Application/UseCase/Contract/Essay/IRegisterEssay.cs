using Src.Core.Domain.Model;

public interface IRegisterEssay{
   Task Execute(RegisterEssayRequestDto dto,UserDomain entityCreatorEssay); 
}