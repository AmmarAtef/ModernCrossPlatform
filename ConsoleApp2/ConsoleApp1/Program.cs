
using Azure;
using Azure.Search.Documents;
string indexName = "gptkbindex";

Uri endpoint = new Uri("https://gptkb-gnzcqaoglj42s.search.windows.net");
string key = "M3ImO31JGkHt5RnTAGQLS6xlvQQruIxGrd1wy2QXy3AzSeCjZWAd";


AzureKeyCredential credential = new AzureKeyCredential(key);
SearchClient client = new SearchClient(endpoint, indexName, credential);

string searchQuery = "resources?top=1000";

try
{
    
    var response = client.Search<doc>(searchQuery);

    if (response.Value != null)
    {
        Console.WriteLine(response.Value.TotalCount);

        foreach (var result in response.Value.GetResults())
        {
            string document = result.Document.id;
            Console.WriteLine($"Retrieved Document: {document}");
        }
    }
    else
    {
        Console.WriteLine($"Error performing search. Status: {response}");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Error performing search: {ex.Message}");
}

class doc
{
    public string id { get; set; }
}