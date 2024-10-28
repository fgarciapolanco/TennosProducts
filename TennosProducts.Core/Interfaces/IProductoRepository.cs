using TennosProducts.Core.Dto;
using TennosProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennosProducts.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<Productos> GetProductoByIdAsync(int id);

        Task<IReadOnlyList<Productos>> GetProductoAsync();

        Task<Productos> InsertProducto(ProductoDto producto);

        void DeleteById(int ProductoID);

        //Task<Producto> ActualizarProducto(ProductoDto producto);
    }
}
