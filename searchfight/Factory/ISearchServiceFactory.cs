using searchfight.Services;

namespace searchfight.Factory
{
    public interface ISearchServiceFactory
    {
        /// <summary>
        /// Get available search engine services
        /// </summary>
        /// <returns>List of available services</returns>
        SearchService[] GetServices();
        /// <summary>
        /// Get Final Winner after comparing results
        /// </summary>
        /// <param name="services"></param>
        /// <returns>Name of search engine winner</returns>
        string GetFinalWinner(SearchService[] services);
    }
}