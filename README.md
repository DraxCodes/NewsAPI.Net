<p align="center">
  <img src="docs/images/logo.png" />
</p>

## 🤔 How To Use

The very basic of usuage could be as follows.

```cs
//Initialise a NewClient & pass in your APIKey
var newsClient = new NewsClient("API_Key Here");

//Generate a new NewsRequest. This is where you create your query for the API.
var request = new NewsRequest(RequestType.Everything, "Arrow", SortType.PublishedDate);

//Send the request (this return a NewsResult)
var result = await newsClient.FetchNews(request);

//You will now have a result, of which you will want to check the status.
if (result.ResponseStatus != ResponseStatus.Ok)
{
    Console.WriteLine($"There seems to have been an error. {result.Error.ToString()}")
}
else
{
    foreach (var article in result.Articles)
    {
        Console.WriteLine(article.Title);
        Console.WriteLine(article.Description);
        Console.WriteLine(article.Author);
        Console.WriteLine(article.Source.Name);
    }
}
```

You are also able to pass the client into a Dependency Injection container. Currently the only way to do this is to simply create an instance of the NewsClient and pass that instance into your DI container. After which you would be able to request it, using something such as constructor injection, by requesting a `NewsClient`.

Example ***(Note: this will soon be depricated in favor of an Extension method on the IServiceProvider).***

```cs
public class Foo
{
    private NewsClient _newsClient;

    public Foo()
    {
        _newsClient = new NewsClient("API_KEY_HERE");
    }

    public void SetupServices()
    {
        services.AddSingleton(_newsClient);
    }
}