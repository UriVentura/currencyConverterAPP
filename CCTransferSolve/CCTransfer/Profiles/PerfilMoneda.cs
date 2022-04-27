using AutoMapper;
using CCTransferApi.Models;

namespace CCTransferApi.Profiles
{
    public class PerfilMoneda : Profile
    {
        public PerfilMoneda()
        { 
            //Vinculación del mapeo
            CreateMap<Moneda, MonedaDto>();
            
            CreateMap<MonedaDto, Moneda>();
        }
    }
}
