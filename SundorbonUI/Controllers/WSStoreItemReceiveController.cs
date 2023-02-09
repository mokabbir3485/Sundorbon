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
    public class WSStoreItemReceiveController : Controller
    {
        // GET: WSStoreItemReceive
        [HttpPost]
        public string Save(ws_StoreItemReceive _StoreItemReceive, List<ws_StoreItemReceiveDetails> _inv_StoreItemReceiveDetail)
        {
            string ret = "";
            try
            {
                _StoreItemReceive.CreateDate = DateTime.Now;
                _StoreItemReceive.UpdateDate = DateTime.Now;
                _StoreItemReceive.ReceiveDate = DateTime.Now;
                _StoreItemReceive.ApprovalStatusId = 2;
                ret = Facade.ws_StoreItemReceiveBLL.Add(_StoreItemReceive);

                foreach (ws_StoreItemReceiveDetails StoreItemReceiveDetails in _inv_StoreItemReceiveDetail)
                {

                    StoreItemReceiveDetails.StoreReceiveNumber = ret;
                    Facade.ws_StoreItemReceiveDetailsBLL.Add(StoreItemReceiveDetails);
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
        public JsonResult StoreItemPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.ws_StoreItemReceiveBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Number", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "VehicleGroupController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult StoreItemDetailsGetAll(string Number)
        {
            try
            {
                var ListData = Facade.ws_StoreItemReceiveBLL.GetAll(Number);
                return Json(ListData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "VehicleGroupController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}