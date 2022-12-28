using LostFound.Services.Models;

namespace LostFound.Services.Abstract;

public interface IFindingService
{
    FindingModel GetFinding(Guid id);

    FindingModel UpdateFinding(Guid id, UpdateFindingModel Finding);

    void DeleteFinding(Guid id);

    PageModel<FindingPreviewModel> GetFindings(int limit = 20, int offset = 0);
    FindingModel AddFinding(FindingModel FindingModel);
}