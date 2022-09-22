using Business.DTOs.JsonObjects;
using Business.HttpClientService;
using Business.Services.Abstarctions;
using Core.Models;
using DAL.Data;

namespace Business.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserClient _userClient;
    private readonly AppDbContext _context;

    public UserService(IUserClient userClient, AppDbContext context)
    {
        _userClient = userClient;
        _context = context;
    }
    public async Task<bool> AddUserRangeAsync(List<User> users)
    {
        await _context.Users.AddRangeAsync(users);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<List<User>> GetAllUser()
    {
        List<User> users = new();
        DatasJsonDto datas = await _userClient.GetUserAsync();
        foreach (UserJsonDto item in datas.Results)
        {
            City city = new()
            {
                Name = item.Location.City
            };
            Country country = new()
            {
                Name = item.Location.State
            };
            User user = new()
            {
                Code = string.Concat(item.Id.Name, item.Id.Value),
                FirstName = string.Concat(item.Name.Title, item.Name.First),
                LastName = item.Name.Last,
                Email = item.Email,
                Phone = item.Phone,
                City = city,
                Country = country
            };
            users.Add(user);
        }
        return users;

    }
}
