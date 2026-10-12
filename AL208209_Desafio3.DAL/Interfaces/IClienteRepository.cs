using System;
using System.Collections.Generic;
using System.Text;
using AL208209_Desafio3.Entities.Models;

namespace AL208209_Desafio3.DAL.Interfaces
{
    public interface IClienteRepository
    {
        public Task<List<Cliente>> GetClientesAsync();
        public Task<Cliente?> GetClienteByIdAsync(int id);
        public Task<int> InsertClienteAsync(Cliente cliente);
        public Task<Cliente?> UpdateClienteAsync(Cliente cliente);
        public Task<bool> DeleteClienteAsync(int id);
    }
}
