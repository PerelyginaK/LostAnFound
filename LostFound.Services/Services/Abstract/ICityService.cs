using LostFound.Services.Models;
namespace LostFound.Services.Abstract;

public interface ICityService
{
    CityModel GetCity(Guid id);


    void DeleteCity(Guid id);

    PageModel<CityModel> GetCitys(int limit = 20, int offset = 0);
    CityModel AddCity(CityModel CityModel);
}