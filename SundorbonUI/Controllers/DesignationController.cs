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
    public class DesignationController : Controller
    {
        // GET: Designation
        public JsonResult GetAllDesignation()
        {
            try
            {
                var designationList = Facade.Designation.GetAll();
                return Json(designationList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
             //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllSection()
        {
            try
            {
                var SectionList = Facade.Designation.GetAllSection();
                return Json(SectionList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        

        public JsonResult GetDesignationPaged(int StartRecordNo, int RowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.Designation.GetPaged(StartRecordNo, RowPerPage, whereClause, "DN.[DesignationId]", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
             //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetGradeGetPaged(int StartRecordNo, int RowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.Designation.GradeGetPaged(StartRecordNo, RowPerPage, whereClause, "Id", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult SectionGetPaged(int StartRecordNo, int RowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.Designation.SectionGetPaged(StartRecordNo, RowPerPage, whereClause, "S.Id", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetDesignationDynamic(string searchCriteria, string orderBy)
        {
            try
            {
                var list = Facade.Designation.GetDynamic(searchCriteria, orderBy);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
               // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllByDepartmentId(int departmentId)
        {
            try
            {
                var list = Facade.Designation.GetAllByDepartmentId(departmentId);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
              //  new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllActiveByDepartmentId(int departmentId)
        {
            try
            {
                var list = Facade.Designation.GetAllActiveByDepartmentId(departmentId);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
               // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public int Save(ad_Designation _ad_Designation)
        {
            int ret = 0;
            if (_ad_Designation.ContactNo == null)
                 _ad_Designation.ContactNo = "";

            try
            {
                if (_ad_Designation.DesignationId == 0)
                {
                    ret = Facade.Designation.Add(_ad_Designation);
                }
                else
                {
                    ret = Facade.Designation.Update(_ad_Designation);
                }
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
               // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }


        [HttpPost]
        public int GradeSave(ad_Grade _ad_Grade)
        {
            int ret = 0;
          
            try
            {
             ret = Facade.Designation.GradeSave(_ad_Grade);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
                return 0;
            }
            return ret;
        }

        [HttpPost]
        public int SaveSection(ad_Section _ad_Section)
        {
            int ret = 0;
            try
            {
                ret = Facade.Designation.SaveSection(_ad_Section);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
                return 0;
            }
            return ret;
        }
        [HttpPost]
        public int Delete(int DesignationId)
        {
            int ret = 0;
            try
            {
                ret = Facade.Designation.Delete(DesignationId);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "DesignationController";
               // new ErrorLogController().CreateErrorLog(error);
                return 0;
            }
            return ret;
        }
    }
}