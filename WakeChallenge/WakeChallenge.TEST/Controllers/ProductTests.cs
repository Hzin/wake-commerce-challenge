using System.Net.Http.Json;
using WakeChallenge.CORE.Entities;
using WakeChallenge.TEST.Factories;

namespace WakeChallenge.TEST.Controllers
{
    [Collection("Database")]
    public class ProductTests : IClassFixture<ProductFactory>
    {
        private readonly ProductFactory _factory;

        public ProductTests(ProductFactory factory)
        {
            _factory = factory;
        }

        // Teste de integração
        [Fact]
        public async Task GetProduct_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/produtos");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual("[]", await response.Content.ReadAsStringAsync());
        }

        // Teste de integração
        [Fact]
        public async Task CreateProduct_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new Product("Prod Teste", 10, 10);

            var response = await client.PostAsJsonAsync("/produtos", request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("{\"productId\":6,\"name\":\"Prod Teste\",\"stock\":10,\"value\":10}", content);
        }

        // Teste de integração
        [Fact]
        public async Task GetProductByName_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/produtos?name=Refrigerante X");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("[{\"productId\":1,\"name\":\"Refrigerante X\",\"stock\":100,\"value\":10.90}]", content);
        }

        // Teste de integração
        [Fact]
        public async Task GetProductByOrderBy_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/produtos?orderBy=Name");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("[{\"productId\":5,\"name\":\"Barra de chocolate\",\"stock\":111,\"value\":10.33},{\"productId\":2,\"name\":\"Bolo de cenoura\",\"stock\":5,\"value\":25.99},{\"productId\":4,\"name\":\"Creme de leite\",\"stock\":45,\"value\":3.25},{\"productId\":3,\"name\":\"Leite condensado\",\"stock\":23,\"value\":7.60},{\"productId\":1,\"name\":\"Refrigerante X\",\"stock\":100,\"value\":10.90}]", content);
        }

        [Fact]
        public async Task GetProductById_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/produtos/1");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("{\"productId\":1,\"name\":\"Refrigerante X\",\"stock\":100,\"value\":10.90}", content);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                ProductId = 1,
                Name = "Prod Teste",
                Stock = 10,
                Value = 10
            };

            var response = await client.PutAsJsonAsync("/produtos/1", request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturn_OK()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.DeleteAsync("/produtos/2");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturn_NotFound()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.DeleteAsync("/produtos/100");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn_BadRequest()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new Product("Refrigerante X", 100, 10.90M);

            var response = await client.PostAsJsonAsync("/produtos", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn_BadRequest_Stock()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new {
                Name = "Prod Teste",
                Stock = -10,
                Value = 10
            };

            var response = await client.PostAsJsonAsync("/produtos", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn_BadRequest_Value()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                Name = "Prod Teste",
                Stock = 10,
                Value = -10
            };

            var response = await client.PostAsJsonAsync("/produtos", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn_BadRequest_ValueZero()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                Name = "Prod Teste",
                Stock = 10,
                Value = 0
            };

            var response = await client.PostAsJsonAsync("/produtos", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturn_BadRequest()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new Product("Refrigerante X", 100, 10.90M);

            var response = await client.PutAsJsonAsync("/produtos/1", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturn_BadRequest_Stock()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                Name = "Prod Teste",
                Stock = -10,
                Value = 10
            };

            var response = await client.PutAsJsonAsync("/produtos/1", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturn_BadRequest_Value()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                Name = "Prod Teste",
                Stock = 10,
                Value = -10
            };

            var response = await client.PutAsJsonAsync("/produtos/1", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturn_BadRequest_ValueZero()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                Name = "Prod Teste",
                Stock = 10,
                Value = 0
            };

            var response = await client.PutAsJsonAsync("/produtos/1", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturn_NotFound()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new
            {
                ProductId = 100,
                Name = "Prod Teste",
                Stock = 10,
                Value = 10
            };

            var response = await client.PutAsJsonAsync("/produtos/100", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
