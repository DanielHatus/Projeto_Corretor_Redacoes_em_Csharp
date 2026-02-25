public interface IRegisterPasswordRecoveryUseCase{
    Task<PasswordRecoveryDomain> Execute(PasswordRecoveryDomain entity);
}