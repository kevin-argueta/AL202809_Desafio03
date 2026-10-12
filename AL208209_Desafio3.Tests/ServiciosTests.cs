using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using AL208209_Desafio3.BL.Services;
using AL208209_Desafio3.DAL.Interfaces;
using AL208209_Desafio3.Entities.Dtos;
using AL208209_Desafio3.Entities.Models;
using AutoMapper;

namespace AL208209_Desafio3.Tests
{
    public class ServiciosTests
    {
        private readonly IMapper _mapperMock;

        public ServiciosTests()
        {
            var mockMapper = new Mock<IMapper>();

            var pedidoDtoSimulado = new PedidoDto
            {
                Codigo = 5,
                Cantidad = 2,
                ClienteId = 1,
                ProductoId = 1,
                FechaPedido = DateTime.Now
            };
            mockMapper.Setup(m => m.Map<Pedido, PedidoDto>(It.IsAny<Pedido>())).Returns(pedidoDtoSimulado);

            _mapperMock = mockMapper.Object;
        }

        // 1. Creación de un cliente
        [Fact]
        public async Task InsertClienteAsync_DeberiaRetornarId_CuandoClienteEsValido()
        {
            // Arrange
            var mockRepo = new Mock<IClienteRepository>();
            var clienteDto = new ClienteDto { Nombre = "Juan", Apellido = "Perez" };
            mockRepo.Setup(repo => repo.InsertClienteAsync(It.IsAny<Cliente>())).ReturnsAsync(1);
            var service = new ClienteService(mockRepo.Object, _mapperMock);

            // Act
            var result = await service.InsertClienteAsync(clienteDto);

            // Assert
            Assert.Equal(1, result);
        }

        // 2. Validación de datos incorrectos de un cliente
        [Fact]
        public async Task InsertClienteAsync_DeberiaLanzarExcepcion_CuandoNombreEsNulo()
        {
            // Arrange
            var mockRepo = new Mock<IClienteRepository>();
            var service = new ClienteService(mockRepo.Object, _mapperMock);
            var clienteInvalido = new ClienteDto { Nombre = "", Apellido = "Perez", Email="prueba@prueba.com"};

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.InsertClienteAsync(clienteInvalido));
        }

        // 3. Creación de un producto
        [Fact]
        public async Task InsertProductoAsync_DeberiaRetornarExito_CuandoDatosSonValidos()
        {
            // Arrange
            var mockRepo = new Mock<IProductoRepository>();
            var productoDto = new ProductoDto { Nombre = "Teclado", Descripcion = "Mecanico", Precio = 25.50, stock = 100 };
            mockRepo.Setup(repo => repo.InsertProductoAsync(It.IsAny<Producto>())).ReturnsAsync(1);
            var service = new ProductoService(mockRepo.Object, _mapperMock);

            // Act
            var result = await service.InsertProductoAsync(productoDto);

            // Assert
            Assert.True(result > 0);
        }

        // 4. Validación del precio y stock
        [Fact]
        public async Task InsertProductoAsync_DeberiaLanzarExcepcion_CuandoPrecioEsNegativo()
        {
            // Arrange
            var mockRepo = new Mock<IProductoRepository>();
            var service = new ProductoService(mockRepo.Object, _mapperMock);
            var productoInvalido = new ProductoDto { Nombre = "Mouse", Descripcion = "Optico", Precio = -10, stock = -5 };

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.InsertProductoAsync(productoInvalido));

            // Assert
            Assert.Contains("precio", exception.Message.ToLower());
        }

        // 5. Creación de un pedido
        [Fact]
        public async Task InsertPedidoAsync_DeberiaRetornarId_CuandoDatosValidos()
        {
            // Arrange
            var mockPedidoRepo = new Mock<IPedidoRepository>();
            mockPedidoRepo.Setup(r => r.InsertPedidoAsync(It.IsAny<Pedido>())).ReturnsAsync(5);

            // Se envía únicamente el mockPedidoRepo y el mapper para coincidir con tu constructor
            var service = new PedidoService(mockPedidoRepo.Object, _mapperMock);
            var pedidoDto = new PedidoDto { ClienteId = 1, ProductoId = 1, Cantidad = 2, FechaPedido = DateTime.Now };

            // Act
            var result = await service.InserPedidoAsync(pedidoDto);

            // Assert
            Assert.Equal(5, result);
        }

        // 6. Consulta de un pedido existente
        [Fact]
        public async Task GetPedidoByIdAsync_DeberiaRetornarPedidoDto_CuandoExiste()
        {
            // Arrange
            var mockPedidoRepo = new Mock<IPedidoRepository>();
            var pedidoDb = new Pedido { Id = 5, Cantidad = 2, ClienteId = 1, ProductoId = 1, FechaPedido = DateTime.Now };
            mockPedidoRepo.Setup(r => r.GetPedidoByIdAsync(5)).ReturnsAsync(pedidoDb);

            var service = new PedidoService(mockPedidoRepo.Object, _mapperMock);

            // Act
            var result = await service.GetPedidoByIdAsync(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Codigo);
        }

        // 7. Intento de consultar un registro inexistente
        [Fact]
        public async Task GetPedidoByIdAsync_DeberiaRetornarNull_CuandoNoExiste()
        {
            // Arrange
            var mockPedidoRepo = new Mock<IPedidoRepository>();
            mockPedidoRepo.Setup(r => r.GetPedidoByIdAsync(999)).ReturnsAsync((Pedido?)null);
            var service = new PedidoService(mockPedidoRepo.Object, _mapperMock);

            // Act
            var result = await service.GetPedidoByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        // 8. Validación de alguna regla de negocio (No vender sin stock)
        [Fact]
        public async Task InsertPedidoAsync_DeberiaLanzarExcepcion_CuandoCantidadSuperaStock()
        {
            // Arrange
            var mockPedidoRepo = new Mock<IPedidoRepository>();
            var pedidoDto = new PedidoDto { ClienteId = 1, ProductoId = 1, Cantidad = 50, FechaPedido = DateTime.Now };
            var service = new PedidoService(mockPedidoRepo.Object, _mapperMock);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => service.InserPedidoAsync(pedidoDto));
            Assert.Contains("stock", exception.Message.ToLower());
        }
    }
}