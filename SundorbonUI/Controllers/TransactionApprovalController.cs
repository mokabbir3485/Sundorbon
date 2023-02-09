using DbExecutor;
using SecurityBLL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XtrialEntity;

namespace Sundorbon.UI.Controllers
{
    public class TransactionApprovalController : Controller
    {
        // GET: TransactionApproval
        public JsonResult TransactionApprovalPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.TransactionApprovalBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "TransactionApprovalController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public int Save(ad_TransactionApproval _ad_TransactionApproval)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.TransactionApprovalBLL.Add(_ad_TransactionApproval);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "TransactionApprovalController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }
        public JsonResult GetTableName(string Status ,string FromDate, string ToDate)
        {
            try
            {
                //DateTime fromDate = new DateTime();
                //DateTime toDate = new DateTime();
                //if (!DateTime.TryParse(FromDate, out fromDate))
                //{
                //    fromDate = DateTime.Parse("01/01/2022");
                //}
                //if (!DateTime.TryParse(ToDate, out toDate))
                //{
                //    toDate = DateTime.Now;
                //}
                DateTime? fromDate = null;
                DateTime? toDate = null;
                if (FromDate != null && FromDate != "Nodate")
                {
                    var NewfromDate = DateTime.Parse(FromDate);
                    fromDate = NewfromDate.Date;
                }
                if (ToDate != null && ToDate != "Nodate")
                {
                    var NewtoDate = DateTime.Parse(ToDate);
                    toDate = NewtoDate.Date;
                }
                var  ret = Facade.TransactionApprovalBLL.GetTableName(Status, fromDate, toDate);
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "TransactionApprovalController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}