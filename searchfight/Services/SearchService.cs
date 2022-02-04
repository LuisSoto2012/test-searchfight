using searchfight.Engines;

namespace searchfight.Services
{
    public abstract class SearchService
    {
        protected abstract ISearchEngine CreateEngine();
        
        protected abstract string Name { get; }

        private string _winner = "No results";

        private long _winnerResults = 0;

        public string GetWinner()
        {
            return _winner;
        }

        public string WinnerToString()
        {
            // Print result
            return $"{Name} winner : {_winner}";
        }

        public string GetResults(string word)
        {
            // Instance engine
            var engine = CreateEngine();
            // Call Search method
            var results = engine.Search(word).Result;
            // Set winner value
            SetWinner(word, results);
            // Print result
            return $"{Name} : {results}";
        }

        private void SetWinner(string word, long results)
        {
            // Set new winner and score
            if (results <= _winnerResults) return;
            _winner = word;
            _winnerResults = results;
        }
    }
}