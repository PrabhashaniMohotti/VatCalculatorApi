using VatCalculatorApi.Models;

namespace VatCalculatorApi.Services
{
    public static class VatService
    {
        public static VatResponse Calculate(VatRequest vatRequest)
        {
            var rate = vatRequest.VatRate / 100m;
            decimal gross = 0, net = 0, vat = 0;

            if (vatRequest.Net.HasValue && vatRequest.Net > 0)
            {
                net = vatRequest.Net.Value;
                gross = vatRequest.Net.Value * (1 + rate);
                vat = vatRequest.Net.Value * rate;
            }
            else if (vatRequest.Gross.HasValue && vatRequest.Gross > 0)
            {
                gross = vatRequest.Gross.Value;
                net = vatRequest.Gross.Value / (1 + rate);
                vat = vatRequest.Gross.Value - net;
            }
            else if (vatRequest.Vat.HasValue && vatRequest.Vat > 0)
            {
                vat = vatRequest.Vat.Value;
                net = vatRequest.Vat.Value / rate;
                gross = vatRequest.Vat.Value / rate * (1 + rate);
            }

            return new VatResponse
            {
                Net = Math.Round(net, 2),
                Gross = Math.Round(gross, 2),
                Vat = Math.Round(vat, 2)
            };
        }
    }
}
