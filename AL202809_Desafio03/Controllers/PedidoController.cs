using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.BL.Services;
using AL208209_Desafio3.Entities.Dtos;
using AL208209_Desafio3.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AL208209_Desafio3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDto>>> GetPedidos()
        {
            var pedidos = await _pedidoService.GetPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> GetPedidoById(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound(new { mensaje = "Pedido no encontrado." });
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertPedido([FromBody] PedidoDto pedidoDto)
        {
            var nuevoId = await _pedidoService.InserPedidoAsync(pedidoDto);
            if (nuevoId <= 0)
            {
                return BadRequest(new { mensaje = "No se pudo crear el pedido." });
            }
            return Ok(new { id = nuevoId, mensaje = "Pedido creado exitosamente." });
        }

        [HttpPut]
        public async Task<ActionResult<PedidoDto>> UpdatePedido([FromBody] PedidoDto pedidoDto)
        {
            var actualizado = await _pedidoService.UpdatePedidoAsync(pedidoDto);
            if (actualizado == null)
            {
                return NotFound(new { mensaje = "No se pudo actualizar el pedido." });
            }
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePedido(int id)
        {
            var eliminado = await _pedidoService.DeletePedidoAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "No se encontró el pedido a eliminar." });
            }
            return Ok(new { mensaje = "Pedido eliminado correctamente." });
        }
    }
}