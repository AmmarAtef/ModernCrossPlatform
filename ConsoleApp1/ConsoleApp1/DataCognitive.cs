using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class DataCognitive
    {

        static readonly string ApiBase = "https://cog-gnzcqaoglj42s.openai.azure.com/";
        static readonly string ApiKey = "0a2f860b02b2477d96af652a1412be9c";
        static readonly string DeploymentId = "chat";

        // Azure AI Search setup
        static readonly string SearchEndpoint = "https://gptkb-gnzcqaoglj42s.search.windows.net";
        static readonly string SearchKey = "DlorNhQbhPlCrdqlrbjqCtACTVGKmpwABx8Hm8Yb4IAzSeC3dgh3";
        static readonly string SearchIndexName = "gptkbindex";

        static async Task getData()
        {
            SetupBYOD(DeploymentId);

            var messageText = new[] { new { role = "user", content = "What are the differences between Azure Machine Learning and Azure AI services?" } };

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

                var completion = await ChatCompletionAsync(httpClient, messageText, DeploymentId);

                Console.WriteLine(completion);
            }
        }

        static void SetupBYOD(string deploymentId)
        {
            // Not needed for C# as it deals with sessions differently
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
}
