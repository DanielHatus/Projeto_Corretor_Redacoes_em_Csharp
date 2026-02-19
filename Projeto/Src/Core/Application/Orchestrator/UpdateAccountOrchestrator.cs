using Src.Core.Domain.Model;

public class UpdateAccountOrchestrator{
    private readonly TransactionPort _transactionPort;
    private readonly IGetUserByIdUseCase _getUserById;
    private readonly IUpdateUserUseCase _updateUser; 
    private readonly IGetVersionTokenByIdUseCase _getVersionTokenById;
    private readonly IUpdateVersionTokenUseCase _updateVersionToken; 
    private readonly IGenerateAccessTokenUseCase _generateAccessToken;
    private readonly IGenerateRefreshTokenUseCase _generateRefreshToken;
    private readonly PayloadDataPort _payloadData;

    public UpdateAccountOrchestrator(
      TransactionPort transactionPort,
      IGetUserByIdUseCase getUserById,
      IUpdateUserUseCase updateUser,
      IGetVersionTokenByIdUseCase getVersionTokenById,
      IUpdateVersionTokenUseCase updateVersionToken,
      IGenerateAccessTokenUseCase generateAccessToken,
      IGenerateRefreshTokenUseCase generateRefreshToken,
      PayloadDataPort payloadData){

      this._transactionPort=transactionPort;
      this._getUserById=getUserById;
      this._updateUser=updateUser;
      this._getVersionTokenById=getVersionTokenById;
      this._updateVersionToken=updateVersionToken;
      this._generateAccessToken=generateAccessToken;
      this._generateRefreshToken=generateRefreshToken;
      this._payloadData=payloadData;  
    
  }
    public async Task<JwtTokenResponseDto> Execute(UpdateAccountUserRequestDto dto){
       await _transactionPort.InitTransaction();
        try{
          var(userRequest,versionTokenUser)=await GetEntityUserRequestAndVersionToken();

          var (userUpdated,versionTokenUpdated)=await UpdateUserAndVersionToken(dto,userRequest,versionTokenUser);

          await _transactionPort.CommitTransaction();

          string accessToken=_generateAccessToken.Execute(userUpdated.FullName.Value,userUpdated.Id,versionTokenUpdated.VersionToken);

          string refreshToken=_generateRefreshToken.Execute(userUpdated.FullName.Value,userUpdated.Id,versionTokenUpdated.VersionToken);

          return new JwtTokenResponseDto(accessToken,refreshToken);
        }
        catch{
          await _transactionPort.RollbackTransaction();  
          throw;  
        }
    }

    private  async Task<(UserDomain,VersionTokenDomain)> GetEntityUserRequestAndVersionToken(){
     long idUser=_payloadData.GetIdUser();

     var userTask=_getUserById.Execute(idUser);

     var versionTokenTask=_getVersionTokenById.Execute(idUser);

     await Task.WhenAll(userTask,versionTokenTask);

     return(await userTask,await versionTokenTask); 
  }
  private async Task<(UserDomain,VersionTokenDomain)> UpdateUserAndVersionToken(
    UpdateAccountUserRequestDto dto,
    UserDomain actEntityUser,
    VersionTokenDomain dataVersionTokenUpdated){

    
    var updateUser=_updateUser.Execute(dto,actEntityUser);
    var updateVersionToken=_updateVersionToken.Execute(dataVersionTokenUpdated);
    await Task.WhenAll(updateUser,updateVersionToken);
    return(await updateUser,await updateVersionToken);
  } 
}