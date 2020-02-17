using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {
        MyCmsContex db = new MyCmsContex();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;
        // GET: News

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupForView());
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        public ActionResult LatestNews()
        {
            return PartialView(pageRepository.LastNews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPage());
        }



        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupID(int id , string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }



        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var News = pageRepository.GetPageById(id);

            if (News == null)
            {
                return HttpNotFound();
            }

            News.Visit += 1;
            pageRepository.UpdatePage(News);
            pageRepository.Save();

            return View(News);
        }

        public ActionResult AddComment(int id,string name, string email,string comment)
        {
            PageComment addcomment = new PageComment()
            {
                Comment = comment,
                CreateDate = DateTime.Now,
                Email = email,
                Name = name,
                PageID=id                          
            };
            pageCommentRepository.AddComment(addcomment);
            return PartialView("ShowComments",pageCommentRepository.GetCommentByNewsId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsId(id));
        }
     
    }
}