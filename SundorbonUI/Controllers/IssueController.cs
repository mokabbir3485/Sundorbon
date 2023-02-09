using DbExecutor;
using SecurityBLL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sundorbon.UI.Controllers
{
    public class IssueController : Controller
    {
        [HttpPost]
        public string Save(inv_StoreIssue _StoreIssue, List<inv_StoreIssueDetail> _StoreIssueDetails)
        {
            string ret = string.Empty;
            try
            {
                ret = Facade.inv_IssueBLL.AddStoreIssue(_StoreIssue);
                foreach (inv_StoreIssueDetail IssueDetail in _StoreIssueDetails)
                {
                    IssueDetail.IssueNumber = ret;
                    Facade.inv_IssueBLL.AddStoreIssueDetail(IssueDetail);
                }


            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "IssueController";
                // new ErrorLogController().CreateErrorLog(error);
                return "";
            }
            return ret;
        }

        public JsonResult IssuedGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.inv_IssueBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "IssueNo", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "IssueController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult StoreIssueDetails_Reports(string Number)
        {
            try
            {
                var list = Facade.inv_IssueBLL.xrpt_inv_StoreIssueDetails(Number);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreItemReciveController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}