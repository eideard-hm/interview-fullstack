namespace Inventory.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        void Edit(TEntity entity);
    }
}
