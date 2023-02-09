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
    public class StoreRackController : Controller
    {
        // GET: StoreRackRack
        public JsonResult GetAll()
        {

            try
            {
                var list = Facade.StoreRackBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreRackController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetByStoreId(int Id)
        {

            try
            {
                var list = Facade.StoreRackBLL.GetByStoreId(Id);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreRackController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult StoreRackGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.StoreRackBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreRackController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult PurposeGetDynamic(string searchCriteria, string orderBy)
        //{
        //    try
        //    {
        //        var list = Facade.StoreRackBLL.GetDynamic(searchCriteria, orderBy);
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        error_Log error = new error_Log();
        //        error.ErrorMessage = ex.Message;
        //        error.ErrorType = ex.GetType().ToString();
        //        error.FileName = "StoreRackController";
        //        // new ErrorLogController().CreateErrorLog(error);
        //        return Json(null, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public int Save(ad_StoreRack _ad_StoreRack)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.StoreRackBLL.Add(_ad_StoreRack);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "StoreRackController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }

    }
}