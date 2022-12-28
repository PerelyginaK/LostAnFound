using LostFound.Services.Models;

namespace LostFound.Services.Abstract;

public interface IBureauService
{
    BureauModel GetBureau(Guid id);

    void DeleteBureau(Guid id);

    PageModel<BureauModel> GetBureaus(int limit = 20, int offset = 0);
    BureauModel AddBureau(BureauModel BureauModel);
}