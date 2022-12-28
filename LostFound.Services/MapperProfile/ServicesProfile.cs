using AutoMapper;
using LostFound.Entity.Models;
using LostFound.Services.Models;

namespace LostFound.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Bureau
        CreateMap<Bureau, BureauModel>().ReverseMap();
        #endregion

          #region City
        CreateMap<City, CityModel>().ReverseMap();
        #endregion
        #region Employee
        CreateMap<Employee, EmployeeModel>().ReverseMap();
        #endregion
        
         #region Finding

        CreateMap<Finding, FindingModel>().ReverseMap();
        CreateMap<Finding,FindingPreviewModel>().ReverseMap();
        #endregion

        #region Users

         CreateMap<User, UserModel>().ReverseMap();


        #endregion
    }
}