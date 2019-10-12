using Microsoft.Extensions.DependencyInjection;

namespace NewsAPI.Extensions
{
    public static class ServiceExntesion
    {
        /// <summary>
        /// Add the NewsClient to your DI Container.
        /// </summary>
        /// <param name="APIKey">Your APiKey for Newsapi.org</param>
        /// <returns></returns>
        public static IServiceCollection UseNewsAPI(this IServiceCollection services, string APIKey) 
            => services.AddSingleton(new NewsClient(APIKey));
    }
}
