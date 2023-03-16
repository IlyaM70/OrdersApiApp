using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service
{
    public interface IDao<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T t);
        Task<T> UpdateAsync(T t);
        Task<T> DeleteAsync(int id);
        Task<T> GetAsync(int id);
    }
}
