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
        var validationResults = models.Select(m => new { Model = m, Result = validator.Validate(m) }).ToList();

        var failedResults = validationResults.Where(r => !r.Result.IsValid).ToList();

        if (failedResults.Any())
        {
            _logger.LogError($"Validation failed for {typeof(T).Name}. {failedResults.Count} errors found:");

            foreach (var failed in failedResults)
            {
                var modelJson = JsonSerializer.Serialize(failed.Model, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogError("Validation errors for model: {0}\nModel JSON: {1}", typeof(T).Name, modelJson);

                foreach (var error in failed.Result.Errors)
                {
                    _logger.LogError("Property: {PropertyName}, Error: {ErrorMessage}", error.PropertyName, error.ErrorMessage);
                }
            }

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
            return result.ToBlModels();
        });
    }

    public Task<(IList<Faction> factions, IList<Knesset> knessets)> InitFactionsAndKnessets(CancellationToken ct = default)
    {
        return ExecuteApiCall(async () =>
        {
            var result = await FetchAndValidateData<FactionsRoot>("https://knesset.gov.il/WebSiteApi/knessetapi/Faction/GetFactions?lng=en");
            if (result == null || !ValidateModels(result.Factions) || !ValidateModels(result.Knessets)) return (null, null);
            var factions = result.Factions.ToBlModels();
            var knessets = result.Knessets.ToBlModels();
            return (factions, knessets);
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
