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
    public class StoreItemReciveController : Controller
    {
        // GET: StoreItemRecive
        public JsonResult StoreReceiveGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.inv_StoreItemReciveBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Number", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreItemReciveController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public string Save(inv_StoreItemReceive _StoreItemReceive, List<inv_StoreItemReceiveDetail> _inv_StoreItemReceiveDetail)
        {
            string ret = string.Empty;
            try
            {
                _StoreItemReceive.StockReceiveDate = DateTime.Now;
                 ret = Facade.inv_StoreItemReciveBLL.Add(_StoreItemReceive);
              
                foreach (inv_StoreItemReceiveDetail _StoreItemReceiveDetail in _inv_StoreItemReceiveDetail)
                {
                    _StoreItemReceiveDetail.StoreReceiveNumber = ret;
                    Facade.inv_StoreItemReciveBLL.DetailPost(_StoreItemReceiveDetail);
                }


            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreItemReciveController";
                // new ErrorLogController().CreateErrorLog(error);
                return "";
            }
            return ret;
        }

        [HttpGet]
        public JsonResult StoreReciveDetails_GetBy_Number(string Number)
        {
            try
            {
                var list = Facade.inv_StoreItemReciveBLL.StoreReciveDetails_GetBy_Number(Number);
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