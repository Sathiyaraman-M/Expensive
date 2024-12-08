using Expensive.Common.Contracts.LookupTypes;
using Expensive.Common.Wrappers;
using Expensive.Common.Wrappers.Abstractions;
using Expensive.UI.Abstractions.Services.Http;
using System.Net.Http.Json;

namespace Expensive.UI.Services.Http;

public class SearchService(HttpClient httpClient) : ISearchService
{
    public async Task<IResult<List<LookupTypeSearchResponse>>> SearchPaymentMethodsAsync(string searchTerm)
    {
        var response = await httpClient.GetAsync($"api/lookup-types/search/payment-methods?searchTerm={searchTerm}");
        var data = await response.Content.ReadFromJsonAsync<List<LookupTypeSearchResponse>>();
        return SuccessfulResult<List<LookupTypeSearchResponse>>.Succeed(data ?? []);
    }

    public async Task<IResult<List<LookupTypeSearchResponse>>> SearchExpenseTypesAsync(string searchTerm)
    {
        var response = await httpClient.GetAsync($"api/lookup-types/search/expense-types?searchTerm={searchTerm}");
        var data = await response.Content.ReadFromJsonAsync<List<LookupTypeSearchResponse>>();
        return SuccessfulResult<List<LookupTypeSearchResponse>>.Succeed(data ?? []);
    }
}