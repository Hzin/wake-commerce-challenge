using WakeChallenge.CORE.Entities;

namespace WakeChallenge.TEST
{
    public class ProductTest
    {
        [Fact]
        public void CreateProductEntity()
        {
            var expectedProduct = new
            {
                Name = "Tesoura sem ponta",
                Stock = 10,
                Value = (decimal) 5.99
            };

            var product = new Product(expectedProduct.Name, expectedProduct.Stock, expectedProduct.Value);

            Assert.Equal(expectedProduct.Name, product.Name);
            Assert.Equal(expectedProduct.Stock, product.Stock);
            Assert.Equal(expectedProduct.Value, product.Value);
        }

        [Fact]
        public void CreateProductEntityWithNegativeValue()
        {
            var expectedProduct = new
            {
                Name = "Tesoura sem ponta",
                Stock = 10,
                Value = (decimal) -5.99
            };

            Assert.Throws<Exception>(() => new Product(expectedProduct.Name, expectedProduct.Stock, expectedProduct.Value));
        }

        [Fact]
        public void CreateProductEntityWithZeroValue()
        {
            var expectedProduct = new
            {
                Name = "Tesoura sem ponta",
                Stock = 10,
                Value = (decimal)0
            };

            Assert.Throws<Exception>(() => new Product(expectedProduct.Name, expectedProduct.Stock, expectedProduct.Value));
        }

        [Fact]
        public void CreateProductEntityWithNegativeStock()
        {
            var expectedProduct = new
            {
                Name = "Tesoura sem ponta",
                Stock = -1,
                Value = (decimal)10
            };

            Assert.Throws<Exception>(() => new Product(expectedProduct.Name, expectedProduct.Stock, expectedProduct.Value));
        }

        [Fact]
        public void CreateProductEntityWithoutName()
        {
            var expectedProduct = new
            {
                Name = "",
                Stock = -1,
                Value = (decimal)10
            };

            Assert.Throws<Exception>(() => new Product(expectedProduct.Name, expectedProduct.Stock, expectedProduct.Value));
        }
    }
}