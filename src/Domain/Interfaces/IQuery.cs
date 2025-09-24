namespace TomAuthApi.src.Domain.Interfaces;

public interface IQuery<T>
{
    Task<ICollection<T>> GetAll();
    Task<T> GetById(string id);
}
