using Src.Core.Domain.Model;

public class UpdateAccountAdminOrchestrator{
    private readonly IUpdateUserAdminUseCase _updateUserAdmin; 
    private readonly IUpdateVersionTokenUseCase _updateVersionToken;
    private readonly IGetUserByIdUseCase _getUserById;
    private readonly IGetVersionTokenByIdUseCase _getVersionToken;
    public async Task Execute(long id,UpdateAccountUserAdminRequestDto dto){
      UserDomain actEntity=await _getUserById.Execute(id);

      VersionTokenDomain actVersionToken=await _getVersionToken.Execute(id);

      await Task.WhenAll(_updateUserAdmin.Execute(dto,actEntity),
      _updateVersionToken.Execute(VersionTokenDomain.UpdateVersionToken(actVersionToken)));  
    }
}