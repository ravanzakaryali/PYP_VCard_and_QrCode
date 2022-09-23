using Core.Models;

namespace Business.Services.Abstarctions;

public interface IUserService
{
    Task<bool> DatabaseSaveAsync();
    Task<List<User>> GetAllUserAsync();
    Task<List<User>> GetAllUserDbAsync();
}
