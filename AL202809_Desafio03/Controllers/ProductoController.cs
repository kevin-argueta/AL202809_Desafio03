using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.BL.Services;
using AL208209_Desafio3.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AL208209_Desafio3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductoById(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertProducto([FromBody] ProductoDto productoDto)
        {
            var nuevoId = await _productoService.InsertProductoAsync(productoDto);
            if (nuevoId <= 0)
            {
                return BadRequest(new { mensaje = "No se pudo crear el producto." });
            }
            return Ok(new { id = nuevoId, mensaje = "Producto creado exitosamente." });
        }

        [HttpPut]
        public async Task<ActionResult<ProductoDto>> UpdateProducto([FromBody] ProductoDto productoDto)
        {
            var actualizado = await _productoService.UpdateProductoAsync(productoDto);
            if (actualizado == null)
            {
                return NotFound(new { mensaje = "No se pudo actualizar el producto." });
            }
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProducto(int id)
        {
            var eliminado = await _productoService.DeleteProductoAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "No se encontró el producto a eliminar." });
            }
            return Ok(new { mensaje = "Producto eliminado correctamente." });
        }
    }
}