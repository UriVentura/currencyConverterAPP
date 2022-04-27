using FixerSharpCore;

namespace CCTransferApi.Services
{
    public class ConversionesFakeRepository : IConversionesRepository
    {
        public double Conversion(string codigoMonedaOrigen, string codigoMonedaDestino, double amount)

        {
            ExchangeRate rate = Fixer.Rate(codigoMonedaOrigen, codigoMonedaDestino);
            double _amount = rate.Convert(amount);
            return _amount;

        }
    }
}
