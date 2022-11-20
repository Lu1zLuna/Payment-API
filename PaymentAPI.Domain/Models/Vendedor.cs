using System.ComponentModel;

namespace PaymentAPI.Domain.Models;

public class Vendedor
{
    public int Id { get; set; }
    [DefaultValue("xxx.xxx.xxx-xx")]
    public string Cpf { get; set; }
    [DefaultValue("Exemplo da Silva")]
    public string Nome { get; set; }
    [DefaultValue("emaildovendedor@email.com")]
    public string Email { get; set; }
    [DefaultValue("9xxxx-xxxx")]
    public string Telefone { get; set; }
}