using Accordian.Web.Controllers;
using BusinessLogic;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static BusinessLogic.Attributes;

namespace Accordian.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleAndLogErrorAttribute());
            filters.Add(new CustomActionFilterAttribute());
        }

        public class HandleAndLogErrorAttribute : HandleErrorAttribute
        {
            //private readonly CommonRepository _objCommon = new CommonRepository();

            public override void OnException(ExceptionContext filterContext)
            {

                using (var _objCommon = new BHSIDBEntities())
                {
                    if (filterContext.ExceptionHandled)
                        return;

                    var eno = _objCommon.LogError(filterContext.Exception);
                    filterContext.ExceptionHandled = true;

                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                        filterContext.Result = new JsonResult { Data = new { status = false, message = string.Format("Unexpected Error # {0}", eno) } };

                    else if (filterContext.RequestContext.HttpContext.Request.Headers["IsAngularRequest"] == "true")
                        filterContext.Result = new JsonResult { Data = new { status = false, message = string.Format("Unexpected # {0}", eno) } };

                    else filterContext.Result = new ViewResult { ViewName = "_Error" };


                    #region DbEntityValidationException
                    /*
                    catch (DbEntityValidationException e)
                    {
                        var errorList = new List<string>();
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            errorList.Add(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                            foreach (var ve in eve.ValidationErrors)
                            {
                                errorList.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                            }
                        }
                        throw;
                    }                
                    */
                    #endregion
                }

            }
        }

        public class CustomActionFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.Controller.GetType().IsSubclassOf(typeof(BaseController)))
                {
                    if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipUsageLogAttribute), false).Length == 0)
                    {
                        var controller = ((BaseController)filterContext.Controller);
                        var user = controller.GetLoggedInUserDetails;
                        controller.ViewBag.LoggedInUser = user;

                        using (var _objCommon = new BHSIDBEntities())
                        {
                            var usage = controller.Usage;
                            usage.EMAIL_ID = (user == null) ? "" : user.EMAIL_ID;
                            _objCommon.LogSummery(usage);
                        }
                    }
                }

                base.OnActionExecuting(filterContext);
            }
        }
    }
}
