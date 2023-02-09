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
    public class JobController : Controller
    {
        // GET: Job
        [HttpPost]
        public string Save(ws_Job _Job, List<ws_JobDetails> _JobDetails, List<ws_JobItemDetails> JobItem)
        {
            string ret = string.Empty;
            try
            {
                
                string Number = "";
                _Job.CreateDate = DateTime.Now;
                _Job.UpdateDate = DateTime.Now;

                ret = Facade.JobBLL.Add(_Job, _Job.transactionType);
                Number = ret;
                foreach (ws_JobDetails JobDetails in _JobDetails)
                {
                    if (JobDetails.JobNumber==null)
                    {
                        JobDetails.IsVoid = false;
                        JobDetails.JobNumber = ret;

                        Facade.JobDetailsBLL.Add(JobDetails, "INSERT");
                    }
                    else
                    {
                        Facade.JobDetailsBLL.Add(JobDetails, "Update");
                    }
                   
                }
                foreach (ws_JobItemDetails JobItemDetails in JobItem)
                {
                    if (JobItemDetails.JobNumber==null)
                    {
                        JobItemDetails.IsVoid = false;
                        JobItemDetails.JobNumber = ret;

                        Facade.JobItemDetailsBLL.Add(JobItemDetails, "INSERT");
                    }
                    else
                    {
                        Facade.JobItemDetailsBLL.Add(JobItemDetails, "Update");
                    }
                   
                }

            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                // new ErrorLogController().CreateErrorLog(error);
                return "";
            }
            return ret;
        }

        public JsonResult JobGetPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.JobBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "CreateDate", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllJob()
        {
            try
            {
                var jobList = Facade.JobBLL.GetAll();
                return Json(jobList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllPendingJob()
        {
            try
            {
                var jobList = Facade.JobBLL.GetAllPending();
                return Json(jobList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public string ApprovalUpdate(ws_Job _Job)
        {
            string Number = string.Empty;
            try
            {
                _Job.ApprovalStatusId = 1;
                Number = Facade.JobBLL.Add(_Job,"Update");
                return Number;
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return null;
            }
        }
        public JsonResult GetAllJobItem(string Number)
        {
            try
            {
                var jobList = Facade.JobBLL.GetAllJobItem(Number);
                return Json(jobList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult GetAllJobDetailsByJobNumber(string Number)
        {
            try
            {
                var JobDetails = Facade.JobDetailsBLL.GetAllByJobNumber(Number);
                return Json(JobDetails, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllJobItemDetailsByJobNumber(string Number)
        {
            try
            {
                var JobDetails = Facade.JobItemDetailsBLL.GetAllByJobNumber(Number);
                return Json(JobDetails, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "JobController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}