using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();

        PageGroup GetGroupById(int GroupId);

        bool InsertGroup(PageGroup pageGroup);

        bool UpdateGroup(PageGroup PageGroup);

        bool DeleteGroup(PageGroup PageGroup);

        bool DeleteGroup(int GroupId);

        void Save();

        IEnumerable<ShowGroupsViewModel> GetGroupForView();

    }
}
