using System.Threading.Tasks;

namespace searchfight.Engines
{
    public interface ISearchEngine
    {
        /// <summary>
        /// Search word in the specific search engine
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Number of results</returns>
        Task<long> Search(string word);
    }
}