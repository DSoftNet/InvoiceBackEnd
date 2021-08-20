namespace Invoice.Domain.SeedWork
{
    public interface IRepository<T>
    where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}