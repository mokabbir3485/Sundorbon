using DbExecutor;
using SecurityBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sundorbon.UI.Controllers
{
    public class StoreIssueDetailController : Controller
    {
        // GET: StoreIssueDetail
        public JsonResult GetByStoreIssueNumber(string Number)
        {
            try
            {
                var list = Facade.inv_StoreIssueDetailsBLL.GetByStoreIssueNumber(Number);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreIssueDetailController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}