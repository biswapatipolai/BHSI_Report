using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using System.ComponentModel.DataAnnotations;

namespace Accordian.Web.Controllers
{
    public class HomeController : BaseController
    {

        BusinessLogic.BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic.BusinessLogic();
        public ActionResult Index()
        {
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

        public  ActionResult Login()
        {
            return View();
        }
      

        [HttpPost]
        public ActionResult LoginSubmit(UserModel usr)
        {
            BaseController bl = new BaseController();
            var userobj = bl.CheckADUser(usr.Email);
            if (userobj!=null)
            {
                Session["BSHI-AUTH-COOKIE"] = new UserModel() { EmpId = userobj.EmployeeId,  Email = userobj.EmailAddress, Name = userobj.Name };
                return View("Index");
            }
            else
                return View("Login");
        }
    }
}

public class UserModel
{
    public string EmpId { get; set; }

    [Required(ErrorMessage = "Please Enter Valid Email Id")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please Enter Valid Password")]
    public string Password { get; set; }

    public string Name { get; set; }


}