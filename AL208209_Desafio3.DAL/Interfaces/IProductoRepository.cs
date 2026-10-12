using System;
using System.Collections.Generic;
using System.Text;
using AL208209_Desafio3.Entities.Models;

namespace AL208209_Desafio3.DAL.Interfaces
{
    public interface IProductoRepository
    {
        public Task<List<Producto>> GetProductosAsync();
        public Task<Producto?> GetProductoByIdAsync(int id);
        public Task<int> InsertProductoAsync(Producto producto);
        public Task<Producto?> UpdateProductoAsync(Producto producto);
        public Task<bool> DeleteProductoAsync(int id);
    }
}
