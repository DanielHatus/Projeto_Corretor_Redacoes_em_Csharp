using Src.Domain.Exceptions;

namespace Src.Core.Domain.Model;
public class VersionTokenDomain{
    public long? Id{get;}
    public long VersionToken{get;}
    public long? IdUser{get;}

    private VersionTokenDomain(long? id,long versionToken,long? idUser){
        this.Id=id;
        this.VersionToken=versionToken;
        this.IdUser=idUser;
    }

    public static VersionTokenDomain CreateVersionTokenValid(long? idUser){
        if (idUser == null){
            throw new DomainException(" [ERRO DE CONSISTÊNCIA],o id da entidade que vai ser armazenada no VersionToken não deve ser nula.",500);
        }
        return new VersionTokenDomain(null,1,idUser!);
    }


    public static VersionTokenDomain ReceivedVersionTokenFromDatabase(long id,long versionToken,long? idUser){
        return new VersionTokenDomain(id!,versionToken,idUser!);
    }

    public static VersionTokenDomain UpdateVersionToken(VersionTokenDomain actVersionToken){
        if (actVersionToken.Id == null){
            throw new DomainException("[ERRO DE CONSISTÊNCIA] um token não registrado não pode ter seu versionToken atualizado.",500);
        }

        return new VersionTokenDomain(actVersionToken.Id,actVersionToken.VersionToken+1L,actVersionToken.IdUser);
    }
}