using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.DAL.Interfaces;
using AL208209_Desafio3.Entities.Dtos;
using AL208209_Desafio3.Entities.Models;
using AutoMapper;

namespace AL208209_Desafio3.BL.Services
{
    public class PedidoService(
        IPedidoRepository repository,
        IMapper mapper) : IPedidoService
    {
        public async Task<List<PedidoDto>> GetPedidosAsync()
        {
            try
            {
                var result = await repository.GetPedidosAsync();
                return mapper.Map<List<Pedido>, List<PedidoDto>>(result);
            }
            catch (Exception e)
            {
                return new List<PedidoDto>();
            }
        }
        public async Task<PedidoDto?> GetPedidoByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetPedidoByIdAsync(id);
                if (result == null)
                    return null;
                return mapper.Map<Pedido, PedidoDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> InserPedidoAsync(PedidoDto pedidoDto)
        {
            try
            {
                var entity = mapper.Map<PedidoDto, Pedido>(pedidoDto);
                return await repository.InsertPedidoAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<PedidoDto?> UpdatePedidoAsync(PedidoDto pedidoDto)
        {
            try
            {
                var entity = mapper.Map<PedidoDto, Pedido>(pedidoDto);
                var result = await repository.UpdatePedidoAsync(entity);
                if (result == null)
                    return null;
                return mapper.Map<Pedido, PedidoDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> DeletePedidoAsync(int id)
        {
            try
            {
                return await repository.DeletePedidoAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
