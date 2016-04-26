using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Index()
        {
            ViewData.Model = _dbContext.AccountBook.ToList();
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