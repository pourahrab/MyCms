using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        MyCmsContex db = new MyCmsContex();

        public LoginRepository(MyCmsContex contex)
        {
            db = contex;
        }
        public bool IsExist(string UserName, string PassWord)
        {
            return db.adminLogin.Any(u => u.UserName == UserName && u.Password == PassWord);
        }
    }
}
