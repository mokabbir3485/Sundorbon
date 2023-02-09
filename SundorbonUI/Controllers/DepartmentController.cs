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
    public class DepartmentController : Controller
    {
        // GET: Department
        public JsonResult DepartmentPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.DepartmentBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
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
        public JsonResult GetAll()
        {

            try
            {
                var list = Facade.DepartmentBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DepartmentController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public int Save(ad_Depertment _ad_Depertment)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.DepartmentBLL.Add(_ad_Depertment);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "BranchController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }
    }
}