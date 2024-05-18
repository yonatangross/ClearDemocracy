using KnessetService.Api.Abstractions;
using KnessetService.Api.Models.Input;
using KnessetService.BL.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace KnessetService.Api;

public class PoliticsApi : IKnessetApi
{
    private readonly ILogger<PoliticsApi> _logger;
    private readonly HttpClient _httpClient;

    public PoliticsApi(HttpClient httpClient, ILogger<PoliticsApi> logger)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36 Edg/124.0.0.0");
        _logger = logger;
    }

    public async Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default)
    {
        var stringUrl = "https://knesset.gov.il/WebSiteApi/knessetapi/MkLobby/GetMkLobbyData?lang=en";
        try
        {
            var response = await _httpClient.GetAsync(stringUrl, ct);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<MKsRoot>(responseString);

                return result.Mks.ToBlModels();
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

    public async Task<IList<Faction>> InitFactions(CancellationToken ct = default)
    {
        var stringUrl = "https://knesset.gov.il/WebSiteApi/knessetapi/Faction/GetFactions?lng=en";
        try
        {
            var response = await _httpClient.GetAsync(stringUrl, ct);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<FactionsRoot>(responseString);

                return result.Factions.ToBlModels();
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

    public async Task<IList<Knesset>> InitKnessets(CancellationToken ct = default)
    {
        var stringUrl = "https://knesset.gov.il/WebSiteApi/knessetapi/Faction/GetFactions?lng=en";
        try
        {
            var response = await _httpClient.GetAsync(stringUrl, ct);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<FactionsRoot>(responseString);

                return result.Knessets.ToBlModels();
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

    public async Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default)
    {
        var stringUrl = $"https://www.knesset.gov.il/WebSiteApi/knessetapi/goverment?GovId={governmentId}&Lang=EN";
        try
        {
            var response = await _httpClient.GetAsync(stringUrl, ct);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<GovernmentRoot>(responseString);

                var governments = result.GovermentsNames.ToBlModels();
                var ministers = result.Ministers.ToBlModels();
                return (governments, ministers);
            }
            else
            {
                _logger.LogError($"Failed to retrieve data from {stringUrl}. Status code: {response.StatusCode}");
                return (null, null);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while retrieving data: {ex.Message}");
            return (null, null);
        }
    }
}

