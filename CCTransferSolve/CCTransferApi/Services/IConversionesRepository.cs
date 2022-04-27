namespace CCTransferApi.Services
{
    public interface IConversionesRepository
    {
        double Conversion(string codigoMonedaOrigen, string codigoMonedaDestino, double _amount);
    }
}
