using DbExecutor;
using SecurityDAL;
using SecurityEntity.SECURITY.SecurityBLL;
using Sundorbon.Backend.SECURITY.SecurityBLL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
namespace SecurityBLL
{
    public static class Facade
    {


        public static ad_ItemGroupBLL ItemGroupBLL { get { return new ad_ItemGroupBLL(); } }
        public static ad_MeasurementUnitBLL MeasurementUnitBLL { get { return new ad_MeasurementUnitBLL(); } }

        public static ad_VATBLL VATBLL { get { return new ad_VATBLL(); } }

        public static ad_ItemBLL ItemBll { get { return new ad_ItemBLL(); } }
        public static ad_ItemReportBLL ItemReportBll { get { return new ad_ItemReportBLL(); } }
        public static ad_SupplierBLL SupplierBll { get { return new ad_SupplierBLL(); } }
        public static ad_ModelBLL ModelBll { get { return new ad_ModelBLL(); } }
        public static ad_EmployeeBLL EmployeeBll { get { return new ad_EmployeeBLL(); } }
        public static ad_ApprovalStatusBLL ApprovalStatusBLL { get { return new ad_ApprovalStatusBLL(); } }
        public static ad_CounterBLL CounterBLL { get { return new ad_CounterBLL(); } }
        public static inv_IssueBLL inv_IssueBLL { get { return new inv_IssueBLL(); } }
        public static ad_DepartmentBLL DepartmentBLL { get { return new ad_DepartmentBLL(); } }
        public static ad_BranchBLL BranchBLL { get { return new ad_BranchBLL(); } }
        public static ad_IssueTypeBLL IssueTypeBLL { get { return new ad_IssueTypeBLL(); } }
        public static ad_PurposeBLL PurposeBLL { get { return new ad_PurposeBLL(); } }
        public static ad_RequisitionTypeBLL RequisitionTypeBLL { get { return new ad_RequisitionTypeBLL(); } }
        public static ad_StoreBLL StoreBLL { get { return new ad_StoreBLL(); } }
        public static ad_StoreRackBLL StoreRackBLL { get { return new ad_StoreRackBLL(); } }
        public static ad_VehicleBLL VehicleBLL { get { return new ad_VehicleBLL(); } }
        public static ad_VehicleGroupBLL VehicleGroupBLL { get { return new ad_VehicleGroupBLL(); } }
        public static ad_ApprovalGivenOnBLL ApprovalGivenOnBLL { get { return new ad_ApprovalGivenOnBLL(); } }
        public static ad_RecordSerialBLL RecordSerialBLL { get { return new ad_RecordSerialBLL(); } }
        public static ad_TransactionApprovalBLL TransactionApprovalBLL { get { return new ad_TransactionApprovalBLL(); } }
        public static inv_PurchaseRequisitionBLL PurchaseRequisitionBLL { get { return new inv_PurchaseRequisitionBLL(); } }
        public static inv_PurchaseRequisitionDetailsBLL PurchaseRequisitionDetailsBLL { get { return new inv_PurchaseRequisitionDetailsBLL(); } }
        public static inv_AdjustmentBLL AdjustmentBLL { get { return new inv_AdjustmentBLL(); } }
        public static inv_AdjustmentDetailsBLL AdjustmentDetailsBLL { get { return new inv_AdjustmentDetailsBLL(); } }
        public static inv_StockAuditBLL StockAuditBLL { get { return new inv_StockAuditBLL(); } }
        public static inv_StoreItemReciveBLL inv_StoreItemReciveBLL { get { return new inv_StoreItemReciveBLL(); } }
        public static inv_StockAuditDetailsBLL StockAuditDetailsBLL { get { return new inv_StockAuditDetailsBLL(); } }
        public static inv_AmendmentBLL inv_AmendmentBLLBLL { get { return new inv_AmendmentBLL(); } }
        public static p_PurchaseBillBLL p_PurchaseBillBLL { get { return new p_PurchaseBillBLL(); } }
        public static ws_JobBLL JobBLL { get { return new ws_JobBLL(); } }
        public static ws_JobDetailsBLL JobDetailsBLL { get { return new ws_JobDetailsBLL(); } }
        public static ws_JobItemDetailsBLL JobItemDetailsBLL { get { return new ws_JobItemDetailsBLL(); } }
        public static s_RoleBLL Role { get { return new s_RoleBLL(); } }
        public static ws_RequestionBLL ws_RequestionBLL { get { return new ws_RequestionBLL(); } }
        public static inv_StoreIssueBLL inv_StoreIssueBLL { get { return new inv_StoreIssueBLL(); } }
        public static inv_StoreIssueDetailsBLL inv_StoreIssueDetailsBLL { get { return new inv_StoreIssueDetailsBLL(); } }
        public static ws_StoreItemReceiveDetailsBLL ws_StoreItemReceiveDetailsBLL { get { return new ws_StoreItemReceiveDetailsBLL(); } }
        public static ws_StoreItemReceiveBLL ws_StoreItemReceiveBLL { get { return new ws_StoreItemReceiveBLL(); } }

        public static ws_IssueItemBLL ws_IssueItemBLL { get { return new ws_IssueItemBLL(); } }
        public static ws_IssueItemDetailsBLL ws_IssueItemDetailsBLL { get { return new ws_IssueItemDetailsBLL(); } }

        public static s_UserBLL User { get { return new s_UserBLL(); } }
        public static s_ModuleBLL Module { get { return new s_ModuleBLL(); } }
       
       
        public static s_ScreenBLL Screen { get { return new s_ScreenBLL(); } }
        public static s_PermissionBLL Permission { get { return new s_PermissionBLL(); } }
        public static s_PermissionDetailBLL PermissionDetail { get { return new s_PermissionDetailBLL(); } }
      
        public static ad_LoginLogoutLogBLL LoginLogoutLog { get { return new ad_LoginLogoutLogBLL(); } }
      
        public static s_ScreenLockBLL ScreenLock { get { return new s_ScreenLockBLL(); } }
     
        public static error_LogBLL ErrorLog { get { return new error_LogBLL(); } }
       
      
       
      
        public static s_ScreenDetailBLL ScreenDetail { get { return new s_ScreenDetailBLL(); } }
      
        public static s_UserDepartmentBLL s_UserDepartment { get { return new s_UserDepartmentBLL(); } }
       
      
       
        public static s_ReportNotificationDetailBLL s_ReportNotificationDetailBLL { get { return new s_ReportNotificationDetailBLL(); } }
      
        public static s_SystemNotificationBLL s_SystemNotificationBLL { get { return new s_SystemNotificationBLL(); } }
       
        public static ad_ItemGroupBLL ad_ItemGroupBLL { get { return new ad_ItemGroupBLL(); } }

        public static ad_DesignationBLL Designation { get { return new ad_DesignationBLL(); } }
    }
}