using Inventory.Domain.Interfaces;

namespace Inventory.Application.Interfaces
{
    public interface IBaseService<TEntity, TEntityId>
        : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IReadable<TEntity, TEntityId>
    {
    }
}
