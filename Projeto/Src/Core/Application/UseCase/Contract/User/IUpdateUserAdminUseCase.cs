using Src.Core.Domain.Model;

public interface IUpdateUserAdminUseCase{
    
    Task Execute(UpdateAccountUserAdminRequestDto dto,UserDomain actEntity);
}