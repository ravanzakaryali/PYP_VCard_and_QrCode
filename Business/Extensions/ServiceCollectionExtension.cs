using Business.HttpClientService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Refit;
using System.Text.Json;

namespace Business.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddRefitHttpClient<T>(this IServiceCollection service, string baseurl) where T : class
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        var settings = new RefitSettings()
        {
            ContentSerializer = new SystemTextJsonContentSerializer(options)
        };

        service.AddRefitClient<T>(settings)
                    .ConfigureHttpClient(hc =>
                    {
                        hc.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                        hc.BaseAddress = new Uri(baseurl);
                    });
    }
}
