using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//add in viewmodels
using Assignment9.Models.ViewModels;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //added
        private IMovieRepository _repository;

        //items per page variable
        //public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        //pass page 1 as default page to display
        public IActionResult Index(string category, int pageNum = 1)
        {
            if (ModelState.IsValid)
            {
                //return #items per page with linq 
                return View(new MovieListViewModel
                {
                    Movies = _repository.Movies
                            //filter
                            //.Where(p => category == null || p.Category == category)
                            //.OrderBy(p => p.BookID)
                            //.Skip((pageNum - 1) * PageSize)
                            //.Take(PageSize)
                    //    ,
                    //PagingInfo = new PagingInfo
                    //{
                    //    CurrentPage = pageNum,
                    //    ItemsPerPage = PageSize,
                    //    TotalNumItems = category == null ? _repository.Books.Count() :
                    //        _repository.Books.Where(p => p.Category == category).Count()
                    //},
                    //CurrentCategory = category
                });
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
