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
    public class AdjustmentController : Controller
    {
        // GET: Adjustment
        public JsonResult AdjustmentPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.AdjustmentBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "CreationDate", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AdjustmentController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAll()
        {

            try
            {
                var list = Facade.AdjustmentBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AdjustmentController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public string Save(inv_Adjustment _Adjustment,List<inv_AdjustmentDetails> _Adjustment_Details_list, string transactiontionType)
        {
            string ret = string.Empty;
            try
            {
                ret = Facade.AdjustmentBLL.Add(_Adjustment, transactiontionType.ToUpper()); 

                if (_Adjustment_Details_list!=null)
                {
                    foreach (var item in _Adjustment_Details_list)
                    {
                        item.AdjustmentNumber = _Adjustment.Number;
                        Facade.AdjustmentDetailsBLL.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AdjustmentController";
                // new ErrorLogController().CreateErrorLog(error);
                return null;
            }
            return ret;
        }

        public JsonResult GetAllAdjustmentDetailsFromAdjustmentId(string Number)
        {

            try
            {
                var list = Facade.AdjustmentDetailsBLL.GetAllAdjustmentDetailsFromAdjustmentId(Number);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AdjustmentController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}