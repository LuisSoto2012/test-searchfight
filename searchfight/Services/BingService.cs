using searchfight.Engines;

namespace searchfight.Services
{
    public class BingService: SearchService
    {
        protected override string Name => "Bing";

        protected override ISearchEngine CreateEngine()
        {
            return new BingEngine();
        }
    }
}