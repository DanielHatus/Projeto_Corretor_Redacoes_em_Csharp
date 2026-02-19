using Src.Core.Domain.ValueObjects;

namespace Src.Core.Domain.Model;
public class EssayDomain{
    public long? Id{get;}
    public UserDomain RefUser{get;}
    public EssayVo Essay{get;}


    private EssayDomain(long? id,UserDomain refUser,EssayVo essay){
        this.Id=id;
        this.RefUser=refUser;
        this.Essay=essay;
    }


    public static EssayDomain CreateEssayDomainValid(UserDomain entity,EssayVo essay){
        return new EssayDomain(null,entity,essay);
    }

    public static EssayDomain ReceivedEssayDomainFromDatabase(long id,UserDomain entity,EssayVo essay){
        return new EssayDomain(id,entity,essay);
    }

}