using ClearDemocracy.KnessetService.Abstractions;
using ClearDemocracy.KnessetService.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ClearDemocracy.KnessetService;

public class KnessetApi : IKnessetApi
{
    private readonly ILogger<KnessetApi> _logger;
    private readonly HttpClient _httpClient;

    public KnessetApi(HttpClient httpClient, ILogger<KnessetApi> logger)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36 Edg/124.0.0.0");
        _logger = logger;
    }

    public async Task<IList<MK>> GetMkLobbyData(CancellationToken ct = default)
    {
        var stringUrl = "https://knesset.gov.il/WebSiteApi/knessetapi/MkLobby/GetMkLobbyData?lang=en";
        try
        {
            var response = await _httpClient.GetAsync(stringUrl, ct);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<MKsRoot>(responseString);

                return result.mks;
            }
            else
            {
                _logger.LogError($"Failed to retrieve data from {stringUrl}. Status code: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while retrieving data: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Faction>> GetFactions(CancellationToken ct = default)
    {
        var stringUrl = "https://knesset.gov.il/WebSiteApi/knessetapi/Faction/GetFactions?lng=en";
        try
        {
            var response = await _httpClient.GetAsync(stringUrl, ct);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<FactionsRoot>(responseString);

                return result.Factions;
            }
            else
            {
                _logger.LogError($"Failed to retrieve data from {stringUrl}. Status code: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while retrieving data: {ex.Message}");
            return null;
        }
    }

    public Task<IList<Knesset>> GetKnessets(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}

