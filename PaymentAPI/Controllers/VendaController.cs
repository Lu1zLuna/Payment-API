using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PaymentAPI.Context;
using PaymentAPI.Extensions;
using PaymentAPI.Models;
using PaymentAPI.Models.Enums;

namespace PaymentAPI.Controllers;

[ApiController]
[Route("api-docs/[controller]")]
public class VendaController : ControllerBase
{
    private readonly DatabaseContext _context;

    public VendaController(DatabaseContext context) {
        _context = context;
    }

    #region Requests

    #region Post

    // Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento"
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreatedAtActionResult))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    public IActionResult Registrar(Venda venda) {
        _context.Add(venda);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Buscar), new { id = venda.Id }, venda);
    }

    #endregion

    # region Get

    /// <summary>
    /// Busca uma venda por id
    /// </summary>
    /// <response code="200">
    /// Retorna a venda caso o id exista
    /// </response>
    /// <response-code="404">
    /// Retorna uma mensagem de erro se o id não for encontrado
    /// </response-code>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    // Buscar venda: Busca pelo Id da venda
    [HttpGet("{id}", Name = "Get")]
    public async Task<IActionResult> Buscar(uint id) {

        //busca o id no banco
        var venda = _context.Vendas
            .Include(p => p.Pedidos)
            .Include(p => p.Vendedor)
            .FirstOrDefault(x => x.Id == id);

        //Retorna 404 se o id requisitado não corresponder a nenhuma venda
        if (await _context.Vendas.FindAsync(id) == null)
            return NotFound();

        // Retorna 200 se o id corresponder a uma venda
        return Ok(value: venda);
    }

    #endregion Get

    #region Patch

    // Atualizar venda: Permite que seja atualizado o status da venda
    [HttpPatch("AtualizarStatus")]
    public IActionResult AtualizarStatus(uint id, [FromBody] EnumStatusVenda request) {
        var venda = _context.Vendas
            .Include(p => p.Pedidos)
            .Include(p => p.Vendedor)
            .FirstOrDefault(x => x.Id == id);

        EnumStatusVenda novoStatus = request;

        if (!EnumExtensions.PodeAtualizarStatus(venda.StatusVenda, novoStatus))
            throw new InvalidOperationException();
        venda.StatusVenda = novoStatus;
        _context.Update(venda);
        _context.SaveChanges();

        return Ok(venda);
    }
    #endregion Patch

    #endregion Post

}