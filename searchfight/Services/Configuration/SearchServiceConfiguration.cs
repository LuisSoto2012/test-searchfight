using System.Collections.Generic;
using System.Linq;
using searchfight.Factory;

namespace searchfight.Services.Configuration
{
    public class SearchServiceConfiguration : ISearchServiceFactory
    {        
        public SearchService[] GetServices()
        {
            // create objects (services) under factory pattern
            return new SearchService[] {
                new GoogleService(),
                new BingService()
            };
        }

        public string GetFinalWinner(SearchService[] services)
        {
            // get list
            var winners = services.Select(service => service.GetWinner()).ToList();
            // return first element after ordering by descending
            return winners.GroupBy(w => w).OrderByDescending(w => w.Count()).First().Key;
        }
    }
}