namespace Src.Core.Application.Orchestrator;
using Src.Core.Domain.Model;

public class CreateAccountOrchestrator{
    private readonly TransactionPort _transactionPort;
    private readonly IRegisterUserUseCase _registerUser;
    private readonly IRegisterVersionTokenUseCase _registerVersionToken;
    private readonly IGenerateAccessTokenUseCase _generateAccessToken;
    private readonly IGenerateRefreshTokenUseCase _generateRefreshToken;

    public CreateAccountOrchestrator(
        TransactionPort transactionPort,
        IRegisterUserUseCase registerUser,
        IRegisterVersionTokenUseCase registerVersionToken,
        IGenerateAccessTokenUseCase generateAccessToken,
        IGenerateRefreshTokenUseCase generateRefreshToken){
        
        this._transactionPort=transactionPort;
        this._registerUser=registerUser;
        this._registerVersionToken=registerVersionToken;
        this._generateAccessToken=generateAccessToken;
        this._generateRefreshToken=generateRefreshToken;
    }
    public async Task<JwtTokenResponseDto> Execute(CreateAccountUserRequestDto dto){
      
      await _transactionPort.InitTransaction();
      try{
            UserDomain userSaved=await _registerUser.Execute(dto);

            VersionTokenDomain versionTokenSaved=await _registerVersionToken.Execute(userSaved.Id!);

            await _transactionPort.CommitTransaction();

            string accessTokenGenerated=_generateAccessToken.Execute(userSaved.FullName.Value,
            userSaved.Id!,
            versionTokenSaved.VersionToken);

            string refreshTokenGenerated=_generateRefreshToken.Execute(userSaved.FullName.Value,
            userSaved.Id!,
            versionTokenSaved.VersionToken);

             return new JwtTokenResponseDto(accessTokenGenerated,refreshTokenGenerated); 
        
        }catch{
            await _transactionPort.RollbackTransaction();
            throw;
        }
    }
}