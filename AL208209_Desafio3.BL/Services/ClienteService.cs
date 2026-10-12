using AutoMapper;
using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.DAL.Interfaces;
using AL208209_Desafio3.Entities.Dtos;
using AL208209_Desafio3.Entities.Models;

namespace AL208209_Desafio3.BL.Services
{
    public class ClienteService(
        IClienteRepository repository,
        IMapper mapper) : IClienteService
    {
        public async Task<List<ClienteDto>> GetClientesAsync()
        {
            try
            {
                var result = await repository.GetClientesAsync();
                return mapper.Map<List<Cliente>, List<ClienteDto>>(result);
            }
            catch (Exception e)
            {
                return new List<ClienteDto>();
            }
        }
        public async Task<ClienteDto?> GetClienteByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetClienteByIdAsync(id);
                if (result == null)
                    return null;
                return mapper.Map<Cliente, ClienteDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> InsertClienteAsync(ClienteDto clienteDto)
        {
            try
            {
                var entity = mapper.Map<ClienteDto, Cliente>(clienteDto);
                return await repository.InsertClienteAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<ClienteDto?> UpdateClienteAsync(ClienteDto clienteDto)
        {
            try
            {
                var entity = mapper.Map<ClienteDto, Cliente>(clienteDto);
                var result = await repository.UpdateClienteAsync(entity);
                if (result == null)
                    return null;
                return mapper.Map<Cliente, ClienteDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> DeleteClienteAsync(int id)
        {
            try
            {
                return await repository.DeleteClienteAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
