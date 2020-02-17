using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {

       private MyCmsContex db;

        public PageRepository(MyCmsContex contex)
        {
            this.db = contex;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageById(int PageId)
        {
            return db.Pages.Find(PageId);
        }

        public bool InsertPage(Page Page)
        {
            try
            {
                db.Pages.Add(Page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdatePage(Page Page)
        {
            try
            {
                db.Entry(Page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(Page Page)
        {
            try
            {
                db.Entry(Page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(int PageId)
        {
            try
            {
                var Page = GetPageById(PageId);
                DeletePage(Page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
           return db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupId(int GroupID)
        {
            return db.Pages.Where(p => p.GroupID == GroupID);
        }

        public IEnumerable<Page> SearchPage(string search)
        {
          return  db.Pages.Where(s => s.Title.Contains(search) || s.ShortDescription.Contains(search) || s.Text.Contains(search) || s.Tags.Contains(search)  ).Distinct();
        }
    }
}
