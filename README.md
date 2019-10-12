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

You can also add the NewsClient easily to your Dependency Injection Container using the following extension method.

ℹ ***Please Note that is is an extension method upon the type IServiceCollection***
```cs
public class Foo
{
    public void SetupServices()
    {
        serviceCollection.UseNewsAPI("YOU_API_KEY_HERE");
    }
}
```