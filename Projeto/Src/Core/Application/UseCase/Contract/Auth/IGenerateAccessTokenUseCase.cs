public interface IGenerateAccessTokenUseCase{
    string Execute(string fullName,long? idUser,long VersionToken);
}