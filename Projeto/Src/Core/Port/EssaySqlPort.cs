using Src.Core.Domain.Model;

public interface EssaySqlPort{
    Task RegisterEssay(RegisterEssayRequestDto dto,UserDomain entityCreatorEssay);
}