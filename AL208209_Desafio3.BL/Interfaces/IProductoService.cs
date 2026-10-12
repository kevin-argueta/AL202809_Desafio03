using AL208209_Desafio3.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AL208209_Desafio3.BL.Interfaces
{
    public interface IProductoService
    {
        public Task<List<ProductoDto>> GetProductosAsync();
        public Task<ProductoDto?> GetProductoByIdAsync(int id);
        public Task<int> InsertProductoAsync(ProductoDto productoDto);
        public Task<ProductoDto?> UpdateProductoAsync(ProductoDto productoDto);
        public Task<bool> DeleteProductoAsync(int id);
    }
}
