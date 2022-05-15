using Inventory.Domain.Interfaces;

namespace Inventory.Application.Interfaces
{
    public interface IInvoiceDetailService<TEntity, TEntityId>
        : IAdd<TEntity>, IReadable<TEntity, TEntityId>
    {
    }
}
