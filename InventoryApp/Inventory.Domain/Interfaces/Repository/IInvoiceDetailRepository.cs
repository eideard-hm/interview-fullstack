namespace Inventory.Domain.Interfaces.Repository
{
    public interface IInvoiceDetailRepository<TEntity, TEntityId>
        : IAdd<TEntity>, IReadable<TEntity, TEntityId>, ITransacction
    {
    }
}
