using System.Web;
using System.Web.Optimization;

namespace Sundorbon
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                      ));


            bundles.Add(new ScriptBundle("~/bundles/spa").Include(


               //---- Angular Assets ------
               "~/Content/assets/plugins/sweet-alert2/sweetalert2.min.js",

                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-filter.min.js",
                "~/Scripts/mapapi.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/dirPagination.js",
                "~/Scripts/toastr.min.js",


                "~/SPA/app.js",


                "~/SPA/Security/ChangePassword/ChangePasswordController.js",
                "~/SPA/Security/UserGroup/UserGroupController.js",
                "~/SPA/Security/Permission/PermissionController.js",

                  /// Main Store ======>>>
                  "~/SPA/MainStore/PurchaseRequisition/PurchaseRequisitionController.js",
                  "~/SPA/MainStore/Adjustment/AdjustmentController.js",
                  "~/SPA/MainStore/StockAudit/StockAuditController.js",
                  "~/SPA/MainStore/Amend/AmendController.js",
                  "~/SPA/MainStore/PurchaseBill/PurchaseBillController.js",
                  "~/SPA/MainStore/Approve/ApproveController.js",

                  "~/SPA/MainStore/PurchaseRequestionReport/PurchaseRequestionReportController.js",
                  "~/SPA/MainStore/PurchaseBillReport/PurchaseBillReportController.js",
                   "~/SPA/MainStore/AmendDetailsReport/AmendDetailsReportController.js",
                   "~/SPA/MainStore/StoreIssue/StoreIssueController.js",
                   "~/SPA/MainStore/ItemReceive/ItemReceiveController.js",
                   "~/SPA/MainStore/ItemReceiveReport/ItemReceiveReportController.js",
                   "~/SPA/MainStore/StoreIssueReport/StoreIssueReportController.js",


                 ///----Admin-----///        

                 "~/SPA/Admin/ApprovalGivenOn/ApprovalGivenOnController.js",
                 "~/SPA/Admin/ItemGoupEntry/ItemGroupEntryController.js",
                 "~/SPA/Admin/ApprovalStatus/ApprovalStatusController.js",

                 "~/SPA/Admin/Department/DepartmentController.js",
                 "~/SPA/Admin/Employee/EmployeeController.js",
                 "~/SPA/Admin/Designation/DesignationController.js",
                 "~/SPA/Admin/Employee/EmployeeController.js",
                 "~/SPA/Admin/IssueType/IssueTypeController.js",
                 "~/SPA/Admin/Item/ItemController.js",
                 "~/SPA/Admin/ItemReports/ItemReportController.js",
                 "~/SPA/Admin/Counter/CounterController.js",


                 "~/SPA/Admin/MeasurementUnit/MeasurementUnitController.js",
                 "~/SPA/Admin/Model/ModelController.js",
                 "~/SPA/Admin/MotherCompany/MotherCompanyController.js",
                 "~/SPA/Admin/Purpose/PurposeController.js",
                 "~/SPA/Admin/RequisitionType/RequisitionTypeController.js",
                 "~/SPA/Admin/Store/StoreController.js",
                 "~/SPA/Admin/StoreRack/StoreRackController.js",
                 "~/SPA/Admin/Supplier/SupplierController.js",
                 "~/SPA/Admin/Branch/BranchController.js",
                 "~/SPA/Admin/TransactionApproval/TransactionApprovalController.js",
                 "~/SPA/Admin/Vat/VatController.js",
                 "~/SPA/Admin/Vehicle/VehicleController.js",
                  "~/SPA/Admin/VehicleGroup/VehicleGroupController.js",
                  "~/SPA/Admin/RecordSerial/RecordSerialController.js",

                 "~/SPA/Admin/Grade/GradeController.js",
                 "~/SPA/Admin/Section/SectionController.js",

                  "~/SPA/Admin/AdminDashboard/AdminDashboardController.js",

                  "~/SPA/Admin/AdminBatteryStatus/AdminBatteryStatusController.js",

                  "~/SPA/User/BatteryStatus/BatteryStatusController.js",

                  "~/SPA/Admin/SwapStationMap/SwapStationMapController.js",

                  "~/SPA/Admin/AddSwapStation/AddSwapStationController.js",

                  "~/SPA/Admin/PaymentReceived/PaymentRecivedController.js",
                  "~/SPA/Admin/AdminDashboard/AdminDashboardController.js",
                  "~/SPA/Admin/AdminSettings/AdminSettingsController.js",
                  "~/SPA/Admin/AdminInvoice/AdminInvoiceController.js",
                  "~/SPA/Admin/AddLocationSetup/AddLocationSetupController.js",
                  "~/SPA/Admin/AddChargingUnit/AddChargingUnitController.js",
                  "~/SPA/Admin/BookingHistory/BookingHistoryController.js",

                 "~/SPA/LandingPage/LandingPageController.js",



                 "~/SPA/User/BatteryBooking/BatteryBookingController.js",

                 "~/SPA/Admin/ApproveReg/ApproveRegController.js",
                  "~/SPA/Admin/PaymentMethod/PaymentMethodEntryController.js",

                  "~/SPA/Admin/UserRole/UserRoleEntryController.js",

                  "~/SPA/Admin/UserManage/UserManageController.js",

                   "~/SPA/Admin/BatterySetup/BatterySetupController.js",

                ///====== Work Shop ========
                
                   "~/SPA/WorkShop/Job/JobController.js",
                   "~/SPA/WorkShop/WorkShopRequestion/WorkShopRequestionController.js",
                   "~/SPA/WorkShop/WorkshopJobApproval/WorkShopJobApprovalController.js",
                   "~/SPA/WorkShop/RequestionSlipReport/WSRequestionReportController.js",
                   "~/SPA/WorkShop/WorkShopStoreItemReceive/StoreItemReceiveController.js",
                   "~/SPA/WorkShop/WorkShopItemReceiveDetailsReport/ItemReceiveDetailsController.js",
                    "~/SPA/WorkShop/WorkShopBill/ItemBillController.js",
                    "~/SPA/WorkShop/WorkShopAmend/WSAmendController.js",

                     "~/SPA/Report/Inv_PR_Amend_Report/Inv_PR_Amend_Report.js",
                 ///====== User ========
                 "~/SPA/User/SwapStationMapMain/SwapStationMapMainController.js",

                 "~/SPA/User/Payment/PaymentController.js",



                  "~/SPA/User/UserProfile/UserProfileController.js",
                  "~/SPA/User/CartItem/CartItemEntryController.js",
                  "~/SPA/User/Ticket/TicketController.js",




                 //// Customer care ///
                 "~/SPA/CustomerCare/Dashboard/CustomerCareDashboardController.js",

                  "~/SPA/CustomerCare/BillingInfo/BillingInfoController.js",
                  "~/SPA/CustomerCare/CustomerQueries/CustomerQueriesController.js",


                  "~/SPA/CustomerCare/EnableDisableSwapStation/EableDisableSwapStationEntryController.js",

                  "~/SPA/CustomerCare/LockUnlockChargingUnit/LockUnlockChargingUnitController.js",

                  "~/SPA/CustomerCare/EnableDisableChargingUnit/EnableDisableChargingUnitController.js",

                  "~/SPA/CustomerCare/ChargingPortError/ChargingPortErrorController.js",
                   "~/SPA/CustomerCare/CustomerTicket/CustomerTicketController.js",
                   "~/SPA/CustomerCare/ManageTicket/ManageTicketController.js",
                   "~/SPA/CustomerCare/BatteryHelthCheck/BatteryHelthCheckEntryController.js",
                  "~/SPA/User/UserDashboard/UserDashboardController.js",
                  "~/SPA/User/Invoice/InvoiceController.js",
                  "~/SPA/IndexController.js"
                //"~/SPA/Login/LoginController.js"




                ));



            //bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
            //       "~/Content/assets/js/jquery.min.js",
            //       "~/Content/assets/js/bootstrap.bundle.min.js",
            //       "~/Content/assets/js/metisMenu.min.js",
            //       "~/Content/assets/js/waves.min.js",
            //     //"~/Content/assets/js/jquery.slimscroll.min.js",
            //       "~/Content/assets/plugins/apexcharts/apexcharts.min.js",
            //       "~/Content/assets/pages/jquery.eco_dashboard.init.js"
            // ));
        }
    }
}
