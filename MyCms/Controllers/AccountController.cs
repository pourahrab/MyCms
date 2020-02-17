using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCms.Controllers
{
    public class AccountController : Controller
    {
        ILoginRepository loginrepository;
        MyCmsContex db = new MyCmsContex();

        public AccountController()
        {
            loginrepository = new LoginRepository(db);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(LoginViewModel login,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {


                if (loginrepository.IsExist(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RemmemberMe);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربر یافت نشد");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}