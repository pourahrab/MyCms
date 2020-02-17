using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {

        private MyCmsContex db;

        public PageCommentRepository(MyCmsContex contex)
        {
            db = contex;
        }
        public bool AddComment(PageComment comment)
        {
            try
            {
                db.pageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
          return db.pageComments.Where(p => p.PageID == pageId);
        }
    }
}
