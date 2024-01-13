using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;


class Program
{
    static async Task Main()
    {
        var endpoint = new Uri("https://cog-zthwxw66y33fs.openai.azure.com/");
        AzureKeyCredential az = new AzureKeyCredential("2b1bc54a65b54e5b971c04617510324b");
        OpenAIClient client = new OpenAIClient(endpoint, az);
        var deploymentId = "chat";



        var messages = new ChatCompletionsOptions()
        {
            Messages =
            {
                new ChatMessage(ChatRole.System, "What is ISO ?"),
                new ChatMessage(ChatRole.User, "what is ISO ?"),
                new ChatMessage(ChatRole.Assistant, "no"),
                new ChatMessage(ChatRole.User, "What is sacc?"),

            },
            MaxTokens = 1000


        };


        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(deploymentId, messages);

        var respons = response.Value.Choices.First().Message.Content;

        
    }
}
