using LostFound.Services.Models;

namespace LostFound.Services.Abstract;

public interface IEmployeeService
{
    EmployeeModel GetEmployee(Guid id);

    void DeleteEmployee(Guid id);

    PageModel<EmployeeModel> GetEmployees(int limit = 20, int offset = 0);
    EmployeeModel AddEmployee(EmployeeModel EmployeeModel);
}