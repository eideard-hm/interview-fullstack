namespace Inventory.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity, TEntityId>
        : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IReadable<TEntity, TEntityId>, ITransacction
    {
    }
}
