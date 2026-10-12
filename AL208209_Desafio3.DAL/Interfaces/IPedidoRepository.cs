using System;
using System.Collections.Generic;
using System.Text;
using AL208209_Desafio3.Entities.Models;

namespace AL208209_Desafio3.DAL.Interfaces
{
    public interface IPedidoRepository
    {
        public Task<List<Pedido>> GetPedidosAsync();
        public Task<Pedido?> GetPedidoByIdAsync(int id);
        public Task<int> InsertPedidoAsync(Pedido pedido);
        public Task<Pedido?> UpdatePedidoAsync(Pedido pedido);
        public Task<bool> DeletePedidoAsync(int id);
    }
}
