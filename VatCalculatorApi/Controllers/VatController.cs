using Microsoft.AspNetCore.Mvc;
using VatCalculatorApi.Models;
using VatCalculatorApi.Validators;

namespace VatCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VatController : ControllerBase
    {
        [HttpPost("Calculate")]
        public ActionResult<VatResponse> CalculateVat([FromBody] VatRequest vatRequest)
        {
            var error = RequestValidator.ValidateVatRequest(vatRequest);
            if (error != null)
                return BadRequest(new ErrorResponse("Validation Failed", error));

            return Ok(null);
        }
    }
}
