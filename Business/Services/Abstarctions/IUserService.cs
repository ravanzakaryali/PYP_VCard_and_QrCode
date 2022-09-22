using Core.Models;

namespace Business.Services.Abstarctions;

public interface IUserService
{
    Task<bool> AddUserRangeAsync(List<User> users);
    Task<List<User>> GetAllUser();
}
