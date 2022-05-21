using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiService
{
    private static HttpClient? _client = default;

    public ApiService(string apiUrl)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        _client = new HttpClient(handler);
        _client.BaseAddress = new Uri(apiUrl);
    }

    public async Task<IEnumerable<Recipe>> GetExistingRecipesAsync()
    {
        var response = await _client!.GetAsync("/api/recipes");

        response.EnsureSuccessStatusCode();
        
        var data = await JsonSerializer.DeserializeAsync<IEnumerable<Recipe>>(response.Content.ReadAsStream());

        return data ?? Enumerable.Empty<Recipe>();
    }
}
