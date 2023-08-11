namespace Cubes.Domain.Interfaces
{
    public interface ISave<TEntity>
    {
        bool Save(TEntity entity);
    }
}
