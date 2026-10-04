using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.OutputEncoding = Encoding.UTF8;

const string endpoint = "https://api.adviceslip.com/advice";

Console.WriteLine("Iniciando requisição para obter dados de um conselho:");
Console.WriteLine();
Console.WriteLine(endpoint);
Console.WriteLine();

using HttpClient client = new();

try
{
    HttpResponseMessage response = await client.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();

    string json = await response.Content.ReadAsStringAsync();

    AdviceResponse? adviceResponse = JsonSerializer.Deserialize<AdviceResponse>(json);

    if (adviceResponse?.Slip?.Advice is not null)
    {
        Console.WriteLine("Conselho de Hoje:");
        Console.WriteLine(adviceResponse.Slip.Advice);
    }
    else
    {
        Console.WriteLine("Não foi possível obter um conselho da API.");
    }
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Erro ao acessar a API.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}
catch (JsonException ex)
{
    Console.WriteLine("Erro ao interpretar os dados retornados pela API.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}

public class AdviceResponse
{
    [JsonPropertyName("slip")]
    public AdviceSlip? Slip { get; set; }
}

public class AdviceSlip
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("advice")]
    public string? Advice { get; set; }
}
