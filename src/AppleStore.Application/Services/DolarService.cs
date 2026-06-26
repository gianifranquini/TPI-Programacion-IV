using AppleStore.Application.DTOs;
using System.Net.Http.Json;

namespace AppleStore.Application.Services;

public class DolarService
{
    private readonly HttpClient _httpClient;

    public DolarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DolarResponse?> ObtenerDolarOficial()
    {
        return await _httpClient.GetFromJsonAsync<DolarResponse>(
            "v1/dolares/oficial");
    }
}