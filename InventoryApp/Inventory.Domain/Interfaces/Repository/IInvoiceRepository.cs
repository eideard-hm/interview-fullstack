namespace Inventory.Domain.Interfaces.Repository
{
    public interface IInvoiceRepository<TEntity, TEntityId>
        : IAdd<TEntity>, IReadable<TEntity, TEntityId>, ITransacction
    {
        void Anular(TEntityId id);
    }
}
