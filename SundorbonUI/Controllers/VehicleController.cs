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
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public JsonResult GetAllActive()
        {

            try
            {
                var list = Facade.VehicleBLL.GetAllActive();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "VehicleController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult VehiclePaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.VehicleBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "VehicleController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetVehicleDynamic(string searchCriteria, string orderBy)
        {
            try
            {
                var list = Facade.VehicleBLL.GetDynamic(searchCriteria, orderBy);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "VehicleController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public int Save(ad_Vehicle _ad_Vehicle)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.VehicleBLL.Add(_ad_Vehicle);



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "VehicleController";
                // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }

        
    }
}