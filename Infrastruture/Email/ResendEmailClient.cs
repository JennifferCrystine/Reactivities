using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Resend;

namespace Infrastruture.Email;

public class ResendEmailClient : IEmailClient
{    
    private const string BaseUrl = "https://api.resend.com";
    private readonly HttpClient _http;
    private readonly ResendClientOptions _options;

    public ResendEmailClient(
        HttpClient http,
        IOptions<ResendClientOptions> options)
    {
        _http = http;
        _options = options.Value;

        _http.BaseAddress = new Uri(BaseUrl);
        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _options.ApiToken);
    }

    public async Task SendAsync(EmailMessage message)
    {
        var request = new 
        {
            message.From,
            To = message.To.ToList(),
            message.Subject,
            Html = message.HtmlBody
        };

        var response = await _http.PostAsJsonAsync("/emails", request);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException(
                $"Resend email failed: {response.StatusCode} - {error}");
        }
    }
}
