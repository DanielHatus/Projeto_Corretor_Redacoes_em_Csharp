public interface IGenerateRefreshTokenUseCase{
    string Execute(string fullName,long? idUser,long VersionToken);
}