using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace PaymentAPI.src.Models;

public enum EnumStatusVenda
{
    [Display(Name = "Pagamento aprovado")]
    PagamentoAprovado,
    [Display(Name = "Enviado para transportadora")]
    EnviadoParaTransportadora,
    Entregue,
    Cancelada
}