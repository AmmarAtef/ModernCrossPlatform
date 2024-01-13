using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string searchEndpoint = "https://gptkb-gnzcqaoglj42s.search.windows.net";
        string apiKey = "M3ImO31JGkHt5RnTAGQLS6xlvQQruIxGrd1wy2QXy3AzSeCjZWAd";
        string indexName = "gptkbindex";

        string apiBase = $"{searchEndpoint}/indexes/{indexName}/docs/search?api-version=2020-06-30";

        using (var httpClient = new HttpClient())
        {
            string searchQuery = "what is sacc?";
            var requestContent = new StringContent($"{{\"search\": \"{searchQuery}\"}}", Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, apiBase);
            httpRequestMessage.Headers.Add("api-key", apiKey);
            httpRequestMessage.Content = requestContent;

            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Successful response: {responseContent}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

