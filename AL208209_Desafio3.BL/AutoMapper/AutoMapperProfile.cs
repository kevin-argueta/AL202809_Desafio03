using AutoMapper;
using AL208209_Desafio3.Entities.Dtos;
using AL208209_Desafio3.Entities.Models;

namespace AL208209_Desafio3.BL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(destination => destination.Codigo, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.Nombre, opts => opts.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.Apellido, opts => opts.MapFrom(source => source.Apellido))
                .ForMember(destination => destination.Email, opts => opts.MapFrom(source => source.Email))
                .ReverseMap();
            CreateMap<Producto, ProductoDto>()
                .ForMember(destination => destination.Codigo, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.Nombre, opts => opts.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.Descripcion, opts => opts.MapFrom(source => source.Descripcion))
                .ForMember(destination => destination.Precio, opts => opts.MapFrom(source => source.Precio))
                .ForMember(destination => destination.stock, opts => opts.MapFrom(source => source.Stock))
                .ReverseMap();
            CreateMap<Pedido, PedidoDto>()
                .ForMember(destination => destination.Codigo, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.FechaPedido, opts => opts.MapFrom(source => source.FechaPedido))
                .ForMember(destination => destination.Cantidad, opts => opts.MapFrom(source => source.Cantidad))
                .ForMember(destination => destination.ClienteId, opts => opts.MapFrom(source => source.ClienteId))
                .ForMember(destination => destination.ProductoId, opts => opts.MapFrom(source => source.ProductoId))
                .ReverseMap();
        }
    }
}
