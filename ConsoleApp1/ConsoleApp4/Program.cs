using Azure;
using Azure.AI.OpenAI;
using System.Text.Json;
using static System.Environment;



string azureOpenAIEndpoint = "https://cog-gnzcqaoglj42s.openai.azure.com/";
string azureOpenAIKey = "0ff4135d095c4a348364c1b718552219";
string searchEndpoint = "https://gptkb-gnzcqaoglj42s.search.windows.net";
string searchKey = "M3ImO31JGkHt5RnTAGQLS6xlvQQruIxGrd1wy2QXy3AzSeCjZWAd";
string searchIndex = "gptkbindex";
string deploymentName = "chat";

var client = new OpenAIClient(new Uri(azureOpenAIEndpoint), new AzureKeyCredential(azureOpenAIKey));



var chatCompletionsOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatMessage(ChatRole.User, "what is sacc?"),
    },
    AzureExtensionsOptions = new AzureChatExtensionsOptions()
    {
        Extensions =
        {
            new AzureCognitiveSearchChatExtensionConfiguration()
            {
                SearchEndpoint = new Uri(searchEndpoint),
                SearchKey = new AzureKeyCredential(searchKey),
                IndexName = searchIndex,
            },
        }
    }
};

Response<ChatCompletions> response = client.GetChatCompletions(deploymentName, chatCompletionsOptions);

ChatMessage responseMessage = response.Value.Choices[0].Message;

Console.WriteLine($"Message from {responseMessage.Role}:");
Console.WriteLine("===");
Console.WriteLine(responseMessage.Content);
Console.WriteLine("===");

Console.WriteLine($"Context information:");
Console.WriteLine("===");
foreach (ChatMessage contextMessage in responseMessage.AzureExtensionsContext.Messages)
{
    string contextContent = contextMessage.Content;
    try
    {
        var contextMessageJson = JsonDocument.Parse(contextMessage.Content);
        contextContent = JsonSerializer.Serialize(contextMessageJson, new JsonSerializerOptions()
        {
            WriteIndented = true,
        });
    }
    catch (JsonException)
    { }
    Console.WriteLine($"{contextMessage.Role}: {contextContent}");
}
Console.WriteLine("===");