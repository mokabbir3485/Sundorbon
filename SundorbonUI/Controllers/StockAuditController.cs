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
    public class StockAuditController : Controller
    {
        // GET: StockAudit
       public JsonResult StockAuditPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.StockAuditBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "CreationDate", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StockAuditController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAll()
        {

            try
            {
                var list = Facade.StockAuditBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StockAuditController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public string Save(inv_StockAudit _StockAudit,List<inv_StockAuditDetails> _StockAudit_Details_list,string transactionType)
        {
            string ret = string.Empty;
            try
            {
                if (transactionType=="INSERT")
                {
                    string IdPrefix = ConfigurationManager.AppSettings["St-Counter-PC1"].ToString();
                    _StockAudit.Id = IdPrefix;
                }
                ret = Facade.StockAuditBLL.Add(_StockAudit, transactionType); 

                if (_StockAudit_Details_list!=null)
                {
                    foreach (var item in _StockAudit_Details_list)
                    {
                        item.StockAuditId = ret;
                        Facade.StockAuditDetailsBLL.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StockAuditController";
                // new ErrorLogController().CreateErrorLog(error);
                return null;
            }
            return ret;
        }

        public JsonResult GetAllStockAuditDetailsFromStockAuditId(string Id)
        {

            try
            {
                var list = Facade.StockAuditDetailsBLL.GetAllStockAuditDetailsFromStockAuditId(Id);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StockAuditController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}