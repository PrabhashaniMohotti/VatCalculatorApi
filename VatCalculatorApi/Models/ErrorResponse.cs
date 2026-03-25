namespace VatCalculatorApi.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string? Detail { get; set; }

        public ErrorResponse(string message, string? detail = null)
        {
            Message = message;
            Detail = detail;
        }
    }
}
