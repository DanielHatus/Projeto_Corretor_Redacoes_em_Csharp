public interface PasswordRecoverySqlPort{
    Task RegisterPasswordRecovery(PasswordRecoveryDomain entity);
    Task<PasswordRecoveryDomain> GetPassswordRecoveryById(long id);
}