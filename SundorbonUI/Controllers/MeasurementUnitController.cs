﻿using DbExecutor;
using SecurityBLL;
using SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sundorbon.Backend.SECURITY.SecurityEntity;
namespace Sundorbon.UI.Controllers
{
  
    public class MeasurementUnitController : Controller
    {
        public JsonResult GetAll()
        {

            try
            {
                var list = Facade.MeasurementUnitBLL.GetAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CategoryController";
             //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult MeasurementUnitPaged(int startRecordNo, int rowPerPage, string whereClause,int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.MeasurementUnitBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "ASC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CategoryController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCategoryDynamic(string searchCriteria, string orderBy)
        {
            try
            {
                var list = Facade.MeasurementUnitBLL.GetDynamic(searchCriteria, orderBy);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CategoryController";
               // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public int Save(ad_MeasurementUnit _MeasurementUnit)
        {
            int ret = 0;
            try
            {
              //  string myGroupName = _ItemGroup.GroupName;

               ret = Facade.MeasurementUnitBLL.Add(_MeasurementUnit);

 

            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "CategoryController";
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