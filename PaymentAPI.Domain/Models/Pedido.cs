﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Domain.Models
{
    public class Pedido
    {
        private readonly decimal _preco;

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DefaultValue("Nome do produto")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1}")]
        public string Nome { get; set; }

        [Precision(18,2), DefaultValue(0.01)]
        public decimal Preco { get; set; }

        // Propriedades de navegação (permite que o EntityFrameWork detecte
        // a relação de 1 para n entre Venda e Pedido)
        [NotMapped]
        int VendaId { get; set; }
        [NotMapped]
        Venda Venda { get; set; }
    }
}
