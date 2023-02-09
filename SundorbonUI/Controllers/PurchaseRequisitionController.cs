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
    public class PurchaseRequisitionController : Controller
    {
        // GET: PurchaseRequisition
        [HttpPost]
        public string Save(inv_PurchaseRequisition _PurchaseRequisition, List<inv_PurchaseRequisitionDetails> _PurchaseRequisitionDetails)
        {
            string ret = string.Empty;
            try
            {
                string Number = "";
                _PurchaseRequisition.CreateDate = DateTime.Now;
                _PurchaseRequisition.UpdateDate = DateTime.Now;
                _PurchaseRequisition.Status = "";
                ret = Facade.PurchaseRequisitionBLL.Add(_PurchaseRequisition);
                Number = ret;
                foreach (inv_PurchaseRequisitionDetails PurchaseReq in _PurchaseRequisitionDetails)
                {
                    PurchaseReq.IsVoid = false;
                    PurchaseReq.PurchaseRequisitionNumber = ret;

                    Facade.PurchaseRequisitionDetailsBLL.Add(PurchaseReq);
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
        public JsonResult PurchaseRequestionGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.PurchaseRequisitionBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Number", "DESC", ref rows),
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
        public JsonResult PurchaseRequestionDetailsGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.PurchaseRequisitionBLL.GetDetailsPaged(startRecordNo, rowPerPage, whereClause, "Id", "DESC", ref rows),
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

        public JsonResult GetAllNumber()
        {

            try
            {
                var list = Facade.PurchaseRequisitionBLL.GetAllNumber();
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
                var list = Facade.PurchaseRequisitionBLL.GetByPurchaseRequisitionNumber(Number);
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
                var list = Facade.PurchaseRequisitionBLL.GetByPurchaseRequisitionReport(Number);
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
        public JsonResult GetAllAmendAndRequisition(string Number, string FromDate, string ToDate)
        {
            try
            {
                DateTime? fromDate = null;
                DateTime? toDate = null;
                if (FromDate != "Not Defined")
                {
                    fromDate = DateTime.Parse(FromDate);
                    toDate = DateTime.Parse(ToDate);
                }

                var list = Facade.PurchaseRequisitionBLL.GetAllAmendAndRequisition(Number, fromDate, toDate);
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
    }
}