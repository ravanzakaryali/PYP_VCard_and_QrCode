using Business.Services.Abstarctions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Buffers.Text;
using System.Text;

namespace PYP_VCard.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;
    private readonly IVCardService _vCardService;
    public HomeController(IUserService userService, IVCardService vCardService)
    {
        _userService = userService;
        _vCardService = vCardService;
    }
    public async Task<IActionResult> Index()
    {
        List<User> users = await _userService.GetAllUser();
        string vcard = _vCardService.GenerateVCard(users[0]);
        string image = _vCardService.QrCodeGenerator(vcard);
        return View(model: image);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
