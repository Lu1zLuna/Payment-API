using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Controllers;
using PaymentAPI.Models;

namespace Payment_API.Tests.Systems.Controllers
{
    public class VendaControllerTests
    {

        private readonly VendaController _requestVendaController;
        private readonly DatabaseContext _context;

        //public VendaControllerTests(DatabaseContext context, VendaController requestVendaController) {
        //    _context = A.Fake<DatabaseContext>();
        //    _requestVendaController = requestVendaController;
        //}


        //[Theory]
        //[InlineData(1, 200)]
        //public async Task VendaController_Buscar_Retorna200Ok(int a, int b) {
        //    // Arrange

        //    // Act
        //    var result = (OkObjectResult)await _requestVendaController.Buscar(a);

        //    // Assert
        //    result.StatusCode.Should().Be(b);
        //}

    }
}
