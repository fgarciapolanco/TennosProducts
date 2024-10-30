using TennosProducts.Core.Dto;
using TennosProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennosProducts.Core.Interfaces
{
    public interface IProductoRepository<T> where T : class
    {

        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int ProductoID);
    }
}
