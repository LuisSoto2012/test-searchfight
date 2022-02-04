using System;
using System.Threading.Tasks;

namespace searchfight.Engines
{
    public class BingEngine : BaseEngine, ISearchEngine
    {
        public async Task<long> Search(string word)
        {
            var key = GetSecretKey("bing-key");
            var url = $"https://api.bing.microsoft.com/v7.0/search?q={word}&customconfig=0";            
            AddHeader("Ocp-Apim-Subscription-Key", key);
            var result = await GetResponseAsync(url);
            return Convert.ToInt64(result["webPages"]?["totalEstimatedMatches"]);
        }
    }
}