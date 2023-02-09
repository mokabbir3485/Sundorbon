using DbExecutor;
using SecurityBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XtrialEntity;

namespace Sundorbon.UI.Controllers
{
    public class RecordSerialController : Controller
    {
        // GET: RecordSerial
        public JsonResult RecordSerialPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.RecordSerialBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ad_RecordSerialController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public int Save(ad_RecordSerial _ad_RecordSerial)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.RecordSerialBLL.Add(_ad_RecordSerial);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ad_RecordSerialController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }

    }
}
