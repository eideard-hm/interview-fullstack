using Inventory.Domain.Interfaces;
namespace Inventory.Application.Interfaces
{
    public interface IInvoiceService<TEntity, TEntityId>
        : IAdd<TEntity>, IReadable<TEntity, TEntityId>
    {
        void Anular(TEntityId id);
    }
}
