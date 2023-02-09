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
    public class RequisitionTypeController : Controller
    {
        // GET: RequisitionType
        public JsonResult RequisitionTypeGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.RequisitionTypeBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "RequisitionTypeController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RequisitionTypeDynamic(string searchCriteria, string orderBy)
        {
            try
            {
                var list = Facade.RequisitionTypeBLL.GetDynamic(searchCriteria, orderBy);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "RequisitionTypeController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetAll()
        {
            try
            {
                var list = Facade.RequisitionTypeBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "RequisitionTypeController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public int Save(ad_RequistionType _ad_RequistionType)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.RequisitionTypeBLL.Add(_ad_RequistionType);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "RequisitionTypeController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }

    }
}