using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WakeChallenge.API.Models
{
    public class ProductDto
    {
        public int? ProductId { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        //Validar se o estoque não é negativo
        [Range(0, int.MaxValue, ErrorMessage = "O estoque do produto não pode ser negativo")]
        [Required(ErrorMessage = "O estoque do produto é obrigatório")]
        [DisplayName("Estoque")]
        public int Stock { get; set; }
        //Validar se o valor é maior que zero
        [Range(0.01, int.MaxValue, ErrorMessage = "O valor do produto deve ser maior que zero")]
        [Required(ErrorMessage = "O valor do produto é obrigatório")]
        [DisplayName("Valor")]
        public decimal Value { get; set; }
    }
}
