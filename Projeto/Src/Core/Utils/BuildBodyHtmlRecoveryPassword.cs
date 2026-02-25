public class BuildBodyHtmlRecoveryPassword{
    
public string Execute(string fullName, string Token){
    return $@"
<html>
  <body>
      <div style=""width:93%;height:210px;border:1px solid yellow; background-color:black; margin:auto;border-radius:10px;"">
        <h1 style=""text-align:center;color:yellow; text-shadow:1px 1px 1px white;"">Token Recovery Password</h1>
         <p style=""color:yellow;"">Olá <strong> {fullName} </strong>, Aqui Está o Token para Resetar A Sua Senha: Caso Você Não Tenha Tentado o Reset, Apenas Ignore.</p> 
          <p style=""color:yellow; font-size:25px; text-align:center;"">{Token}</p>
      </div>
  </body>
</html>";
    }
}
