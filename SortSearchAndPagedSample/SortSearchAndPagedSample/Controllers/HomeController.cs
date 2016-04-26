using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SortSearchAndPagedSample.Models;

namespace SortSearchAndPagedSample.Controllers
{
    public class HomeController : Controller
    {
        private Model1 _dbContext;

        public HomeController()
        {
            _dbContext = new Model1();
        }

        public ActionResult Index(int? page)
        {
            //分頁套件： Install-Package PagedList.Mvc 
            var pageIndex = page.HasValue ? page.Value < 1 ? 1 : page.Value : 1;
            var pageSize = 10;

            //為了範例最簡化，因此直接在 Controller 操作 DB ，實務上請盡量避免
            ViewData.Model = _dbContext.AccountBook
                .OrderByDescending(d => d.Dateee) //分頁前需先排序
                .ToPagedList(pageIndex, pageSize);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}