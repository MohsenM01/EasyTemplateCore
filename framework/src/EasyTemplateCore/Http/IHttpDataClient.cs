using System.Threading.Tasks;
using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.Http
{
    public interface IHttpDataClient
    {
        Task SendCountries(CountryDto country);
    }
}