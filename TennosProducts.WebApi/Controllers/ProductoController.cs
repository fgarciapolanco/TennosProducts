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
        public readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("/TodosLosProductos")]
        public async Task<ActionResult<List<Productos>>> GetProductos()
        {
            var buscarTodos = await _productoRepository.GetProductoAsync();
            return Ok(buscarTodos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductosId(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);

        }

        [HttpPost("/AgregarProducto")]
        public async Task<Productos> InsertProducto(ProductoDto productoDto)
        {
            return await _productoRepository.InsertProducto(productoDto);

        }
        [HttpPut("/AgregarProducto/{id}")]
        public async Task<Productos> ActualizarProducto(ProductoDto productoDto)
        {
            return await _productoRepository.InsertProducto(productoDto);
          
        }
        [HttpDelete("/BorrarProducto")]
        public IActionResult DeleteById(int ProductoID)
        {
            var result = _productoRepository.DeleteById(ProductoID);
            
            return StatusCode(StatusCodes.Status400BadRequest);
        }

       

    }
}
