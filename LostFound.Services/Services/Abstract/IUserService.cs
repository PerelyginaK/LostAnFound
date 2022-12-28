using LostFound.Services.Models;

namespace LostFound.Services.Abstract;

public interface IUserService
{
    UserModel GetUser(Guid id);

    void DeleteUser(Guid id);

    PageModel<UserModel> GetUsers(int limit = 20, int offset = 0);
}