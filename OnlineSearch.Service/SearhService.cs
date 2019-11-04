using OnlineSearch.Service.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineSearch.Service
{
    public class SearhService : ISearchService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://www.google.com.au/search?q={0}&num=100";

        public SearhService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<int>> SearchKeyWordAsync(string keyWord, string Url)
        {
            // Create search endpoint
            var requestUrl = string.Format(BaseUrl, keyWord);

            var response = await _client.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();
                
            return FindOccurences(content, Url);
        }

        /// <summary>
        /// Find occurences of the URL in the HTML content
        /// </summary>
        /// <param name="content">The HTML content</param>
        /// <param name="url">The URL to match</param>
        /// <returns>A list of indexes that the given URL appears in the search result</returns>
        private IEnumerable<int> FindOccurences(string content, string url)
        {
            var result = new List<int>();
            var regex = new Regex("<cite.*?cite>");

            // Get all the result URLs on the screen
            var matches = regex.Matches(content);

            for (var i = 0; i < matches.Count; i++)
            {
                if (matches[i].Value.Contains(url))
                {
                    result.Add(i+1);
                }
            }

            return result;
        }
    }
}
