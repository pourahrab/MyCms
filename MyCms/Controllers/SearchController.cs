using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class SearchController : Controller
    {
        MyCmsContex db = new MyCmsContex();
       private IPageRepository pagerepository;

        public SearchController()
        {
            pagerepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(pagerepository.SearchPage(q));
        }
    }
}