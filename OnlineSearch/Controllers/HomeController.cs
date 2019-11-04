using OnlineSearch.Model;
using OnlineSearch.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;

        public HomeController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new SearchModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SearchModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.SearchResult = await _searchService.SearchKeyWordAsync(model.KeyWords, model.Url);

            return View(model);
        }
    }
}