using DbExecutor;
using SecurityBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sundorbon.UI.Controllers
{
    public class ItemReportsController : Controller
    {
        public JsonResult GetAllItem(int? ModelId, string GroupName)
        {
            if (GroupName=="null")
            {
                GroupName = null;
            }
            try
            {
                var list = Facade.ItemReportBll.GetAll(ModelId, GroupName);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ItemController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}