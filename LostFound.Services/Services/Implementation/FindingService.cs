using AutoMapper;
using LostFound.Entity.Models;
using LostFound.Repository;
using LostFound.Services.Abstract;
using LostFound.Services.Models;

namespace LostFound.Services.Implementation;

public class FindingService : IFindingService
{
    private readonly IRepository<Finding> FindingsRepository;
       private readonly IRepository<Bureau> BureausRepository;
    private readonly IMapper mapper;
    public FindingService(IRepository<Finding> FindingsRepository,IRepository<Bureau> BureausRepository, IMapper mapper)
    {
        this.BureausRepository= BureausRepository;
        this.FindingsRepository = FindingsRepository;
        this.mapper = mapper;
    }

    public void DeleteFinding(Guid id)
    {
        var FindingToDelete = FindingsRepository.GetById(id);
        if (FindingToDelete == null)
        {
            throw new Exception("Finding not found");
        }

        FindingsRepository.Delete(FindingToDelete);
    }

    public FindingModel GetFinding(Guid id)
    {
        var Finding = FindingsRepository.GetById(id);
        return mapper.Map<FindingModel>(Finding);
    }

    public PageModel<FindingPreviewModel> GetFindings(int limit = 20, int offset = 0)
    {
        var Findings = FindingsRepository.GetAll();
        int totalCount = Findings.Count();
        var chunk = Findings.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<FindingPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<FindingPreviewModel>>(Findings),
            TotalCount = totalCount
        };
    }

    public FindingModel UpdateFinding(Guid id, UpdateFindingModel Finding)
    {
        var existingFinding = FindingsRepository.GetById(id);
        if (existingFinding == null)
        {
            throw new Exception("Finding not found");
        }

        existingFinding.ConditionsOfObtaining = Finding.ConditionsOfObtaining;
        existingFinding.Description = Finding.Description;
        existingFinding.StorageTax = Finding.StorageTax;
        existingFinding.TimeRemains = Finding.TimeRemains;


        existingFinding = FindingsRepository.Save(existingFinding);
        return mapper.Map<FindingModel>(existingFinding);
    }
      public FindingModel AddFinding(FindingModel FindingModel)
    {
        if (FindingsRepository.GetAll(x => x.Id == FindingModel.Id).FirstOrDefault()!=null)
            throw new Exception("create not uniqe subject");
        Finding modelCreate = new Finding();
        modelCreate.Id=FindingModel.Id;
        modelCreate.CreationTime = FindingModel.CreationTime;
        modelCreate.ModificationTime= FindingModel.ModificationTime;
        modelCreate.BureauId = FindingModel.BureauId;
        modelCreate.ConditionsOfObtaining = FindingModel.ConditionsOfObtaining;
         modelCreate.DateFound = FindingModel.DateFound;
        modelCreate.Description = FindingModel.Description; 
        modelCreate.Name = FindingModel.Name;
        modelCreate.StorageTax = FindingModel.StorageTax;
         modelCreate.TimeRemains = FindingModel.TimeRemains;

        modelCreate.Bureau = BureausRepository.GetAll(x => x.Id == modelCreate.BureauId).FirstOrDefault();
         if (modelCreate.Bureau==null)
            throw new Exception("not found id Bureaus");
        modelCreate.Bureau.Findings.Add(modelCreate);
        FindingsRepository.Save(mapper.Map<Finding>(modelCreate));

        return FindingModel;
    }
}