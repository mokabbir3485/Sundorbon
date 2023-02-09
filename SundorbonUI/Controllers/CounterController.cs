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
    public class CounterController : Controller
    {
        // GET: Counter
        public JsonResult CounterPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.CounterBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CounterController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public int Save(ad_Counter _ad_Counter)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.CounterBLL.Add(_ad_Counter);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ItemController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }
        public JsonResult GetAll()
        {
            try
            {
                var list = Facade.CounterBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CounterController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllNoUsedCounter(int DeptId)
        {
            try
            {
                var list = Facade.CounterBLL.GetAllNotUsedCounter(DeptId);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CounterController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public int ChangeUsedStatus(int id,bool status)
        {
            try
            {
                var list = Facade.CounterBLL.ChangeUsedStatus(id, status);
                return list;
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CounterController";
                //   new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
        }
    }
}