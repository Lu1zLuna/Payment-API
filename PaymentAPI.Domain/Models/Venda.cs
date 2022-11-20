using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Domain.Models;

public class Venda
{
    #region VendaProps

    private string _status;

    public int Id { get; set; }
    //[JsonConverter(typeof(StringEnumConverter))]
    //[NotMapped]
    //EnumStatusVenda EnumStatusVenda { get; set; }
    public DateTime Data { get; set; }

    [DefaultValue("Aguardando pagamento"), DisplayName("Status")]
    public string StatusVenda {
        get => _status;
        set {
            // Se ArrayStatusValues conter o valor digitado, ele é armazenado
            if (ArrayStatus.ArrayStatusValues.Contains(value)) {
                _status = value;
            }
            // Senão o valor armazenado será "Aguardando pagamento"
            else {
                _status = "Aguardando pagamento";
            }
        }   

    }

    public void AlterarStatusVenda(EnumStatusVenda statusInput) {
        string alteracaoStatus = statusInput.ToString();
        
        if (StatusVenda == "Aguardando pagamento"
            || StatusVenda == "Pagamento aprovado"
            && alteracaoStatus == "Cancelado") 
        {
            StatusVenda = alteracaoStatus;
        }
        else if (StatusVenda == "Aguardando pagamento"
                 && alteracaoStatus == "Pagamento aprovado") {
            StatusVenda = alteracaoStatus;
        }
        else if (StatusVenda == "Pagamento aprovado"
                 && alteracaoStatus == "Enviado para transportadora") {
            StatusVenda = alteracaoStatus;
        }
        else if (StatusVenda == "Enviado para transportadora"
                 && alteracaoStatus == "Entregue") {
        }
        else 
            throw new Exception("Status inválido. Visite a documentação.");

    }

    #endregion

    #region VendedorProps

    [ForeignKey("Vendedor")]
    public int IdVendedor { get; set; }
    public virtual Vendedor Vendedor { get; set; }

    #endregion

    #region PedidoProps

    public ICollection<Pedido> Pedidos { get; set; }

    #endregion
}