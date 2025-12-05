using System.Threading.Tasks;

namespace Tfg_hotelGestor.Contracts
{
    public interface IGenericCRUD<T, Tkey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Tkey id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(Tkey id, T entity);
        Task<bool> DeleteAsync(Tkey id);

    }
}
