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

    public class EmployeeController : Controller
    {
        public JsonResult GetAllEmployee()
        {

            try
            {
                var list = Facade.EmployeeBll.GetAll();
              
              
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "EmployeeController";
                //   new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        

     
        public JsonResult EmployeePaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.EmployeeBll.GetPaged(startRecordNo, rowPerPage, whereClause, "[E].[EmployeeId]", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "EmployeeController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmployeeDynamic(string searchCriteria, string orderBy)
        {
            try
            {
                var list = Facade.EmployeeBll.GetDynamic(searchCriteria, orderBy);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "EmployeeController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public int Save(ad_Employee _ad_Employee, s_User user)
        {
            int ret = 0;
            try
            {
                //  string myGroupName = _ItemGroup.GroupName;

                ret = Facade.EmployeeBll.Add(_ad_Employee);

                if (user !=null)
                {
                    if (user.UserId==0)
                    {
                        user.EmployeeId = ret;
                        ret = Facade.User.Add(user);
                    }
                    else
                    {
                        user.EmployeeId = ret;
                        ret = Facade.User.Update(user);
                    }
                   
                }



            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "EmployeeController";
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