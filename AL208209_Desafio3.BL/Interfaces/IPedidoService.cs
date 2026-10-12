using AL208209_Desafio3.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AL208209_Desafio3.BL.Interfaces
{
    public interface IPedidoService
    {
        public Task<List<PedidoDto>> GetPedidosAsync();
        public Task<PedidoDto?> GetPedidoByIdAsync(int id);
        public Task<int> InserPedidoAsync(PedidoDto pedidoDto);
        public Task<PedidoDto?> UpdatePedidoAsync(PedidoDto pedidoDto);
        public Task<bool> DeletePedidoAsync(int id);

    }
}
