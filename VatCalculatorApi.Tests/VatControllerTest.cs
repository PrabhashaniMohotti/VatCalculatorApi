using Microsoft.AspNetCore.Mvc;
using VatCalculatorApi.Controllers;
using VatCalculatorApi.Models;

namespace VatCalculatorApi.Tests
{
    public class VatControllerTest
    {
        [Fact]
        public void Validate_CalculateVat_WithMultipleFields_ReturnsBadRequest()
        {
            // Arrange
            var request = new VatRequest { Net = 100, Gross = 120, VatRate = 20 };
            var controller = new VatController();

            // Act
            var result = controller.CalculateVat(request);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            var errorResponse = Assert.IsType<ErrorResponse>(badRequest.Value);

            Assert.Equal("Validation Failed", errorResponse.Message);
            Assert.NotNull(errorResponse.Detail);
        }

        [Fact]
        public void Validate_CalculateVat_WithValidNet_ReturnsCorrectGrossAndVat()
        {
            // Arrange
            var request = new VatRequest { Net = 100, VatRate = 20 };
            var expectedGross = 120;
            var expectedVat = 20;
            var controller = new VatController();

            // Act
            var result = controller.CalculateVat(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<VatResponse>(okResult.Value);

            Assert.Equal(expectedGross, response.Gross);
            Assert.Equal(expectedVat, response.Vat);
        }
    }
}