using Business.Services.Abstarctions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace PYP_VCard.Controllers;
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IActionResult> Index()
    {
        List<User> users = await _userService.GetAllUserAsync();
        return View(model: users);
    }

    public async Task<IActionResult> Db()
    {
        return View(viewName: "UserDb", model: await _userService.GetAllUserDbAsync());
    }

    [HttpPost]
    public async Task<bool> DbSave()
    {
        return await _userService.DatabaseSaveAsync();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}