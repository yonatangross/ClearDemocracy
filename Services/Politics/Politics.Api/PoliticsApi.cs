using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Politics.Api.Abstractions;
using Politics.Api.Models.Input;
using Politics.BL.Models;
using System.Text.Json;

namespace Politics.Api;

public class PoliticsApi : IKnessetApi
{
    private readonly ILogger<PoliticsApi> _logger;
    private readonly HttpClient _httpClient;
    private readonly IServiceProvider _serviceProvider;

    public PoliticsApi(HttpClient httpClient, ILogger<PoliticsApi> logger, IServiceProvider serviceProvider)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36 Edg/124.0.0.0");
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    private async Task<T> ExecuteApiCall<T>(Func<Task<T>> apiCall)
    {
        try
        {
            return await apiCall();
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while retrieving data: {ex.Message}");
            return default;
        }
    }

    private async Task<T> FetchAndValidateData<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
            return default;
        }

        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<T>(responseString);

        return result;
    }

    private bool ValidateModels<T>(IEnumerable<T> models)
    {
        var validator = _serviceProvider.GetRequiredService<IValidator<T>>();
        var validationResult = models.Select(validator.Validate).ToList();

        if (validationResult.Any(r => !r.IsValid))
        {
            _logger.LogError($"Validation failed for {typeof(T).Name}.");
            return false;
        }

        return true;
    }

    public Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default)
    {
        return ExecuteApiCall(async () =>
        {
            var result = await FetchAndValidateData<MKsRoot>("https://knesset.gov.il/WebSiteApi/knessetapi/MkLobby/GetMkLobbyData?lang=en");
            if (result == null || !ValidateModels(result.Mks)) return null;
            return result.Mks.ToBlModels();
        });
    }

    public Task<IList<Faction>> InitFactions(CancellationToken ct = default)
    {
        return ExecuteApiCall(async () =>
        {
            var result = await FetchAndValidateData<FactionsRoot>("https://knesset.gov.il/WebSiteApi/knessetapi/Faction/GetFactions?lng=en");
            if (result == null || !ValidateModels(result.Factions)) return null;
            return result.Factions.ToBlModels();
        });
    }

    public Task<IList<Knesset>> InitKnessets(CancellationToken ct = default)
    {
        return ExecuteApiCall(async () =>
        {
            var result = await FetchAndValidateData<FactionsRoot>("https://knesset.gov.il/WebSiteApi/knessetapi/Faction/GetFactions?lng=en");
            if (result == null || !ValidateModels(result.Knessets)) return null;
            return result.Knessets.ToBlModels();
        });
    }

    public Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default)
    {
        return ExecuteApiCall(async () =>
        {
            var result = await FetchAndValidateData<GovernmentRoot>($"https://www.knesset.gov.il/WebSiteApi/knessetapi/goverment?GovId={governmentId}&Lang=EN");
            if (result == null) return (null, null);

            if (!ValidateModels(result.GovermentsNames) || !ValidateModels(result.Ministers)) return (null, null);

            var governments = result.GovermentsNames.ToBlModels();
            var ministers = result.Ministers.ToBlModels();
            return (governments, ministers);
        });
    }
}
