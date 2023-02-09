using DbExecutor;
using SecurityBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XtrialEntity;

namespace Sundorbon.UI.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public JsonResult GetAll()
        {

            try
            {
                var list = Facade.StoreBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllRack()
        {

            try
            {
                var list = Facade.StoreBLL.GetAllRack();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult StoreGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.StoreBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult PurposeGetDynamic(string searchCriteria, string orderBy)
        //{
        //    try
        //    {
        //        var list = Facade.StoreBLL.GetDynamic(searchCriteria, orderBy);
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        error_Log error = new error_Log();
        //        error.ErrorMessage = ex.Message;
        //        error.ErrorType = ex.GetType().ToString();
        //        error.FileName = "StoreController";
        //        // new ErrorLogController().CreateErrorLog(error);
        //        return Json(null, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public int Save(ad_Store _ad_Store)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.StoreBLL.Add(_ad_Store);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }

    }
}