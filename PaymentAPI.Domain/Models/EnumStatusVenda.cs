using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Domain.Models;

// A principal função dessa Enum é funcionar como um facilitador para a visualização do HttpPatch
public enum EnumStatusVenda
{
    [Display(Name = "Aguardando pagamento")]
    AguardandoPagamento = 1,
    [Display(Name = "Pagamento aprovado")]
    PagamentoAprovado = 2,
    [Display(Name = "Enviado para transportadora")]
    EnviadoParaTransportadora = 3,
    Entregue = 4,
    Cancelada = 5
}