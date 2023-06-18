using System;
using System.Net;
using System.Web;

class CSharpExample
{
    private static string API_KEY = "YOUR_API_KEY";

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(makeAPICall()); // Calling the function to make an API call
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message); // Handling and displaying the error message in case of a WebException
        }
    }

    // Function to make an API call and retrieve the information
    static string makeAPICall()
    {
        var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest"); // Coinmarketcap API URL

        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["start"] = "1";
        queryString["limit"] = "5000";
        queryString["convert"] = "USD";

        URL.Query = queryString.ToString();

        var client = new WebClient();
        client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY); // Adding the API key to the request headers
        client.Headers.Add("Accepts", "application/json");
        return client.DownloadString(URL.ToString()); // Making the API call and returning the response
    }
}
