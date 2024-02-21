using static System.Console;



await CallHttp();

static async Task CallHttp()
{

    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync("http://www.apple.com/");

    WriteLine($"Apple's home page has {response.Content.Headers.ContentLength}");
}