using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.src.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Preco { get; set; }
    }
}
