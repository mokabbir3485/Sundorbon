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
    public class AmmendmentController : Controller
    {
        [HttpPost]
        public int Save(inv_Ammendment _Ammendment, List<inv_AmmendmentDetails> _inv_AmmendmentDetails)
        {
            int ret = 0;
            try
            {
                //====For PR=====
                if (_Ammendment.ApprovalGivenOnId == 12)
                {
                    //===Get Data===
                    var requisition = Facade.PurchaseRequisitionBLL.GetByNumber(_Ammendment.ReferenceTransactionNumber).FirstOrDefault();
                    var requisitionDetails = Facade.PurchaseRequisitionBLL.GetByRequisitionNumber(requisition.Number);

                    //=====Insert Into Log========
                    requisition.TransactiontionType = "INSERT";
                    var logId = Facade.PurchaseRequisitionBLL.AddIntoReuisitionLog(requisition);
                    foreach (var item in requisitionDetails)
                    {
                        var detailLog = Facade.PurchaseRequisitionDetailsBLL.AddIntoPurchaseRequisitionDetailsLog(item, "INSERT");
                    }

                    //=====Update========
                    requisition.ApprovalStatusId = 14;
                    requisition.TransactiontionType = "UPDATE";
                    Facade.PurchaseRequisitionBLL.Add(requisition);

                    foreach (var item in _inv_AmmendmentDetails)
                    {
                        var UpdatedRequisitionDetails = requisitionDetails.Where(x => x.Id == item.DetailId).FirstOrDefault();
                        if (UpdatedRequisitionDetails != null)
                        {
                            UpdatedRequisitionDetails.RequestedQty = item.AmendedQuantity;
                            Facade.PurchaseRequisitionDetailsBLL.Add(UpdatedRequisitionDetails);
                        }
                    }

                }

                //====For PB=====
                if (_Ammendment.ApprovalGivenOnId == 1)
                {
                    //===Get Data===
                    var bill = Facade.p_PurchaseBillBLL.Get(_Ammendment.ReferenceTransactionNumber).FirstOrDefault();
                    var billDetails = Facade.p_PurchaseBillBLL.p_PurchaseBillDetails_GetBy_Number(bill.Number);

                    //===Update into log====
                    bill.TransactionType = "INSERT";
                    Facade.p_PurchaseBillBLL.AddIntoLog(bill);
                    foreach (var item in billDetails)
                    {
                        Facade.p_PurchaseBillBLL.DetailLogAdd(item, "INSERT");
                    }

                    //=====Update========
                    bill.ApprovalStatusId = 14;
                    bill.TransactionType = "UPDATE";
                    Facade.p_PurchaseBillBLL.Add(bill);

                    foreach (var item in _inv_AmmendmentDetails)
                    {
                        var UpdatedBillDetails = billDetails.Where(x => x.Id == item.DetailId).FirstOrDefault();
                        if (UpdatedBillDetails != null)
                        {
                            UpdatedBillDetails.AIT = item.AIT;
                            UpdatedBillDetails.Amount = item.AmendedPrice;
                            UpdatedBillDetails.SD = item.SD;
                            UpdatedBillDetails.VAT = item.Vat;
                            UpdatedBillDetails.Qty = item.AmendedQuantity;
                            Facade.p_PurchaseBillBLL.DetailAdd(UpdatedBillDetails);
                        }
                    }
                }



                //=====Insert Into Amendment=========
                ret = Facade.PurchaseRequisitionBLL.Add(_Ammendment);

                foreach (inv_AmmendmentDetails ammentDetail in _inv_AmmendmentDetails)
                {

                    if (ammentDetail.Remarks == null)
                    {
                        ammentDetail.Remarks = "NA";
                    }
                    ammentDetail.AmmendmentId = ret;

                    Facade.PurchaseRequisitionBLL.AddAmmendmentDetail(ammentDetail);
                }


            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "PurchaseRequisitionController";
                // new ErrorLogController().CreateErrorLog(error);
                return ret;
            }
            return ret;
        }

        public JsonResult AmendmentGetByApprovalGivenOnId(int ApprovalGivenOnId)
        {

            try
            {
                var list = Facade.PurchaseRequisitionBLL.AmendmentGetByApprovalGivenOnId(ApprovalGivenOnId);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "ApprovalGivenOnController";
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetTableName(string Status, string FromDate, string ToDate)
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddDays(-2);
                DateTime toDate = DateTime.Now;
                if (FromDate != "default" && ToDate != "default")
                {
                    fromDate = DateTime.Parse(FromDate);
                    toDate = DateTime.Parse(ToDate);
                }
                var ret = Facade.TransactionApprovalBLL.GetTableName(Status, fromDate, toDate);
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "TransactionApprovalController";
                // new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AmendmentPaged(int startRecordNo, int rowPerPage, string whereClause, int rows)
        {
            try
            {
                var customMODEntity = new
                {
                    ListData = Facade.inv_AmendmentBLLBLL.GetPaged(startRecordNo, rowPerPage, whereClause, "Id", "DESC", ref rows),
                    TotalRecord = rows
                };
                return Json(customMODEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AdjustmentController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetByAmendIdReport(int Id)
        {
            try
            {
                var list = Facade.PurchaseRequisitionBLL.GetByAmendIdReport(Id);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AdjustmentController";
                //new ErrorLogController().CreateErrorLog(error);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public string Update(inv_Ammendment _Ammendment)
        {
            string ret = string.Empty;
            try
            {
                if (_Ammendment.ApprovalGivenOnId == 12)
                {
                    //===Get Data===
                    var requisition = Facade.PurchaseRequisitionBLL.GetByNumber(_Ammendment.ReferenceTransactionNumber).FirstOrDefault();
                    requisition.ApprovalStatusId = 1;
                    requisition.TransactiontionType = "Update";
                    ret = Facade.PurchaseRequisitionBLL.Add(requisition);
                }
                if (_Ammendment.ApprovalGivenOnId == 1)
                {
                    //===Get Data===
                    var PurchaseBill = Facade.p_PurchaseBillBLL.Get(_Ammendment.ReferenceTransactionNumber).FirstOrDefault();
                    PurchaseBill.ApprovalStatusId = 1;
                    PurchaseBill.TransactionType = "Update";
                    ret = Facade.p_PurchaseBillBLL.Add(PurchaseBill);

                }
            }
            catch (Exception ex)
            {
                error_Log error = new error_Log();
                error.ErrorMessage = ex.Message;
                error.ErrorType = ex.GetType().ToString();
                error.FileName = "AmendmentController";
                // new ErrorLogController().CreateErrorLog(error);
                return ret;
            }
            return ret;
        }
        
    }
}