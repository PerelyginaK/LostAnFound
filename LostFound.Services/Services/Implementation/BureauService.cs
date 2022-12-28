using AutoMapper;
using LostFound.Entity.Models;
using LostFound.Repository;
using LostFound.Services.Abstract;
using LostFound.Services.Models;

namespace LostFound.Services.Implementation;

public class BureauService : IBureauService
{
    private readonly IRepository<Bureau> BureausRepository;
      private readonly IRepository<City> CitysRepository;
    private readonly IMapper mapper;
    public BureauService(IRepository<Bureau> BureausRepository,IRepository<City> CitysRepository, IMapper mapper)
    {
        this.CitysRepository = CitysRepository;
        this.BureausRepository = BureausRepository;
        this.mapper = mapper;
    }

    public void DeleteBureau(Guid id)
    {
        var BureauToDelete = BureausRepository.GetById(id);
        if (BureauToDelete == null)
        {
            throw new Exception("Bureau not found");
        }

        BureausRepository.Delete(BureauToDelete);
    }

    public BureauModel GetBureau(Guid id)
    {
        var Bureau = BureausRepository.GetById(id);
        return mapper.Map<BureauModel>(Bureau);
    }

    public PageModel<BureauModel> GetBureaus(int limit = 20, int offset = 0)
    {
        var Bureaus = BureausRepository.GetAll();
        int totalCount = Bureaus.Count();
        var chunk = Bureaus.OrderBy(x => x.Adress).Skip(offset).Take(limit);

        return new PageModel<BureauModel>()
        {
            Items = mapper.Map<IEnumerable<BureauModel>>(Bureaus),
            TotalCount = totalCount
        };
    }
      public BureauModel AddBureau(BureauModel BureauModel)
    {
        if (BureausRepository.GetAll(x => x.Id == BureauModel.Id).FirstOrDefault()!=null)
            throw new Exception("create not uniqe subject");
        Bureau modelCreate = new Bureau();
        modelCreate.Id=BureauModel.Id;
        modelCreate.CreationTime = BureauModel.CreationTime;
        modelCreate.ModificationTime= BureauModel.ModificationTime;
        modelCreate.Adress = BureauModel.Adress;
        modelCreate.CityId = BureauModel.CityId;
        modelCreate.City = CitysRepository.GetAll(x => x.Id == modelCreate.CityId).FirstOrDefault();
         if (modelCreate.City==null)
            throw new Exception("not found id City");
        modelCreate.City.Bureaus.Add(modelCreate);
        BureausRepository.Save(mapper.Map<Bureau>(modelCreate));
        return BureauModel;
    }
}