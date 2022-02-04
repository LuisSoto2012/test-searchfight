using searchfight.Engines;

namespace searchfight.Services
{
    public class GoogleService: SearchService
    {
        protected override string Name => "Google";

        protected override ISearchEngine CreateEngine()
        {
            return new GoogleEngine();
        }
    }
}