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
    public class WorkShopRequestionController : Controller
    {
        // GET: WorkShopRequestion
        [HttpPost]
        public string Save(ws_Requestion _ws_Requestion, List<ws_RequestionSlipDetails> _ws_RequestionSlipDetails)
        {
            string ret = "";
            try
            {
                ret = Facade.ws_RequestionBLL.Add(_ws_Requestion);
               
                foreach (ws_RequestionSlipDetails PurchaseReq in _ws_RequestionSlipDetails)
                {

                    PurchaseReq.RequistionSlipNumber = ret;
                    Facade.ws_RequestionBLL.AddDetail(PurchaseReq);
                }


            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                // new ErrorLogController().CreateErrorLog(error);
                return "";
            }
            return ret;
        }
        //ad_Counter_GetAll
        public JsonResult WSRequestionGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.ws_RequestionBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Number", "DESC", ref rows),
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
      


        public JsonResult GetAllCounter()
        {

            try
            {
                var list = Facade.PurchaseRequisitionBLL.GetAllCounter();
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


        public JsonResult GetByPurchaseRequisitionNumber(string Number)
        {

            try
            {
                var list = Facade.ws_RequestionBLL.GetByWSRequisitionNumber(Number);
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

        public JsonResult GetByPurchaseRequisitionReport(string Number)
        {

            try
            {
                var list = Facade.ws_RequestionBLL.GetByWSRequisitionReport(Number);
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
        public JsonResult GetAllRequisitionSlip()
        {

            try
            {
                var list = Facade.ws_RequestionBLL.GetAllRequisitionSlip();
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
        public JsonResult GetAllPurchaseRequestion()
        {

            try
            {
                var list = Facade.PurchaseRequisitionBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult ws_RequistionSlip_GetByIssue(DateTime? fromdate = null, DateTime? toDate = null)
        {
            try
            {
                var list = Facade.ws_RequestionBLL.ws_RequistionSlip_GetByIssue(fromdate, toDate);
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