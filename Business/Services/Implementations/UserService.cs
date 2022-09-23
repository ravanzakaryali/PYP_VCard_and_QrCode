using Business.DTOs.JsonObjects;
using Business.HttpClientService;
using Business.Services.Abstarctions;
using Core.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserClient _userClient;
    private readonly IVCardService _vCardService;
    private readonly AppDbContext _context;
    private static List<User> _users;

    static UserService()
    {
        _users = new List<User>();
    }
    public UserService(IUserClient userClient, AppDbContext context, IVCardService vCardService)
    {
        _userClient = userClient;
        _context = context;
        _vCardService = vCardService;
    }
    public async Task<bool> DatabaseSaveAsync()
    {
        await _context.Users.AddRangeAsync(_users);
        _users = new();
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<List<User>> GetAllUserDbAsync()
    {
        return await _context.Users.Include(c => c.City).Include(c => c.Country).ToListAsync();
    }
    public async Task<List<User>> GetAllUserAsync()
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
                Country = country,
            };
            user.QrCodeUrl = _vCardService.QrCodeGenerator(_vCardService.GenerateVCard(user), 530);
            users.Add(user);
        }
        _users = users;
        return users;
    }
}
