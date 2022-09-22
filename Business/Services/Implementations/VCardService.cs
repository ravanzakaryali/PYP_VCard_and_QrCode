using Business.HttpClientService;
using Business.Services.Abstarctions;
using Core.Models;
using System.Web;

namespace Business.Services.Implementations;
public class VCardService : IVCardService
{
    public string GenerateVCard(User user)
    {
        return "BEGIN:VCARD\r\n" +
               "VERSION:3.0\r\n" +
               $"N:{user.FirstName};{user.LastName};\r\n" +
               $"FN:{user.LastName + user.FirstName};\r\n" +
               $"EMAIL:{user.Email};\r\n" +
               $"TEL:{user.Phone};\r\n" +
               $"ADR;TYPE#CITY:{user.City.Name};\r\n" +
               $"ADR;TYPE#COUNTRY:{user.Country.Name};\r\n" +
               $"END:VCARD";
    }
    public string QrCodeGenerator(string vcard,int size=300)
    {
        string data =  HttpUtility.UrlEncode(vcard);
        return $"https://chart.googleapis.com//chart?cht=qr&chs={size}x{size}&chl={data}";
    }
}