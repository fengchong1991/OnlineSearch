using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSearch.Service.Interface
{
    public interface ISearchService
    {
        /// <summary>
        /// Search the keyword in google and find the indexes of the URL
        /// </summary>
        /// <param name="keyWord">The keyword to search in Google</param>
        /// <param name="Url">The URL to match</param>
        /// <returns>A list of indexes that the given URL appears in the search result</returns>
        Task<IEnumerable<int>> SearchKeyWordAsync(string keyWord, string Url);
    }
}
