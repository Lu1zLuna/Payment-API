using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.Enums;

// Essa Enum define os possíveis status para cada venda
public enum EnumStatusVenda
{
    [Display(Name = "Aguardando pagamento")]
    Aguardando_pagamento = 1,
    [Display(Name = "Pagamento aprovado")]
    Pagamento_aprovado = 2,
    [Display(Name = "Enviado para transportadora")]
    Enviado_para_transportadora = 3,
    Entregue = 4,
    Cancelada = 5
}