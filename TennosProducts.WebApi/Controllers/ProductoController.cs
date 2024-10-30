using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennosProducts.BusinessLogic.Logic;
using TennosProducts.Core.Dto;
using TennosProducts.Core.Entities;
using TennosProducts.Core.Interfaces;

namespace TennosProducts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly IProductoRepository<Productos> _productoRepository;

        public ProductoController(IProductoRepository<Productos> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("/TodosLosProductos")]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoRepository.GetAllAsync();
            return Ok(productos);
        }


        [HttpGet("/BuscarProductoPorID")]
        public async Task<IActionResult> GetById(int ProductoID)
        {

            var producto = await _productoRepository.GetByIdAsync(ProductoID);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }


        [HttpPost("/AgregarProducto")]
        public async Task<IActionResult> Post(ProductoDto productosDto)
        {
            var productoEntidad = new Productos()
            {
                Precio = productosDto.Precio,
                Nombre = productosDto.Nombre,
                FechaCreacion = DateTime.Now
            };

            var createProResponse = await _productoRepository.CreateAsync(productoEntidad);
            return CreatedAtAction(nameof(GetById), new { id = createProResponse.ProductoID }, createProResponse);

        }

        [HttpPost("/AtualizarProducto")]
        public async Task<IActionResult> Put(int id, ProductoDto productosDto)
        {
            var productoActualizar = await _productoRepository.GetByIdAsync(id);
            if (productoActualizar == null)
            {
                return NotFound();
            }
            productoActualizar.Nombre = productosDto.Nombre;
            productoActualizar.Precio = productosDto.Precio;
            productoActualizar.FechaCreacion = productosDto.FechaCreacion;

            await _productoRepository.UpdateAsync(productoActualizar);
            return NoContent();
        }

        [HttpDelete("/BorrarProducto/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var buscarIdBorrar = await _productoRepository.GetByIdAsync(id);
            if (buscarIdBorrar == null)
            {
                return NotFound("Id Producto no encontrado");
            }


            await _productoRepository.DeleteAsync(buscarIdBorrar);
            return NoContent();
        }

    }
}
