using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{

    static readonly string ApiBase = "https://cog-gnzcqaoglj42s.openai.azure.com/";
    static readonly string ApiKey = "0ff4135d095c4a348364c1b718552219";
    static readonly string DeploymentId = "chat";

    // Azure AI Search setup
    static readonly string SearchEndpoint = "https://gptkb-gnzcqaoglj42s.search.windows.net";
    static readonly string SearchKey = "M3ImO31JGkHt5RnTAGQLS6xlvQQruIxGrd1wy2QXy3AzSeCjZWAd";
    static readonly string SearchIndexName = "gptkbindex";

    static async Task Main()
    {
        

        var messageText = new[] { new { role = "user", content = "What are the differences between Azure Machine Learning and Azure AI services?" } };

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

            var completion = await ChatCompletionAsync(httpClient, messageText, DeploymentId);

            Console.WriteLine(completion);
        }
    }

  

    static async Task<object> ChatCompletionAsync(HttpClient httpClient, object[] messages, string deploymentId)
    {
        var url = $"{ApiBase}/openai/deployments/{deploymentId}/extensions/chat/completions?api-version=2023-08-01-preview";
        var requestBody = new { messages, deployment_id = deploymentId, dataSources = new[] { new { type = "AzureCognitiveSearch", parameters = new { endpoint = SearchEndpoint, key = SearchKey, indexName = SearchIndexName } } } };

        using (var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestBody)))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var response = await httpClient.PostAsync(url, content))
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
            }
        }
    }
}
