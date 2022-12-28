using AutoMapper;
using LostFound.Entity.Models;
using LostFound.Repository;
using LostFound.Services.Abstract;
using LostFound.Services.Models;

namespace LostFound.Services.Implementation;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> EmployeesRepository;
        private readonly IRepository<Bureau> BureausRepository;
    private readonly IMapper mapper;
    public EmployeeService(IRepository<Employee> EmployeesRepository, IRepository<Bureau> BureausRepository, IMapper mapper)
    {
        this.BureausRepository = BureausRepository;
        this.EmployeesRepository = EmployeesRepository;
        this.mapper = mapper;
    }

    public void DeleteEmployee(Guid id)
    {
        var EmployeeToDelete = EmployeesRepository.GetById(id);
        if (EmployeeToDelete == null)
        {
            throw new Exception("Employee not found");
        }

        EmployeesRepository.Delete(EmployeeToDelete);
    }

    public EmployeeModel GetEmployee(Guid id)
    {
        var Employee = EmployeesRepository.GetById(id);
        return mapper.Map<EmployeeModel>(Employee);
    }

    public PageModel<EmployeeModel> GetEmployees(int limit = 20, int offset = 0)
    {
        var Employees = EmployeesRepository.GetAll();
        int totalCount = Employees.Count();
        var chunk = Employees.Skip(offset).Take(limit);

        return new PageModel<EmployeeModel>()
        {
            Items = mapper.Map<IEnumerable<EmployeeModel>>(Employees),
            TotalCount = totalCount
        };
    }
      public EmployeeModel AddEmployee(EmployeeModel EmployeeModel)
    {
        if (EmployeesRepository.GetAll(x => x.Id == EmployeeModel.Id).FirstOrDefault()!=null)
            throw new Exception("create not uniqe subject");
        Employee modelCreate = new Employee();
        modelCreate.Id=EmployeeModel.Id;
        modelCreate.CreationTime = EmployeeModel.CreationTime;
        modelCreate.ModificationTime= EmployeeModel.ModificationTime;
        modelCreate.BureauId = EmployeeModel.BureauId;
        modelCreate.Bureau = BureausRepository.GetAll(x => x.Id == modelCreate.BureauId).FirstOrDefault();
         if (modelCreate.Bureau==null)
            throw new Exception("not found id Bureau");
        modelCreate.Bureau.Employees.Add(modelCreate);
        EmployeesRepository.Save(mapper.Map<Employee>(modelCreate));

        return EmployeeModel;
    }
}