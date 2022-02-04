using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace searchfight.Engines
{
    /// <summary>
    /// Base class that contains http connection to external APIs
    /// </summary>
    
    public class BaseEngine
    {
        private readonly HttpClient _httpClient;
        
        public BaseEngine()
        {
            _httpClient = new HttpClient();
        }
        public void AddHeader(string key, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(key, value);
        }
        public async Task<JObject> GetResponseAsync(string url)
        {
            try
            {
                var data = await _httpClient.GetStringAsync(url);                
                return JObject.Parse(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public string GetSecretKey(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config.GetSection("engines").GetSection(key).Value;
        }
    }
}