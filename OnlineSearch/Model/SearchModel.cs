using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSearch.Model
{
    public class SearchModel
    {
        [Required]
        public string KeyWords { get; set; }

        [Required]
        public string Url { get; set; }

        public IEnumerable<int> SearchResult { get; set; }
    }
}