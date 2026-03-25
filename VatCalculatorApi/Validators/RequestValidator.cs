using VatCalculatorApi.Models;

namespace VatCalculatorApi.Validators
{
    public static class RequestValidator
    {
        public static string? ValidateVatRequest(VatRequest vatRequest)
        {
            if (vatRequest == null)
                return "Request cannot be null.";

            //Should provide value only one field
            int enteredAmountCount = 0;
            if (vatRequest.Net.HasValue) enteredAmountCount++;
            if (vatRequest.Gross.HasValue) enteredAmountCount++;
            if (vatRequest.Vat.HasValue) enteredAmountCount++;

            if (enteredAmountCount == 0)
                return "At least one amount value must be provided.";

            if (enteredAmountCount > 1)
                return "Provide value in only one field.";

            //Validate the amount
            if (vatRequest.Net.HasValue && vatRequest.Net <= 0)
                return "Net amount must be greater than 0.";
            if (vatRequest.Gross.HasValue && vatRequest.Gross <= 0)
                return "Gross amount must be greater than 0.";
            if (vatRequest.Vat.HasValue && vatRequest.Vat <= 0)
                return "Vat amount must be greater than 0.";

            //Validate VAT rate
            if (vatRequest.VatRate != 10 && vatRequest.VatRate != 13 && vatRequest.VatRate != 20)
                return "Invalid VAT rate. Allowed only 10, 13, 20 rate values.";

            return null;
        }
    }
}
