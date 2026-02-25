public interface ISendEmailUseCase{
    Task Execute(string to,string subject,string body);
}