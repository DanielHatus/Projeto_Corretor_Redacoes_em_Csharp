public interface TransactionPort{
    Task InitTransaction();
    Task CommitTransaction();
    Task RollbackTransaction();
}