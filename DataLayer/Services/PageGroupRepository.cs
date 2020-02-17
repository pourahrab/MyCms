using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContex db;

        public PageGroupRepository(MyCmsContex contex)
        {
            this.db = contex;
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
           return db.PageGroups;
        }

        public PageGroup GetGroupById(int GroupId)
        {
            return db.PageGroups.Find(GroupId);
        }

        public bool InsertGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool UpdateGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroup(int GroupId)
        {
            try
            {
                var Group = GetGroupById(GroupId);
                
                DeleteGroup(Group);
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

        public IEnumerable<ShowGroupsViewModel> GetGroupForView()
        {
           return db.PageGroups.Select(g => new ShowGroupsViewModel
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count
            });
        }
    }
}
