using LostFound.Entity.Models;

namespace LostFound.Services.Models;

public class UserModel : BaseModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }  
}