using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using BusinessLogic;
using System.DirectoryServices.AccountManagement;
using System.ComponentModel.DataAnnotations;
using System.Web.Routing;

namespace Accordian.Web.Controllers
{
    public class BaseController : Controller
    {
        public UserPrincipal CheckADUser(string adUserName)
        {
            UserPrincipal usr = null;
            if (adUserName != null )
            {
                usr = new ActiveDirectoryManager().GetUserDetails(adUserName);

                if (usr != null)
                {
                    var authTicket = new FormsAuthenticationTicket(
                          version: 1,
                          name: adUserName,
                          issueDate: DateTime.Now,
                          expiration: DateTime.Now.AddMinutes(10),
                          isPersistent: false,
                          userData: Convert.ToString(usr)
                      );

                    return usr;
                }
                else
                    return usr;
            }
            else
                return usr;
        }

        public user GetLoggedInUserDetails
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var obj = Request.Cookies["BHSI-AUTH-COOKIE"];
                    return new user() { EMAIL_ID = Convert.ToString("") };
                }
                else
                    return null;

            }
        }



        public user Usage
        {
            get
            {
                return new user { EMAIL_ID = "test@gamil.com" };
            }
        }

    }



    public class LoginViewModel
    {
        [Required, AllowHtml]
        public string Email { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}