using Src.Core.Domain.Model;

public class RecoveryPasswordOrchestrator{
   private readonly TransactionPort _transactionPort;
   private readonly ISendEmailUseCase _sendEmail;
   private readonly BuildBodyHtmlRecoveryPassword _buildHtml;
   private readonly GenerateTokenFromRecoveryPassword _generateTokenRecovery;
   private readonly IGetUserByEmailUseCase _getUserByEmail; 
   private  readonly IRegisterPasswordRecoveryUseCase _registerPasswordRecovery;

   public RecoveryPasswordOrchestrator(
    TransactionPort transactionPort,
    ISendEmailUseCase sendEmail,
    BuildBodyHtmlRecoveryPassword buildHtml,
    GenerateTokenFromRecoveryPassword generateTokenRecovery,
    IGetUserByEmailUseCase getUserByEmail,
    IRegisterPasswordRecoveryUseCase registerPasswordRecovery){
        
    this._transactionPort=transactionPort;
    this._sendEmail=sendEmail;
    this._buildHtml=buildHtml;
    this._generateTokenRecovery=generateTokenRecovery;
    this._getUserByEmail=getUserByEmail;
    this._registerPasswordRecovery=registerPasswordRecovery;    
    }
    public  async Task<string> Execute(RecoveryPasswordDto dto){

     await _transactionPort.InitTransaction();
     try{
            UserDomain user=await _getUserByEmail.Execute(dto.email);

            string tokenGenerated=_generateTokenRecovery.Execute();

            PasswordRecoveryDomain recoveryDomain=PasswordRecoveryDomain.CreatePasswordRecovery(tokenGenerated);

            string body=_buildHtml.Execute(user.FullName.Value,tokenGenerated);

            await _registerPasswordRecovery.Execute(recoveryDomain);

            await _transactionPort.CommitTransaction();

            await _sendEmail.Execute(user.Email.Value,"Reset da senha do usuário",body);

            return "Caso o usuário esteja cadastrado,um email será enviado  para o reset da senha do usuário";
        
        }catch{
         await _transactionPort.RollbackTransaction();
         throw;   
        }
    }
}