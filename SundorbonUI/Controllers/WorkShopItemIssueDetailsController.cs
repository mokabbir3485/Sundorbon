using DbExecutor;
using SecurityBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sundorbon.UI.Controllers
{
    public class WorkShopItemIssueDetailsController : Controller
    {
        // GET: WorkShopItemIssueDetails
        public JsonResult GetAll(string Number)
        {

            try
            {
                var list = Facade.ws_IssueItemDetailsBLL.GetAll(Number);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "WorkShopItemIssueDetailsController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);

            }
        }
    }
}