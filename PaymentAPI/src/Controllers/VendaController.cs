using Microsoft.AspNetCore.Mvc;
using PaymentAPI.src.Context;

namespace PaymentAPI.src.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private DatabaseContext _context;

    public VendaController(DatabaseContext context) {
        this._context = context;
    }

    // TODO: Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento"
    [HttpPost]
    public IActionResult Registrar() {
        return Ok();
    }

    // TODO: Buscar venda: Busca pelo Id da venda
    [HttpGet]
    public IActionResult Buscar(int id) {
        return Ok();
    }

    // TODO: Atualizar venda: Permite que seja atualizado o status da venda
    [HttpPatch]
    public IActionResult Atualizar() {
        return Ok();
    }
}