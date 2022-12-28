using AutoMapper;
using LostFound.WebAPI.Models;
using LostFound.Services.Models;

namespace LostFound.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
         #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));
        CreateMap(typeof(PageResponse<>), typeof(PageModel<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        #endregion
         #region Bureau

        CreateMap<BureauModel, BureauResponse>().ReverseMap();
        #endregion
         #region City

        CreateMap<CityModel, CityResponse>().ReverseMap();
        #endregion
         #region Employee

        CreateMap<EmployeeModel, EmployeeResponse>().ReverseMap();
        #endregion
         #region Finding

        CreateMap<FindingModel, FindingResponse>().ReverseMap();
        CreateMap<UpdateFindingRequest, UpdateFindingModel>().ReverseMap();
        CreateMap<FindingPreviewModel, FindingPreviewResponse>().ReverseMap();
        CreateMap<FindingResponse,FindingPreviewModel>().ReverseMap();
        #endregion
    }
}