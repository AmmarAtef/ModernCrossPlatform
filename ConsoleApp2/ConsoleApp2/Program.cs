// Use the PnP Framework AuthenticationManager class to get access to SharePoint Online
using Microsoft.SharePoint.Client;
using PnP.Framework;
using System.Text;

var am = new AuthenticationManager();

using (var context = am.GetACSAppOnlyContext("https://catrionsa.sharepoint.com/sites/MasterData",
    "2bd8b0f8-6370-4f2e-b23a-205201ad6e77", "jx/Y43o8dULaqXy6TURM8iQpw5vXvu2+E/1LlL84TBM="))
{
    // Read the target library title
    var targetLibrary = context.Web.Lists.GetByTitle("CD");
    context.Load(targetLibrary, l => l.Title);
    await context.ExecuteQueryAsync();


    var list = context.Web.Lists.GetByTitle("Gender");


    // Query to get all items
    var items = list.GetItems(CamlQuery.CreateAllItemsQuery(1));

    context.Load(items);

    await context.ExecuteQueryAsync();
    string name = String.Empty;
    foreach (var item in items)
    {
        name = Convert.ToString(item["Title"]);
    }





    Console.WriteLine($"The title of the library is: \"{targetLibrary.Title}\"");

    // Add a new document to the target library
    using (var fileContent = new MemoryStream())
    {
        // Create some random text content
        var randomContent = Encoding.UTF8.GetBytes($"Some random content {DateTime.Now}");
        fileContent.Write(randomContent, 0, randomContent.Length);
        fileContent.Position = 0;

        // Upload the content as a random name file
        await targetLibrary.RootFolder.UploadFileAsync($"{Guid.NewGuid().ToString("n")}.txt", fileContent, true);
    }
}