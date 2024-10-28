using TennosProducts.Core.Dto;
using TennosProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennosProducts.BusinessLogic.Data;
using TennosProducts.Core.Interfaces;

namespace TennosProducts.BusinessLogic.Logic
{

    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductoDbContext _context;
        public ProductoRepository(ProductoDbContext context)
        {
            _context = context;
        }

        public async Task<Productos> GetProductoByIdAsync(int id)
        {
            var buscarProductoId = await _context.productos.FindAsync(id); 

            return buscarProductoId;
        }

        public async Task<IReadOnlyList<Productos>> GetProductoAsync()
        {
            var buscarTodosProductos =  _context.productos.ToList();
            return buscarTodosProductos;
        }

        public Task<Productos> InsertProducto(ProductoDto producto)
        {


            //var productos = new Productos
            //{
            //    Nombre = producto.Nombre,
            //    Precio = producto.Precio,
            //    FechaCreacion = DateTime.Now
            //};

            //_context.SaveChanges();
            ////return productos;
            throw new NotImplementedException();
        }

        public void DeleteById(int ProductoID)
        {
            _context.Remove(ProductoID);
            _context.SaveChanges();
        }
    }
}
