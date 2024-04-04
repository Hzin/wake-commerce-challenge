using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WakeChallenge.CORE.Entities
{
    [Table("products")]
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Value { get; set; }

        [JsonConstructor]
        public Product(string name, int stock, decimal value) 
        {
            Name = name;
            Stock = stock;
            Value = value;

            Validate();
        }

        public Product(int id, string name, int stock, decimal value)
        {
            ProductId = id;
            Name = name;
            Stock = stock;
            Value = value;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Nome do produto é obrigatório");

            if (Stock < 0)
                throw new Exception("O estoque do produto não pode ser negativo");

            if (Value < 0)
                throw new Exception("Valor do produto não pode ser negativo");

            if (Value == 0)
                throw new Exception("Valor do produto não pode ser zero");
        }
    }
}
