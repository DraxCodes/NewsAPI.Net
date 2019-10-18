<p align="center">
  <img src="docs/images/logo.png" />
</p>

## ℹ Add NewsAPI.Net to your project.

From the NUGET CLI

```cs
PM> Install-Package News.Net -Version 1.0.0
```

From the DotNet CLI

```cs
> dotnet add package News.Net --version 1.0.0
```

Or place this line in your `.csproj` & do a `dotnet restore`.

```cs
<PackageReference Include="News.Net" Version="1.0.0" />
```

## 🤔 How To Use

### Creating a request to send to the API.

```cs
//Generate a new AllNewsRequest. This is where you create your query for the API.
var request = new AllNewsRequest("Arrow", SortType.PublishedDate);

//You can also set date from and to if you so wish.
//This will fetch all news regarding Arrow that have been published in the last 7 days.
var request = new AllNewsRequest("Arrow", SortType.PublishedDate, DateTime.UtcNow.AddDays(-7));

//This will fetch all news regarding Arrow 
//This request exmample states that articles are to be:
//No older than 7 days and also ignore articles from the last 2 days.
//For example if it where 10/1/2019, this would be news articles from The 3/1/2019 to 8/1/2019 
var request = new AllNewsRequest("Arrow", SortType.PublishedDate, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow.AddDays(-2));
```

### Using those requests.
```cs
//Initialise a NewClient & pass in your APIKey
//Get the NewsClient from your IOC Container if you are using one.
var newsClient = new NewsClient("API_Key Here");

//Send the request you created (as shown above)
var result = await newsClient.FetchNewsAsync(request);

//You will now have a NewsResult, of which you will want to check the status.
//If the status has not shown OK, you handle it.
if (result.ResponseStatus != ResponseStatus.Ok)
{
    Console.WriteLine($"There seems to have been an error. {result.Error.ToString()}")
}

//Else you can use the result.Articles to access the article information.
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

### Getting top headline results for a desired source.

```cs
//as above, create your client or get it from your IOC Container.
//Use the NewsClient to send a request for the latest news from a desired source.
var result = await _newsClient.FetchNewsFromSource(NewsSource.BBC);

//You can also pass in an array of sources if you wish.
var sources = new NewsSource[] 
    { 
        NewsSource.ABCNews,
        NewsSource.BBC
    };

var result = await _newsClient.FetchNewsFromSource(sources);
```

While I do support a large amount of sources by default that are provided by the NewsApi.Org website. I **DO NOT** support them all. If you want to use a source I do not support, you are able to enter the source id like so. (Find the source ID's [Here](https://newsapi.org/docs/endpoints/sources))

```cs
var result = await _newsClient.FetchNewsFromSource("buzzfeed");
```

### The IServiceCollection extension method.

ℹ ***This is a simple way to add the service to your IOC Container.***
```cs
public class Foo
{
    public void SetupServices()
    {
        serviceCollection.UseNewsAPI("YOUR_API_KEY_HERE");
    }
}
```