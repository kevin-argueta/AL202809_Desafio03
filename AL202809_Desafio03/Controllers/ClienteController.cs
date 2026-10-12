using Microsoft.AspNetCore.Mvc;
using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.Entities.Dtos;

namespace AL208209_Desafio3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado." });
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertCliente([FromBody] ClienteDto clienteDto)
        {
            var nuevoId = await _clienteService.InsertClienteAsync(clienteDto);
            if (nuevoId <= 0)
            {
                return BadRequest(new { mensaje = "No se pudo crear el cliente." });
            }
            return Ok(new { id = nuevoId, mensaje = "Cliente creado exitosamente." });
        }

        [HttpPut]
        public async Task<ActionResult<ClienteDto>> UpdateCliente([FromBody] ClienteDto clienteDto)
        {
            var actualizado = await _clienteService.UpdateClienteAsync(clienteDto);
            if (actualizado == null)
            {
                return NotFound(new { mensaje = "No se pudo actualizar el cliente." });
            }
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCliente(int id)
        {
            var eliminado = await _clienteService.DeleteClienteAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "No se encontró el cliente a eliminar." });
            }
            return Ok(new { mensaje = "Cliente eliminado correctamente." });
        }
    }
}