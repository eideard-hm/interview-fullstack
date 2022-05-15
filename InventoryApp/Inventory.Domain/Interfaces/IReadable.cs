namespace Inventory.Domain.Interfaces
{
    public interface IReadable<TEntity, TEntityId>
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
