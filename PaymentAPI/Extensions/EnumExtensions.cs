using System.ComponentModel.DataAnnotations;
using System.Reflection;
using PaymentAPI.Models.Enums;

namespace PaymentAPI.Extensions;

public static class EnumExtensions
{
    //Dicionário que determina quais valores poder ser atualizado
    public static Dictionary<EnumStatusVenda, List<EnumStatusVenda>> MudancaStatusDictionary =
    new Dictionary<EnumStatusVenda, List<EnumStatusVenda>>() {
        {
            EnumStatusVenda.Aguardando_pagamento,
            new List<EnumStatusVenda> { EnumStatusVenda.Pagamento_aprovado, EnumStatusVenda.Cancelada }
        }, {
            EnumStatusVenda.Pagamento_aprovado,
            new List<EnumStatusVenda> { EnumStatusVenda.Enviado_para_transportadora, EnumStatusVenda.Cancelada }
        }, {
            EnumStatusVenda.Enviado_para_transportadora,
            new List<EnumStatusVenda> { EnumStatusVenda.Entregue }
        }
    };

    // Recebe o status atual/antigo e o novo status solicitado para atualização da venda
    // Retornando o Novo Status se ele for equivalente ao valor contido no dicionário
    public static bool PodeAtualizarStatus(EnumStatusVenda antigo, EnumStatusVenda novoStatus) {
        return MudancaStatusDictionary.ContainsKey(antigo)
               && MudancaStatusDictionary[antigo].Contains(novoStatus);
    }
}

