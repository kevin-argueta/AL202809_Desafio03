using AutoMapper;
using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.DAL.Interfaces;
using AL208209_Desafio3.Entities.Dtos;
using AL208209_Desafio3.Entities.Models;

namespace AL208209_Desafio3.BL.Services
{
    public class ProductoService(
        IProductoRepository repository,
        IMapper mapper) : IProductoService
    {
        public async Task<List<ProductoDto>> GetProductosAsync()
        {
            try
            {
                var result = await repository.GetProductosAsync();
                return mapper.Map<List<Producto>, List<ProductoDto>>(result);
            }
            catch (Exception e)
            {
                return new List<ProductoDto>();
            }
        }
        public async Task<ProductoDto?> GetProductoByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetProductoByIdAsync(id);
                if (result == null)
                    return null;
                return mapper.Map<Producto, ProductoDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> InsertProductoAsync(ProductoDto productoDto)
        {
            try
            {
                var entity = mapper.Map<ProductoDto, Producto>(productoDto);
                return await repository.InsertProductoAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<ProductoDto?> UpdateProductoAsync(ProductoDto productoDto)
        {
            try
            {
                var entity = mapper.Map<ProductoDto, Producto>(productoDto);
                var result = await repository.UpdateProductoAsync(entity);
                if (result == null)
                    return null;
                return mapper.Map<Producto, ProductoDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> DeleteProductoAsync(int id)
        {
            try
            {
                return await repository.DeleteProductoAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
