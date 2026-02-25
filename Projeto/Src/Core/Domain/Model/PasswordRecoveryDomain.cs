public class PasswordRecoveryDomain{
    public long? Id{get;}
    public string Token{get;}
    public bool IsValid{get;}
    public DateTime TimeExpiration;
    private PasswordRecoveryDomain(long? id,string token,bool  isValid,DateTime timeExpiration){
        this.Id=id;
        this.Token=token;
        this.IsValid=isValid;
        this.TimeExpiration=timeExpiration;
    }
    public static  PasswordRecoveryDomain CreatePasswordRecovery(string tokenGenerated){
      return new PasswordRecoveryDomain(null,tokenGenerated,true,DateTime.Now.AddMinutes(7));  
    }
    public static PasswordRecoveryDomain ReceivedRecoveryDomain(long id,string token,bool isValid,DateTime timeExpiration){
        return new PasswordRecoveryDomain(id,token,isValid,timeExpiration);
    }
}