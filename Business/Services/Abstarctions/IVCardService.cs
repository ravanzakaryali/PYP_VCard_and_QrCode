using Core.Models;

namespace Business.Services.Abstarctions;
public interface IVCardService
{
    string QrCodeGenerator(string vcard, int size = 300);
    string GenerateVCard(User user);
}