var app = angular.module('AngularDemoApp', ['ngRoute', 'ngCookies', 'angular.filter', 'angularUtils.directives.dirPagination']);


//app.run(function (signalR) {
//    signalR.url("http://localhost:21991/signalr");
//});

//Check page parmission from cookies which is defined by 'IndexController'
app.config(function ($routeProvider, $controllerProvider) {
    
    $routeProvider

        ///Security Module======>>>
        .when('/UserGroup', {
            templateUrl: '/SPA/Security/UserGroup/UserGroup.html',
            controller: 'ApprovalGivenOnController',

         
        })
        .when('/Permission', {
            templateUrl: '/SPA/Security/Permission/Permission.html',
            controller: 'PermissionController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('PermissionPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';

                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }

        })

        /// Report Section ====>>
       .when('/PurchaseRequestionReport', {
            templateUrl: '/SPA/MainStore/PurchaseRequestionReport/PurchaseRequestionReportEntry.html',
            controller: 'PurchaseRequestionReportController',
        })
        .when('/AmendDetailsReport', {
            templateUrl: '/SPA/MainStore/AmendDetailsReport/AmendDetailsReport.html',
            controller: 'AmendDetailsReportController',
        })
        .when('/PurchaseBillReport', {
            templateUrl: '/SPA/MainStore/PurchaseBillReport/PurchaseBillReport.html',
            controller: 'PurchaseBillReportController',
        })
        .when('/RequestionSlipReport', {
            templateUrl: '/SPA/WorkShop/RequestionSlipReport/WSRequestionReportEntry.html',
            controller: 'WSRequestionReportController',
        })
        .when('/ItemReceiveReport', {
            templateUrl: '/SPA/MainStore/ItemReceiveReport/ItemReceiveReportEntry.html',
            controller: 'ItemReceiveReportController',
        })
        .when('/WorkshopItemReceiveDetailsReport', {
            templateUrl: '/SPA/WorkShop/WorkShopItemReceiveDetailsReport/ItemReceiveDetailsReport.html',
            controller: 'ItemReceiveDetailsController',
        })
        .when('/StoreIssueReport', {
            templateUrl: '/SPA/MainStore/StoreIssueReport/StoreIssueReportEntry.html',
            controller: 'StoreIssueReportController',
        })

        .when('/Amendment', {
            templateUrl: '/SPA/MainStore/Amend/AmendEntry.html',
            controller: 'AmendController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('AmendmentPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';

                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }

        })
        .when('/ChangePassword', {
            templateUrl: '/SPA/Security/ChangePassword/ChangePassword.html',
            controller: 'ApprovalGivenOnController',

        })

        .when('/ApprovalGivenOn', {
            templateUrl: '/SPA/Admin/ApprovalGivenOn/ApprovalGivenOn.html',
            controller: 'ApprovalGivenOnController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ApprovalGivenOnPermission');
                        if ( !(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/WSItemBill', {
            templateUrl: '/SPA/WorkShop/WorkShopBill/ItemBill.html',
            controller: 'ItemBillController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('WorkShopItemBillPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/WSAmend', {
            templateUrl: '/SPA/WorkShop/WorkShopAmend/WSAmendEntry.html',
            controller: 'WSAmendController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('WSAmendPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/WSItemReceive', {
            templateUrl: '/SPA/WorkShop/WorkShopStoreItemReceive/StoreItemReceiveEntry.html',
            controller: 'StoreItemReceiveController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('WorkShopItemReceivePermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/Job', {
            templateUrl: '/SPA/WorkShop/Job/JobEntry.html',
            controller: 'JobController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('JobPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Approve', {
            templateUrl: '/SPA/MainStore/Approve/Approve.html',
            controller: 'ApproveController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ApprovePermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/JobApproval', {
            templateUrl: '/SPA/WorkShop/WorkshopJobApproval/WorkShopJobApproval.html',
            controller: 'WorkShopJobApprovalController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('JobApprovalPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/AmendReport', {
            templateUrl: '/SPA/Report/Inv_PR_Amend_Report/Inv_PR_Amend_Report.html',
            controller: 'Inv_PR_Amend_Report',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('Inv_PR_Amend_ReportPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Employee', {
            templateUrl: '/SPA/Admin/Employee/Employee.html',
            controller: 'EmployeeController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('EmployeePermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })



        .when('/ItemGoupEntry', {
            templateUrl: '/SPA/Admin/ItemGoupEntry/ItemGroupEntry.html',
            controller: 'ItemGroupEntryController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ItemGroupViewEntryPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/MeasurementUnit', {
            templateUrl: '/SPA/Admin/MeasurementUnit/MeasurementUnit.html',
            controller: 'MeasurementUnitController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('MeasurementUnitPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Vat', {
            templateUrl: '/SPA/Admin/VAT/Vat.html',
            controller: 'VATController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    console.log("Mofiz");
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('VATPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Counter', {
            templateUrl: '/SPA/Admin/Counter/Counter.html',
            controller: 'CounterController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    //console.log("Mofiz");
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('CounterPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Model', {
            templateUrl: '/SPA/Admin/Model/Model.html',
            controller: 'ModelController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ModelPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Item', {
            templateUrl: '/SPA/Admin/Item/Item.html',
            controller: 'ItemController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ItemSetupPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/ItemReport', {
            templateUrl: '/SPA/Admin/ItemReports/ItemReport.html',
            controller: 'ItemReportController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ItemSetupPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Department', {
            templateUrl: '/SPA/Admin/Department/Department.html',
            controller: 'DepartmentController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('DepartmentPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/Designation', {
            templateUrl: '/SPA/Admin/Designation/Designation.html',
            controller: 'DesignationController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('DesignationPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/Section', {
            templateUrl: '/SPA/Admin/Section/SectionEntry.html',
            controller: 'SectionController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('SectionPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/Grade', {
            templateUrl: '/SPA/Admin/Grade/GradeEntry.html',
            controller: 'GradeController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('GradePermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/PurchaseRequisition', {
            templateUrl: '/SPA/MainStore/PurchaseRequisition/PurchaseRequisitionEntry.html',
            controller: 'PurchaseRequisitionController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('PurchaseRequisitionPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })


        .when('/WorkShopRequestion', {
            templateUrl: '/SPA/WorkShop/WorkShopRequestion/WorkShopRequestionEntry.html',
            controller: 'WorkShopRequestionController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('WorkShopRequestionPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/PurchaseBill', {
            templateUrl: '/SPA/MainStore/PurchaseBill/PurchaseBillEntry.html',
            controller: 'PurchaseBillController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('PurchaseBillPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })


        .when('/Adjustment', {
            templateUrl: '/SPA/MainStore/Adjustment/AdjustmentEntry.html',
            controller: 'AdjustmentController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('AdjustmentPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })
        .when('/StockAudit', {
            templateUrl: '/SPA/MainStore/StockAudit/StockAuditEntry.html',
            controller: 'StockAuditController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('StockAuditPermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/StoreIssue', {
            templateUrl: '/SPA/MainStore/StoreIssue/StoreIssueEntry.html',
            controller: 'StoreIssueController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('StoreIssuePermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

        .when('/ItemReceive', {
            templateUrl: '/SPA/MainStore/ItemReceive/ItemReceiveEntry.html',
            controller: 'ItemReceiveController',
            resolve: {
                "check": function () {
                    var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
                    if (login != undefined) {
                        var permission = sessionStorage.getItem('ItemReceivePermission');
                        if (!(JSON.parse(permission))) {
                            alert("You don't have parmission to access this page");
                            window.location = '/Home/Index#/Home';
                        }
                    }
                    else {
                        window.location = '/Home/Login#/';
                    }
                }
            }
        })

       
        .when('/ApprovalStatus', {
            templateurl: '/spa/admin/ApprovalStatus/ApprovalStatus.html',
            controller: 'ApprovalStatusController',
            //resolve: {
            //    "check": function () {
            //        var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
            //        if (login != undefined) {
            //            var permission = sessionStorage.getItem('ItemGroupPermission');
            //            if ( !(JSON.parse(permission))) {
            //                alert("You don't have parmission to access this page");
            //                window.location = '/Home/Index#/Home';

            //            }
            //        }
            //        else {
            //            window.location = '/Home/Login#/';
            //        }
            //    }
            //}
        })

        .when('/AdminDashboard', {
            templateurl: '/spa/admin/AdminDashboard/AdminDashboard.html',
            controller: 'AdminDashboardController',
           
        })
       
       

       
        .when('/Supplier', {
            templateUrl: '/SPA/Admin/Supplier/Supplier.html',
            controller: 'SupplierController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/ApprovalStatus', {
            templateUrl: '/SPA/Admin/ApprovalStatus/ApprovalStatus.html',
            controller: 'ApprovalStatusController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/AdminDashboard', {
            templateUrl: '/SPA/Admin/AdminDashboard/AdminDashboard.html',
            controller: 'AdminDashboardController',
            //resolve: {
            //    "check": function () {
            //        var UserData = sessionStorage.getItem("UserDataSession"); if (UserData != null) { var login = JSON.parse(sessionStorage.UserDataSession); }
            //        if (login != undefined) {
            //            var permission = sessionStorage.getItem('AdminDashBoardPermission');
            //            if (!(JSON.parse(permission))) {
            //                alert("You don't have parmission to access this page");
            //                window.location = '/Home/Index#/Home';
            //            }
            //        }
            //        else {
            //            window.location = '/Home/Login#/';
            //        }
            //    }
            //}
        })
          .when('/Counter', {
            templateUrl: '/SPA/Admin/Counter/Counter.html',
            controller: 'CounterController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
          })
        .when('/Branch', {
            templateUrl: '/SPA/Admin/Branch/Branch.html',
            controller: 'BranchController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/IssueType', {
            templateUrl: '/SPA/Admin/IssueType/IssueType.html',
            controller: 'IssueTypeController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/', {
            templateUrl: '/SPA/Login/Login.html',
            controller: 'LoginController',

        })
        .when('/Purpose', {
            templateUrl: '/SPA/Admin/Purpose/Purpose.html',
            controller: 'PurposeController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/RequisitionType', {
            templateUrl: '/SPA/Admin/RequisitionType/RequisitionType.html',
            controller: 'RequisitionTypeController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/Store', {
            templateUrl: '/SPA/Admin/Store/Store.html',
            controller: 'StoreController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/RecordSerial', {
            templateUrl: '/SPA/Admin/RecordSerial/RecordSerial.html',
            controller: 'RecordSerialController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/StoreRack', {
            templateUrl: '/SPA/Admin/StoreRack/StoreRack.html',
            controller: 'StoreRackController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/Vehicle', {
            templateUrl: '/SPA/Admin/Vehicle/Vehicle.html',
            controller: 'VehicleController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/VehicleGroup', {
            templateUrl: '/SPA/Admin/VehicleGroup/VehicleGroup.html',
            controller: 'VehicleGroupController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .when('/TransactionApproval', {
            templateUrl: '/SPA/Admin/TransactionApproval/TransactionApproval.html',
            controller: 'TransactionApprovalController',
            resolve: {
                "check": function () {
                    $('.note-popover').css("display", "none");
                }
            }
        })
        .otherwise({ redirectTo: '/' });
    
        //.when('/', {
        //    templateUrl: '/SPA/Admin/AdminDashboard/AdminDashboard.html',
        //    controller: 'AdminDashboardController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //.when('/ApprovalStatus', {
        //    templateUrl: '/SPA/Admin/ApprovalStatus/ApprovalStatus.html',
        //    controller: 'ApprovalStatusController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})


      

        //.when('/Department', {
        //    templateUrl: '/SPA/Admin/Department/Department.html',
        //    controller: 'DepartmentController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        //.when('/Designation', {
        //    templateUrl: '/SPA/Admin/Designation/Designation.html',
        //    controller: 'DesignationController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        //.when('/Employee', {
        //    templateUrl: '/SPA/Admin/Employee/Employee.html',
        //    controller: 'EmployeeController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        //.when('/IssueType', {
        //    templateUrl: '/SPA/Admin/IssueType/IssueType.html',
        //    controller: 'IssueTypeController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        //.when('/Item', {
        //    templateUrl: '/SPA/Admin/Item/Item.html',
        //    controller: 'ItemController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

      

        //.when('/MeasurementUnit', {
        //    templateUrl: '/SPA/Admin/MeasurementUnit/MeasurementUnit.html',
        //    controller: 'MeasurementUnitController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})


        //.when('/Model', {
        //    templateUrl: '/SPA/Admin/Model/Model.html',
        //    controller: 'ModelController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})
        //.when('/MotherCompany', {
        //    templateUrl: '/SPA/Admin/MotherCompany/MotherCompany.html',
        //    controller: 'MotherCompanyController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})
        //.when('/Purpose', {
        //    templateUrl: '/SPA/Admin/Purpose/Purpose.html',
        //    controller: 'PurposeController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})
        //.when('/RequisitionType', {
        //    templateUrl: '/SPA/Admin/RequisitionType/RequisitionType.html',
        //    controller: 'RequisitionTypeController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})
        //.when('/Store', {
        //    templateUrl: '/SPA/Admin/Store/Store.html',
        //    controller: 'StoreController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        //.when('/StoreRack', {
        //    templateUrl: '/SPA/Admin/StoreRack/StoreRack.html',
        //    controller: 'StoreRackController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        

        

        //.when('/Vat', {
        //    templateUrl: '/SPA/Admin/Vat/Vat.html',
        //    controller: 'VatController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

        //.when('/Vehicle', {
        //    templateUrl: '/SPA/Admin/Vehicle/Vehicle.html',
        //    controller: 'VehicleController',
        //    resolve: {
        //        "check": function () {
        //            $('.note-popover').css("display", "none");
        //        }
        //    }
        //})

       
      
      
    app.registerCtrl = $controllerProvider.register;
    //jquery to dynamically include controllers as needed




});
app.directive("selectNgFiles", function () {
    return {
        require: "ngModel",
        link: function postLink(scope, elem, attrs, ngModel) {
            elem.on("change", function (e) {
                var files = elem[0].files;
                ngModel.$setViewValue(files);
            })
        }
    }
});
//app.filter('angularUtils.directives.dirPagination', function () {
//    return function (array, property, target) {
//        if (target && property) {
//            target[property] = array;
//        }
//        return array;
//    }
//});
app.factory('MyService', function () {
    return {
        data: {
            userName: '',
            role: '',
            permission: []
        },
        update: function (username, role) {
            this.data.userName = username;
            this.data.role = role;
        },
        permissionUpdate: function (permission) {
            this.data.permission = permission;
        }
    };
});

app.config(function ($provide) {
    $provide.decorator('$exceptionHandler', function ($delegate, $cookieStore) {
        return function (exception, cause) {
            $delegate(exception, cause);
            var message = exception.message;
            $cookieStore.put('errorMassage', message);
        };

    });
});

app.run(function ($http, $cookieStore) {
    var message = $cookieStore.get('errorMassage');
    if (message != undefined) {
        var megs = $cookieStore.get('errorMassage');
        var parms = { message: megs };
        //$http.post('/ErrorLog/CreateErrorLogForClintSite', parms).success(function (data) {
        //});
    }


});