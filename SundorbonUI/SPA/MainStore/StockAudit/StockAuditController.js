app.controller("StockAuditController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();
    var CounterPrefix = "";
    function Clear() {
        $scope.IsIncreasedList = [
            { Id: 1, IsIncreased: "YES" },
            { Id: 2, IsIncreased: "NO" }
        ];
        $scope.Updating = false;
        $scope.button = "Save";
        $scope.buttonStockAuditDetails = "Add";
        $scope.StockAudit = {};
        $scope.StockAuditDetail = {};
        $scope.ItemList = [];
        $scope.StockAuditDetailList = [];
        $scope.EmployeeList = [];
        $scope.StoreRackList = [];
        $scope.StoreList = [];

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        StockAuditGetPaged($scope.currentPage);
        ///Method Call=====>>>
        GetAllItem();
        GetAllEmployee();
        GetAllStoreRack();
        GetAllStore();
    }

    function StockAuditGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "Id LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/StockAudit/StockAuditPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.StockAuditList = data.ListData;
            $scope.total_count = data.TotalRecord;
            angular.forEach($scope.StockAuditList, function (aData) {
                if (aData.AuditDate != null) {
                    var res1 = aData.AuditDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.AuditDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'MMM dd, yyyy')).toString();
                        aData.AuditDate = date1;
                    }
                }

            })
            if (data.TotalRecord>0) {
                var NumberString = data.ListData[0].Id;
                var num1 = Number(NumberString.substr(7, 17));
                num2 = num1 + 1;
                $scope.StockAudit.Id = NumberString.substr(0, 7) + (num2).toString();
            }
            else {
                $scope.StockAudit.Id = "SC1-SA-1000000001";
            }
           
            
          
        });
    }

    function GetAllEmployee() {
        $http({
            url: "/Employee/GetAllEmployee",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.EmployeeList = data;
        });
    }

    function GetAllItem() {
        $http({
            url: "/Item/GetAllItem",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ItemList = data;
        });
    }

    function GetAllStoreRack() {
        $http({
            url: "/StoreRack/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.StoreRackList = data;
        });
    }
    function GetAllStore() {
        $http({
            url: "/Store/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.StoreList = data;
        });
    }

    $scope.ReloadStore = function () {
        $scope.StoreList = [];
        $scope.ddlStore = null;
        GetAllStore();
    }
    $scope.ReloadItem = function () {
        $scope.ItemList = [];
        GetAllItem();
    }
    $scope.ReloadEmployee = function () {
        $scope.EmployeeList = [];
        $scope.ddlEmployee = null;
        GetAllEmployee();
    }
    $scope.ReloadStoreRack= function () {
        $scope.StoreRackList = [];
        $scope.ddlStoreRack = null;
        GetAllStoreRack();
    }
    $scope.addStockAuditDetail = function () {
        var isValid = true;
        if ($scope.StockAuditDetail.PhysicalStockQty == null || $scope.StockAuditDetail.PhysicalStockQty == undefined) {
            toastr.error('Physical Stock Qty can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }

        if ($scope.ddlStoreRack == null || $scope.ddlStoreRack == undefined) {
            toastr.error('Store Rack can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.StockAuditDetail.OldStockQty == null || $scope.StockAuditDetail.OldStockQty == undefined) {
            toastr.error('Old Stock Qty  can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            $scope.StockAuditDetail.RackDescription = $scope.ddlStoreRack.RackDescription;
            $scope.StockAuditDetail.RackId = $scope.ddlStoreRack.Id;

            if ($scope.StockAuditDetail.Id == null || $scope.StockAuditDetail.Id == undefined) {
                $scope.StockAuditDetailList.push($scope.StockAuditDetail);
            }
            else {
                angular.forEach($scope.StockAuditDetailList, function (aData) {
                    if (aData.Id == $scope.StockAuditDetail.Id) {
                        var StoreRack = Object.values($scope.StoreRackList).filter(x => x.Id == $scope.ddlStoreRack.Id);
                        aData.RackDescription = StoreRack[0].RackDescription;
                        aData.RackId = $scope.ddlStoreRack.Id;
                        aData.PhysicalStockQty = $scope.StockAuditDetail.PhysicalStockQty;
                        aData.OldStockQty = $scope.StockAuditDetail.OldStockQty;
                    }

                })
            }
            $scope.StockAuditDetailList.p
            $scope.StockAuditDetail = {};
            $scope.ddlItem = null;
            $scope.ddlStoreRack = null;
            $scope.ddlIsIncreased = null;
        }

    }

    $scope.Remove = function (aReqDetail) {
        var ind = $scope.StockAuditDetailList.indexOf(aReqDetail);
        $scope.StockAuditDetailList.splice(ind, 1);
    }

    $scope.StockAuditSave = function () {
        var isValid = true;
        if ($scope.StockAudit.AuditDate == null || $scope.StockAudit.AuditDate == undefined) {
            toastr.error('Stock Audit Date can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }

        if ($scope.StockAudit.Remarks == null || $scope.StockAudit.Remarks == undefined || $scope.StockAudit.Remarks == "") {
            toastr.error('Remarks can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlEmployee == null || $scope.ddlEmployee == undefined) {
            toastr.error('Employee can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlStore == null || $scope.ddlStore == undefined) {
            toastr.error('Store can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            $scope.StockAudit.CreatorId = $scope.LoginUser.UserId;
            $scope.StockAudit.UpdatorId = $scope.LoginUser.UserId;
            $scope.StockAudit.AuditedByUserId = $scope.ddlEmployee.EmployeeId;
            $scope.StockAudit.AuditedStoreId = $scope.ddlStore.Id;
            var transactionType = "INSERT";
            var titleText = "Do you want to save?";
            if ($scope.button == "Update") {
                titleText = "Do you want to update?";
                transactionType = "UPDATE";
            }
            else {
                transactionType = "INSERT";
            }


            var parms = JSON.stringify({ _StockAudit: $scope.StockAudit, _StockAudit_Details_list: $scope.StockAuditDetailList, transactionType: transactionType });
            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/StockAudit/Save', parms).success(function (data) {
                        if (data != null) {
                            if ($scope.button == "Update") {
                                toastr.success('Item updated successfully.');
                            }
                            else {
                                toastr.success('Item saved successfully.');
                            }
                            Clear();
                        } else {
                            toastr.error('Data Not save.');
                        }
                    }).error(function (data) {
                        toastr.error('Server Errors!');
                        alertify.log('Server Errors!', 'error', '5000');
                    });
                }
                else if (result.dismiss == "cancel") {
                    Swal.DismissReason.cancel;
                }
            })

        }


    }

    function GetAllStockAuditDetailsFromStockAuditId(Number) {
        $http({

            url: encodeURI('/StockAudit/GetAllStockAuditDetailsFromStockAuditId?Id=' + Number),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.StockAuditDetailList = data;
            //angular.forEach($scope.StockAuditDetailList, function (aData) {
            //    var StoreRack = Object.values($scope.StoreRackList).filter(x => x.Id == aData.RackId);
            //    aData.Rack = StoreRack[0].RackDescription;
            //    $scope.Updating = true;
            //})
            $scope.Updating = true;
        });
    }


    $scope.UpdateStockAudit = function (aStockAudit) {

        $scope.button = "Update";
        $scope.StockAudit.Id = aStockAudit.Id;
        $scope.StockAudit.Remarks = aStockAudit.Remarks;
        $scope.ddlEmployee = { EmployeeId: aStockAudit.AuditedByUserId };
        $scope.ddlStore = { Id: aStockAudit.AuditedStoreId}

        var date = aStockAudit.AuditDate;
        $scope.StockAudit.AuditDate = new Date(date.toString());
        GetAllStockAuditDetailsFromStockAuditId(aStockAudit.Id);
    }

    $scope.UpdateStockAuditDetails = function (aStockAudit) {
        $scope.buttonStockAuditDetails = "Update";
        $scope.StockAuditDetail.Id = aStockAudit.Id;
        $scope.ddlStoreRack = { Id: aStockAudit.RackId}

        $scope.StockAuditDetail.PhysicalStockQty = aStockAudit.PhysicalStockQty;
        $scope.StockAuditDetail.OldStockQty = aStockAudit.OldStockQty;
    }
    $scope.ResetItem = function () {
        Clear();
    }
    $scope.ClearBtn = function () {
        //clear();
        $scope.SearchItem = "";
        StockAuditGetPaged(1);
    }
    $scope.SearchBtn = function () {
        StockAuditGetPaged(1);
    }
});