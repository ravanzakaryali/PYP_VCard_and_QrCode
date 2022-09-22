using Business.DTOs.JsonObjects;
using Refit;

namespace Business.HttpClientService;

public interface IUserClient
{
    [Get("/api?results=50")]
    public Task<DatasJsonDto> GetUserAsync();  

}
