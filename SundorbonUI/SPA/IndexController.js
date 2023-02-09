app.controller("IndexController", function ($scope, $cookieStore, $route, $templateCache, $window, MyService, $http, $filter) {
    load();
  
     $scope.LoginUser = $cookieStore.get('LoginUser');
   


    function load() {

        $scope.ManueName ="Sundarban"
        //$('.note-popover').css("display", "none")
        $scope.LoginUser = [];
        $scope.NoticeList = [];
     
        $scope.UnreadMessageNo = 0;
        //All menu control hidden default ----Start
        //$('.note-popover').css("display", "none");

        $scope.SecurityView = "menuViewHide";
        $scope.UserGroupView = "menuViewHide";
        $scope.PermissionView = "menuViewHide";
        $scope.ChangePasswordView = "menuViewHide";

        $scope.AdminView = "menuViewHide";
        $scope.ApprovalGivenOnView = "menuViewHide";
        $scope.ItemGroupView = "menuViewHide"
        $scope.ApprovalStatusView = "menuViewHide";
        $scope.AdminDashBoardView = "menuViewHide"
        $scope.BranchView = "menuViewHide";
        $scope.StoreView = "menuViewHide";
        $scope.StoreRackView = "menuViewHide";
        $scope.SupplierView = "menuViewHide";
        $scope.TransactionApprovalView = "menuViewHide";
        $scope.VatView = "menuViewHide";
        $scope.VehicleView = "menuViewHide";
        $scope.CounterView = "menuViewHide";
        $scope.DepartmentView = "menuViewHide";
        $scope.DesignationView = "menuViewHide";
        $scope.IssueTypeView = "menuViewHide";
        $scope.EmployeeView = "menuViewHide";
        $scope.ItemSetupView = "menuViewHide";
        $scope.ItemGroupViewEntry = "menuViewHide"
        $scope.MeasurementUnitView = "menuViewHide";
        $scope.ModelView = "menuViewHide";
        $scope.MotherCompanyView = "menuViewHide";
        $scope.PurposeView = "menuViewHide";
        $scope.RequisitionTypeView = "menuViewHide";
        $scope.VehicleGroupView = "menuViewHide";
        $scope.VatView = "menuViewHide";
        $scope.GradeView = "menuViewHide";
        $scope.SectionView = "menuViewHide";
        $scope.ItemReportView = "menuViewHide";
        $scope.RecordSerial = "menuViewHide";

        $scope.ReportsView = "menuViewHide";
        $scope.WorkshopView = "menuViewHide";
        $scope.MainStoreView = "menuViewHide";
        $scope.PurchaseBillView = "menuViewHide";
        $scope.JobView = "menuViewHide";
        $scope.JobApprovalView = "menuViewHide";
        $scope.AmendReportView = "menuViewHide";
        ///Purchase 

        $scope.MainStoreView = "menuViewHide";
        $scope.PurchaseRequisitionView = "menuViewHide";
        $scope.AdjustmentView = "menuViewHide";
        $scope.StockAuditView = "menuViewHide";
        $scope.AmendmentView = "menuViewHide";
        $scope.ApproveView = "menuViewHide";
        $scope.StoreIssueView = "menuViewHide";
        $scope.ItemReceiveView = "menuViewHide";
        $scope.WorkShopRequestionView = "menuViewHide";
        $scope.WorkShopItemReceiveView = "menuViewHide";
        $scope.WorkShopItemBillView = "menuViewHide";
        $scope.WSAmendView = "menuViewHide";
      
        //All menu control hidden default ----End
        GetUser(); //Get logged in user Info from cookies
    }

   

  
  

    $scope.ReloadPage = function () {
        //$templateCache.removeAll();
        var currentPageTemplate = $route.current.templateUrl;
        console.log(currentPageTemplate);
        $templateCache.remove(currentPageTemplate);
        //$window.location.reload();
    }

    function GetUser() {
        var login = sessionStorage.getItem("UserDataSession");
        if (login=="null") {
            sessionStorage.removeItem('UserDataSession');
            login = null;
        }
        if (login != null   ) {
          
                $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
                $scope.UserId = $scope.LoginUser.UserId;
                $scope.UserName = $scope.LoginUser.Username;
                $scope.RoleId = $scope.LoginUser.RoleId;
                $scope.RoleName = $scope.LoginUser.RoleName;

                GetPermissionByRoleId($scope.RoleId);      
      
          
        }
       
    }

    function GetPermissionByRoleId(roleId) {

        $http({
            url: '/Permission/GetPermissionByRoleId?roleId=' + roleId,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            console.log(data);
            angular.forEach(data, function (aPermission) {
                //Set Sitebar and Page Permission
                if (aPermission.ScreenName == "Approval Given On" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.ApprovalGivenOnView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Stock Audit" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.StockAuditView = "menuViewShow";
                    sessionStorage.setItem("StockAuditScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("StockAuditPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "WS ItemReceive" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.WorkShopItemReceiveView = "menuViewShow";
                    sessionStorage.setItem("WorkShopItemReceiveScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("WorkShopItemReceivePermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Transaction Approval" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.TransactionApprovalView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Amendment" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.AmendmentView = "menuViewShow";
                    sessionStorage.setItem("AmendmentScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("AmendmentPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Amend Report" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.AmendReportView = "menuViewShow";
                    sessionStorage.setItem("Inv_PR_Amend_ReportScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("Inv_PR_Amend_ReportPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Job Approval" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.JobApprovalView = "menuViewShow";
                    sessionStorage.setItem("JobApprovalScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("JobApprovalPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "WS Amend" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.WSAmendView = "menuViewShow";
                    sessionStorage.setItem("WSAmendScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("WSAmendPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "WS Item Bill" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.WorkShopItemBillView = "menuViewShow";
                    sessionStorage.setItem("WorkShopItemBillScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("WorkShopItemBillPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Record Serial" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.RecordSerial = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Vehicle Group" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.VehicleGroupView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Store" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.StoreView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Vehicle" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.VehicleView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Store Rack" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.StoreRackView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Requisition Type" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.RequisitionTypeView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Branch" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.BranchView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Issue Type" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.IssueTypeView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Purpose" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.PurposeView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Item Report" && aPermission.CanView) {
                    $scope.ReportsView = "menuViewShow";
                    $scope.ItemReportView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }

                if (aPermission.ScreenName == "AdminDashBoard" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.AdminDashBoardView = "menuViewShow";
                    sessionStorage.setItem("AdminDashBoardScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("AdminDashBoardPermission", aPermission.PermissionId);

                }

                
                if (aPermission.ScreenName == "Approval Status" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.ApprovalStatusView = "menuViewShow";
                    sessionStorage.setItem("ApprovalGivenOnScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalGivenOnPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Item Group" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.ItemGroupViewEntry = "menuViewShow";
                    sessionStorage.setItem("ItemGroupViewEntryScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ItemGroupViewEntryPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "MeasurementUnit" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.MeasurementUnitView = "menuViewShow";
                    sessionStorage.setItem("MeasurementUnitScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("MeasurementUnitPermission", aPermission.PermissionId);
                    
                }
                if (aPermission.ScreenName == "VAT" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.VatView = "menuViewShow";
                    sessionStorage.setItem("VATScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("VATPermission", aPermission.PermissionId);
                    

                }
                if (aPermission.ScreenName == "Model" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.ModelView = "menuViewShow";
                    sessionStorage.setItem("ModelScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ModelPermission", aPermission.PermissionId);
                }
                if (aPermission.ScreenName == "Job" && aPermission.CanView) {
                    $scope.WorkshopView = "menuViewShow";
                    $scope.JobView = "menuViewShow";
                    sessionStorage.setItem("JobScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("JobPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Supplier" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.SupplierView = "menuViewShow";
                    sessionStorage.setItem("SupplierScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("SupplierPermission", aPermission.PermissionId);


                }

              
                if (aPermission.ScreenName == "Employee" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.EmployeeView = "menuViewShow";
                    sessionStorage.setItem("EmployeeScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("EmployeePermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Department" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.DepartmentView = "menuViewShow";
                    sessionStorage.setItem("DepartmentScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("DepartmentPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Designation" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.DesignationView = "menuViewShow";
                    sessionStorage.setItem("DesignationScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("DesignationPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Section" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.SectionView = "menuViewShow";
                    sessionStorage.setItem("SectionScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("SectionPermission", aPermission.PermissionId);

                }

                
                if (aPermission.ScreenName == "Grade" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.GradeView = "menuViewShow";
                    sessionStorage.setItem("GradeScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("GradePermission", aPermission.PermissionId);

                }

                
                
                if (aPermission.ScreenName == "Approval Status" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.ApprovalStatusView = "menuViewShow";
                    sessionStorage.setItem("ApprovalStatusScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovalStatusPermission", aPermission.PermissionId);

                }

                if (aPermission.ScreenName == "Approve" && aPermission.CanView) {
                    $scope.MainStoreView = "menuViewShow";
                    $scope.ApproveView = "menuViewShow";
                    sessionStorage.setItem("ApproveScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ApprovePermission", aPermission.PermissionId);

                }

                
                if (aPermission.ScreenName == "ItemSetup" && aPermission.CanView) {
                    $scope.AdminView = "menuViewShow";
                    $scope.ItemSetupView = "menuViewShow";
                    sessionStorage.setItem("ItemSetupScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ItemSetupPermission", aPermission.PermissionId);

                }
              
                if (aPermission.ScreenName == "Permision" && aPermission.CanView) {
                    $scope.SecurityView = "menuViewShow";
                    $scope.PermissionView = "menuViewShow";
                    sessionStorage.setItem("PermissionScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("PermissionPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Counter View" && aPermission.CanView) {
                    $scope.SecurityView = "menuViewShow";
                    $scope.CounterView = "menuViewShow";
                    sessionStorage.setItem("PermissionScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("CounterPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Purchase Requisition" && aPermission.CanView) {
                    $scope.MainStoreView = "menuViewShow";
                    $scope.PurchaseRequisitionView = "menuViewShow";
                    sessionStorage.setItem("PurchaseRequisitionScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("PurchaseRequisitionPermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "PurchaseBill" && aPermission.CanView) {
                    $scope.MainStoreView = "menuViewShow";
                    $scope.PurchaseBillView = "menuViewShow";
                    sessionStorage.setItem("PurchaseBillScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("PurchaseBillPermission", aPermission.PermissionId);

                }

                
                if (aPermission.ScreenName == "Adjustment" && aPermission.CanView) {
                    $scope.MainStoreView = "menuViewShow";
                    $scope.AdjustmentView = "menuViewShow";
                    sessionStorage.setItem("AdjustmentScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("AdjustmentPermission", aPermission.PermissionId);

                }

                if (aPermission.ScreenName == "Store Issue" && aPermission.CanView) {
                    $scope.MainStoreView = "menuViewShow";
                    $scope.StoreIssueView  = "menuViewShow";
                    sessionStorage.setItem("StoreIssueScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("StoreIssuePermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "Item Receive" && aPermission.CanView) {
                    $scope.MainStoreView = "menuViewShow";
                    $scope.ItemReceiveView = "menuViewShow";
                    sessionStorage.setItem("ItemReceiveScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("ItemReceivePermission", aPermission.PermissionId);

                }
                if (aPermission.ScreenName == "WorkShop Requestion Slip" && aPermission.CanView) {
                    $scope.WorkshopView = "menuViewShow";
                    $scope.WorkShopRequestionView = "menuViewShow";
                    sessionStorage.setItem("WorkShopRequestionScreenId", aPermission.ScreenId);
                    sessionStorage.setItem("WorkShopRequestionPermission", aPermission.PermissionId);

                }
               
                
                
                    
              

            });

        });

    }

    $scope.SignOut = function () {
        var login = sessionStorage.getItem("UserDataSession");
        if (login != null) {
            $scope.User = JSON.parse(sessionStorage.UserDataSession);
        }
        sessionStorage.setItem("UserDataSession", null);
        window.location = '/Home/Login#/';
        RemoveAllScreenLock();
        RemoveSession();
    }


    function RemoveAllScreenLock() {
        var parms = JSON.stringify({ userId: $scope.UserId });
        $http.post('/Permission/RemoveScreenLock', parms).success(function (data) {
        });
    }
    window.onbeforeunload = UpdateCounterStatus;
    
    function UpdateCounterStatus() {
        var CounterData = sessionStorage.getItem("CounterData");
        var ParsedCounterData = JSON.parse(CounterData);
        $http({
            url: encodeURI('/Counter/ChangeUsedStatus?Id=' + ParsedCounterData.Id + '&status=' + false),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.CounterList = data;
        });
    }

    function RemoveSession() {
        //User Data Remove ==========>>
        sessionStorage.removeItem('UserDataSession');

        //Counter Data Remove ==========>>
        UpdateCounterStatus();
        sessionStorage.removeItem('CounterData');

        //Add For ScreenId============>>
        sessionStorage.removeItem('ApprovalGivenOnScreenId');
       
        sessionStorage.removeItem('ApprovalStatusScreenId');
        sessionStorage.removeItem('AdminDashBoardScreenId');
        sessionStorage.removeItem('PermissionScreenId');
        sessionStorage.removeItem('ItemGroupViewEntryScreenId');
        sessionStorage.removeItem('ItemSetupScreenId');
        sessionStorage.removeItem('MeasurementUnitScreenId');
        sessionStorage.removeItem('VATScreenId');
        sessionStorage.removeItem('DepartmentScreenId');
        sessionStorage.removeItem('CounterScreenId');
        sessionStorage.removeItem('EmployeeScreenId');
        sessionStorage.removeItem('AdminDashBoardScreenId');
        sessionStorage.removeItem('DesignationScreenId');
        sessionStorage.removeItem('GradeScreenId');
        sessionStorage.removeItem('SectionScreenId');
        sessionStorage.removeItem('PurchaseRequisitionScreenId');
        sessionStorage.removeItem('PurchaseBillScreenId');
        sessionStorage.removeItem('ApproveScreenId');
        sessionStorage.removeItem('StoreIssueScreenId');
        sessionStorage.removeItem('ItemReceiveScreenId');
        sessionStorage.removeItem('WorkShopRequestionScreenId');


        //Add For PermisionId==========>>
        sessionStorage.removeItem('ApprovalGivenOnPermission');
        sessionStorage.removeItem('ApprovalStatusPermission');
        sessionStorage.removeItem('PermissionPermission');
        sessionStorage.removeItem('ItemGroupViewEntryPermission');
        sessionStorage.removeItem('ItemSetupPermission');
        sessionStorage.removeItem('MeasurementUnitPermission');
        sessionStorage.removeItem('VATPermission');
        sessionStorage.removeItem('DepartmentPermission');
        sessionStorage.removeItem('CounterPermission');
        sessionStorage.removeItem('EmployeePermission');
        sessionStorage.removeItem('AdminDashBoardPermission');
        sessionStorage.removeItem('DesignationPermission');
        sessionStorage.removeItem('GradePermission');
        sessionStorage.removeItem('SectionPermission');
        sessionStorage.removeItem('PurchaseRequisitionScreenId');
        sessionStorage.removeItem('PurchaseBillPermission');
        sessionStorage.removeItem('ApprovePermission');
        sessionStorage.removeItem('StoreIssuePermission');
        sessionStorage.removeItem('ItemReceivePermission');
        sessionStorage.removeItem('WorkShopRequestionPermission');
     
      }
});
