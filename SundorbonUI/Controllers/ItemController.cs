using DbExecutor;
using SecurityBLL;
using SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Sundorbon.UI.Controllers
{

    public class ItemController : Controller
    {
        public JsonResult GetAllItem()
        {

            try
            {
                var list = Facade.ItemBll.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ItemController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RequestionPurpose()
        {

            try
            {
                var list = Facade.ItemBll.GetAllPurpose();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ItemController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult ItemPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.ItemBll.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ItemController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetItemDynamic(string searchCriteria, string orderBy)
        {
            try
            {
                var list = Facade.ItemBll.GetDynamic(searchCriteria, orderBy);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ItemController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public int Save(ad_Item _ad_Item)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.ItemBll.Add(_ad_Item);



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

        [HttpPost]
        public int Delete(int CategoryId)
        {
            int ret = 0;
            //try
            //{
            //    ret = Facade.ItemCategory.Delete(CategoryId);
            //}
            //catch (Exception ex)
            //{
            //    error_Log error = new error_Log();
            //    error.ErrorSide = "Server";
            //    error.ErrorMessage = ex.Message;
            //    error.ErrorType = ex.GetType().ToString();
            //    error.FileName = "CategoryController";
            //    error.IpAddress = Session["IP"].ToString();
            //    error.UserId = Convert.ToInt32(Session["UserId"]);
            //   // new ErrorLogController().CreateErrorLog(error);
            //    return 0;
            //}
            return ret;
        }
    }
}