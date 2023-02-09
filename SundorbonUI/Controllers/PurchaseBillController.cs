using DbExecutor;
using SecurityBLL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sundorbon.UI.Controllers
{
    public class PurchaseBillController : Controller
    {
        [HttpPost]
        public string Save(p_PurchaseBill _PurchaseBill, List<p_PurchaseBillDetails> _p_PurchaseBillDetails)
        {
            string ret = string.Empty;
            try
            {
                ret = Facade.p_PurchaseBillBLL.Add(_PurchaseBill);
              
                foreach (p_PurchaseBillDetails PBD in _p_PurchaseBillDetails)
                {
                    PBD.PuchaseBillNumber = ret;
                    Facade.p_PurchaseBillBLL.DetailAdd(PBD);
                }


            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseBillController";
                return "";
            }
            return ret;
        }


        public JsonResult PurchaseBillGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.p_PurchaseBillBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Number", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetByPurchaseBillNumber(string Number)
        {
            try
            {
                var list = Facade.p_PurchaseBillBLL.p_PurchaseBillDetails_GetBy_Number(Number);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult p_PurchaseBillDetails_GetBy_Report(string Number)
        {
            try
            {
                var list = Facade.p_PurchaseBillBLL.p_PurchaseBillDetails_GetBy_Report(Number);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult p_PurchaseBill_GetByIssue(DateTime ? fromdate=null,DateTime ? toDate=null)
        {
            try
            {
                var list = Facade.p_PurchaseBillBLL.p_PurchaseBill_GetByIssue(fromdate, toDate);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var list = Facade.p_PurchaseBillBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}