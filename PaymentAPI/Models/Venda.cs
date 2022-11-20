using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PaymentAPI.Models.Enums;

namespace PaymentAPI.Models;

public class Venda
{
    #region Propriedades exclusivas da Venda

    public int Id { get; set; }

    public DateTime Data { get; set; }

    [DefaultValue("Aguardando pagamento")]
    public EnumStatusVenda StatusVenda { get; set; }

    #endregion

    #region Propriedades relacionadas a classe Vendedor

    [ForeignKey("Vendedor")]
    public int IdVendedor { get; set; }
    public virtual Vendedor Vendedor { get; set; }

    #endregion

    #region Propriedades relacionadas a classe Pedido

    public ICollection<Pedido> Pedidos { get; set; }

    #endregion
}