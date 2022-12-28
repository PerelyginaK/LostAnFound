using AutoMapper;
using LostFound.Entity.Models;
using LostFound.Repository;
using LostFound.Services.Abstract;
using LostFound.Services.Models;

namespace LostFound.Services.Implementation;

public class CityService : ICityService
{
    private readonly IRepository<City> CitysRepository;
    private readonly IMapper mapper;
    public CityService(IRepository<City> CitysRepository, IMapper mapper)
    {
        this.CitysRepository = CitysRepository;
        this.mapper = mapper;
    }

    public void DeleteCity(Guid id)
    {
        var CityToDelete = CitysRepository.GetById(id);
        if (CityToDelete == null)
        {
            throw new Exception("City not found");
        }

        CitysRepository.Delete(CityToDelete);
    }

    public CityModel GetCity(Guid id)
    {
        var City = CitysRepository.GetById(id);
        return mapper.Map<CityModel>(City);
    }

    public PageModel<CityModel> GetCitys(int limit = 20, int offset = 0)
    {
        var Citys = CitysRepository.GetAll();
        int totalCount = Citys.Count();
        var chunk = Citys.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<CityModel>()
        {
            Items = mapper.Map<IEnumerable<CityModel>>(Citys),
            TotalCount = totalCount
        };
    }
      public CityModel AddCity(CityModel CityModel)
    {
        if (CitysRepository.GetAll(x => x.Id == CityModel.Id).FirstOrDefault()!=null)
            throw new Exception("create not uniqe subject");
        City modelCreate = new City();
        modelCreate.Id=CityModel.Id;
        modelCreate.CreationTime = CityModel.CreationTime;
        modelCreate.ModificationTime= CityModel.ModificationTime;
        modelCreate.Name = CityModel.Name;
        CitysRepository.Save(mapper.Map<City>(modelCreate));

        return CityModel;
    }


}