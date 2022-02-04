using System;
using System.Threading.Tasks;

namespace searchfight.Engines
{
    public class GoogleEngine : BaseEngine, ISearchEngine
    {
        /// <summary>
        /// Factory method, use google api to search word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Number of results</returns>
        public async Task<long> Search(string word)
        {   
            var key = GetSecretKey("google-key");
            var url = $"https://serpapi.com/search.json?engine=google&q={word}&api_key={key}";
            var result = await GetResponseAsync(url);
            return Convert.ToInt64(result["search_information"]["total_results"]);
        }
    }
}