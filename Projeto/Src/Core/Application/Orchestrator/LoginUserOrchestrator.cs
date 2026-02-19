namespace Src.Core.Application.Orchestrator;
using Src.Core.Domain.Model;
public class LoginUserOrchestrator{
    private readonly ILoginUserUseCase _loginUser;
    private readonly IGetVersionTokenByIdUseCase _getVersionTokenById;
    private readonly IGenerateAccessTokenUseCase _generateAccessToken;
    private readonly IGenerateRefreshTokenUseCase _generateRefreshToken;

    public LoginUserOrchestrator(
        ILoginUserUseCase loginUser,
        IGetVersionTokenByIdUseCase getVersionTokenById,
        IGenerateAccessTokenUseCase generateAccessToken,
        IGenerateRefreshTokenUseCase generateRefreshToken){
        
        this._loginUser=loginUser;
        this._getVersionTokenById=getVersionTokenById;
        this._generateAccessToken=generateAccessToken;
        this._generateRefreshToken=generateRefreshToken;
    }   
    public async Task<JwtTokenResponseDto> Execute(LoginUserDto dto){
        
        UserDomain user=await _loginUser.Execute(dto);
        
        VersionTokenDomain versionToken=await _getVersionTokenById.Execute(user.Id!);

        string accessTokenGenerated=_generateAccessToken.Execute(
            user.FullName.Value,
            user.Id,
            versionToken.VersionToken);

        string refreshTokenGenerated=_generateRefreshToken.Execute(
            user.FullName.Value,
            user.Id,
            versionToken.VersionToken);

            return new JwtTokenResponseDto(accessTokenGenerated,refreshTokenGenerated);
    }    
}