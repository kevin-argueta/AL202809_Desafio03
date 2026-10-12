using AL208209_Desafio3.Entities.Dtos;
namespace AL208209_Desafio3.BL.Interfaces
{
    public interface IClienteService
    {
        public Task<List<ClienteDto>> GetClientesAsync();
        public Task<ClienteDto?> GetClienteByIdAsync(int id);
        public Task<int> InsertClienteAsync(ClienteDto clienteDto);
        public Task<ClienteDto?> UpdateClienteAsync(ClienteDto clienteDto);
        public Task<bool> DeleteClienteAsync(int id);
    }
}
