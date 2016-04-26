using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
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

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="q">搜尋字串</param>
        /// <param name="column">搜尋欄位名稱 預設為 Dateee</param>
        /// <param name="order">排序方向 預設為 Ascending</param>
        /// <returns></returns>
        public ActionResult Index(int? page, string q, string column = "Dateee", EnumSort order = EnumSort.Ascending)
        {
            //分頁套件： Install-Package PagedList.Mvc 
            var pageIndex = page.HasValue ? page.Value < 1 ? 1 : page.Value : 1;
            var pageSize = 2;

            //為了範例最簡化，因此直接在 Controller 操作 DB ，實務上請盡量避免
            var source = _dbContext.AccountBook.AsQueryable();

            if (string.IsNullOrWhiteSpace(q) == false)
            {
                // 只是單純示範搜尋條件應該如何累加
                var category = Convert.ToInt32(q);
                source = source.Where(d => d.Categoryyy == category);
            }

            var result = new QueryOption<AccountBook>
            {
                Order = order,
                Column = column,
                Page = pageIndex,
                PageSize = pageSize,
                Keyword = q
            };
            //利用 SetSource 將資料塞入（塞進去之前不能將資料讀出來）
            result.SetSource(source);
            ViewData.Model = result;
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