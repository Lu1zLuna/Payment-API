using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PaymentAPI.src.Models;

public class Venda
{
    public int Id { get; set; }

    public EnumStatusVenda StatusVenda { get; set; }

    public DateTime Data { get; set; }

    [ForeignKey("Vendedor")]
    public int IdVendedor { get; set; }
    public virtual Vendedor Vendedor { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }
    public ICollection<Pedido> Pedidos { get; set; }
}