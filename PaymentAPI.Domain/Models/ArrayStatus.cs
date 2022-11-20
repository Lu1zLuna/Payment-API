namespace PaymentAPI.Domain.Models
{
    public class ArrayStatus
    {
        public static readonly string[] ArrayStatusValues = new string[5] {
            "Aguardando pagamento",
            "Pagamento aprovado",
            "Enviado para transportadora",
            "Entregue",
            "Cancelada"
        };
    }
}
