using System.Text;
public class GenerateTokenFromRecoveryPassword{
    public string Execute(){
        Random random=new Random();
        StringBuilder strBuilder=new StringBuilder();
        for(int i = 0; i < 10; i++){
            strBuilder.Append(random.Next(0,10).ToString());
        }
        return strBuilder.ToString();
    }
}