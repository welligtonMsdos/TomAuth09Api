namespace TomAuthApi.src.Domain.Interfaces;

public interface ICommand<T>
{
    Task<T> Post(T obj);
    Task<bool> DeleteById(string id);
    Task<T> Put(string id, T obj);
}
