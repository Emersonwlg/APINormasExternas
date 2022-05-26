using AutoMapper;
using Norma.Api.ViewModels;
using Norma.Business.Models;

namespace Norma.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<NormaExternaViewModel, NormaExterna>();
            CreateMap<NormaExterna, NormaExternaViewModel>();

            CreateMap<ArquivoViewModel, Arquivo>();
            CreateMap<Arquivo, ArquivoViewModel>();

        }
    }
}