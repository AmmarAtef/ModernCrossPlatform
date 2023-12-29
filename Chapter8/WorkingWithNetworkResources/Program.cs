using static System.Console;
using System.Net;
using System.Net.NetworkInformation;

WriteLine("Enter a valid web address: ");
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
    url = "https://stackoverflow.com/search?q=securestring";
}

Uri uri = new Uri(url);


WriteLine($"Url: {url}");
WriteLine($"Scheme: {uri.Scheme}");
WriteLine($"Port: {uri.Port}");
WriteLine($"Host: {uri.Host}");
WriteLine($"Path: {uri.AbsolutePath}");
WriteLine($"Query: {uri.Query}");


IPHostEntry hostEntry = Dns.GetHostEntry(uri.Host);
WriteLine($"{hostEntry.HostName} has the following IP addresses: ");

foreach (IPAddress address in hostEntry.AddressList)
{
    WriteLine($"{address} ({address.AddressFamily})");
}

try
{
    Ping ping = new Ping();
    WriteLine($"Pinging server. Please wait...");
    PingReply pingReply = ping.Send(uri.Host);
    WriteLine($"{uri.Host} was pinged and replied: {pingReply.Status}");

    if(pingReply.Status == IPStatus.Success)
    {
        WriteLine($"Replay from {pingReply.Address}, took {pingReply.RoundtripTime}");
    }

}
catch(Exception ex)
{
    WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
}


ReadLine();



