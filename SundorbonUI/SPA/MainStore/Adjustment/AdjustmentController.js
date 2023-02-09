app.controller("AdjustmentController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
    console.log(CounterData);
    Clear();
    var CounterPrefix = "";
    function Clear() {
        $scope.IsIncreasedList = [
            { Id: 1, IsIncreased: "YES" },
            { Id: 2, IsIncreased: "NO" }
        ];
        $scope.Updating = false;
        $scope.button = "Save";
        $scope.buttonAdjustmentDetails = "Add";
        $scope.Adjustment = {};
        $scope.AdjustmentDetail = {};
        $scope.ItemList = [];
        $scope.AdjustmentDetailList = [];
        $scope.EmployeeList = [];
        //$scope.CounterList = [];
        $scope.StoreRackList = [];
        
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        AdjustmentGetPaged($scope.currentPage);
        ///Method Call=====>>>
        GetAllItem();
        GetAllEmployee();
        //GetAllCounter();
        GetAllStoreRack();
    }

    function AdjustmentGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
           /* SearchCriteria = "ProductName LIKE '%" + $scope.SearchItem + "%'";*/
            SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%' OR AdjustmentDate LIKE '%" + $scope.SearchItem + "%'";
        }


        $http({
            url: encodeURI('/Adjustment/AdjustmentPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.AdjustmentList = data.ListData;
            $scope.total_count = data.TotalRecord;
            angular.forEach($scope.AdjustmentList, function (aData) {
                if (aData.AdjustmentDate != null) {
                    var res1 = aData.AdjustmentDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.AdjustmentDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'MMM dd, yyyy')).toString();
                        aData.AdjustmentDate = date1;
                    }
                }

            })
            var NumberString = data.ListData[0].Number;
            var num1 = Number(NumberString.substr(7, 17));
            num2 = num1 + 1;
            $scope.Adjustment.Number = NumberString.substr(0, 7) + (num2).toString();
        });
    }

    //function GetAllCounter() {
    //    $http({
    //        url: "/Counter/GetAll",
    //        method: 'GET',
    //        headers: { 'Content-Type': 'application/json' }
    //    }).success(function (data) {
    //        $scope.CounterList = data;
    //    });
    //}

    

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

    $scope.ReloadStoreRack = function () {
        $scope.StoreRackList = [];
        GetAllStoreRack();
    }
    $scope.ReloadItem = function () {
        $scope.ItemList = [];
        GetAllItem();
    }
    $scope.ReloadEmployee = function () {
        $scope.EmployeeList = [];
        GetAllEmployee();
    }
    //$scope.ReloadCounter = function () {
    //    $scope.CounterList = [];
    //    GetAllCounter();
    //}
    $scope.addAdjustmentDetail = function () {
        var isValid = true;
        if ($scope.AdjustmentDetail.AdjstedUnitPrice == null || $scope.AdjustmentDetail.AdjstedUnitPrice == undefined) {
            toastr.error('Adjsted Unit Price can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlItem == null || $scope.ddlItem == undefined) {
            toastr.error('Item can not be null or empty');
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
        if ($scope.ddlIsIncreased == null || $scope.ddlIsIncreased == undefined) {
            toastr.error('Is Increased can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.AdjustmentDetail.AdjustedQty == null || $scope.AdjustmentDetail.AdjustedQty == undefined || $scope.AdjustmentDetail.AdjustedQty == "") {
            toastr.error('Adjusted Qty can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.AdjustmentDetail.AdjstedUnitPrice == null || $scope.AdjustmentDetail.AdjstedUnitPrice == undefined || $scope.AdjustmentDetail.AdjstedUnitPrice == "") {
            toastr.error('Adjsted Unit Price can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.AdjustmentDetail.Remarks == null || $scope.AdjustmentDetail.Remarks == undefined || $scope.AdjustmentDetail.Remarks == "") {
            toastr.error('Remarks can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            $scope.AdjustmentDetail.ItemId = $scope.ddlItem.Id;
            $scope.AdjustmentDetail.Combination = $scope.ddlItem.Combination;
            $scope.AdjustmentDetail.Rack = $scope.ddlStoreRack.RackDescription;
            $scope.AdjustmentDetail.RackId = $scope.ddlStoreRack.Id;
            if ($scope.ddlIsIncreased.IsIncreased == "YES") {
                $scope.AdjustmentDetail.IsIncreased = true
            }
            else {
                $scope.AdjustmentDetail.IsIncreased = false;
            }
            if ($scope.AdjustmentDetail.Id == null || $scope.AdjustmentDetail.Id == undefined) {
                $scope.AdjustmentDetailList.push($scope.AdjustmentDetail);
            }
            else {
                angular.forEach($scope.AdjustmentDetailList, function (aData) {
                    if (aData.Id == $scope.AdjustmentDetail.Id) {
                        var item = Object.values($scope.ItemList).filter(x => x.Id == $scope.ddlItem.Id);
                        var StoreRack = Object.values($scope.StoreRackList).filter(x => x.Id == $scope.ddlStoreRack.Id);
                        aData.ItemId = $scope.ddlItem.Id;
                        aData.Combination = item[0].Combination;
                        aData.Rack = StoreRack[0].RackDescription;
                        aData.RackId = $scope.ddlStoreRack.Id;
                        aData.IsIncreased = $scope.AdjustmentDetail.IsIncreased;
                        aData.AdjustedQty = $scope.AdjustmentDetail.AdjustedQty;
                        aData.AdjstedUnitPrice = $scope.AdjustmentDetail.AdjstedUnitPrice;
                        aData.Remarks = $scope.AdjustmentDetail.Remarks;
                    }
                   
                })
            }
            $scope.AdjustmentDetailList.p
            $scope.AdjustmentDetail = {};
            $scope.ddlItem = null;
            $scope.ddlStoreRack = null;
            $scope.ddlIsIncreased = null;
        }
       
    }

    $scope.Remove = function (aReqDetail) {
        var ind = $scope.AdjustmentDetailList.indexOf(aReqDetail);
        $scope.AdjustmentDetailList.splice(ind, 1);
    }

    $scope.AdjustmentSave = function () {
        var isValid = true;
        if ($scope.Adjustment.AdjustmentDate == null || $scope.Adjustment.AdjustmentDate == undefined) {
            toastr.error('Adjustment Date can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        
        if ($scope.Adjustment.AdjustedReason == null || $scope.Adjustment.AdjustedReason == undefined || $scope.Adjustment.AdjustedReason=="") {
            toastr.error('Adjusted Reason can not be null or empty');
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
        //if ($scope.CounterId == null || $scope.CounterId == undefined) {
        //    toastr.error('Counter Id can not be null or empty');
        //    isValid = false;
        //}
        //else {
        //    if (isValid) {
        //        isValid = true;
        //    }
        //}
       
        if (isValid) {
            $scope.Adjustment.CreatorId = $scope.LoginUser.UserId;
            $scope.Adjustment.UpdatorId = $scope.LoginUser.UserId;
            $scope.Adjustment.CounterId = CounterData.Id;
            $scope.Adjustment.AdjustedByUserId = $scope.ddlEmployee.EmployeeId;
            var transactionType = "INSERT";
            var titleText = "Do you want to save?";
            if ($scope.button == "Update") {
                titleText = "Do you want to update?";
                transactionType = "UPDATE";
            }
            else {
                $scope.Adjustment.Number = CounterData.ShortCode;
            }

            var parms = JSON.stringify({ _Adjustment: $scope.Adjustment, _Adjustment_Details_list: $scope.AdjustmentDetailList, transactiontionType: transactionType });
            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/Adjustment/Save', parms).success(function (data) {
                        if (data !=null) {
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

    function GetAllAdjustmentDetailsFromAdjustmentId(Number) {
        $http({
            
            url: encodeURI('/Adjustment/GetAllAdjustmentDetailsFromAdjustmentId?Number=' + Number),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.AdjustmentDetailList = data;
            angular.forEach($scope.AdjustmentDetailList, function (aData) {
                var item = Object.values($scope.ItemList).filter(x => x.Id == aData.ItemId);
                var StoreRack = Object.values($scope.StoreRackList).filter(x => x.Id == aData.RackId);
                aData.Combination = item[0].Combination;
                aData.Rack = StoreRack[0].RackDescription;
                $scope.Updating = true;
            })
        });
    }


    $scope.UpdateAdjustment = function (aAdjustment) {

        $scope.button = "Update";
        $scope.Adjustment.Number = aAdjustment.Number;
        $scope.Adjustment.AdjustedReason = aAdjustment.AdjustedReason;
        $scope.CounterId = { Id: aAdjustment.CounterId };
        $scope.ddlEmployee = { EmployeeId: aAdjustment.AdjustedByUserId };
       
        var date = aAdjustment.AdjustmentDate;
        $scope.Adjustment.AdjustmentDate = new Date(date.toString());
        GetAllAdjustmentDetailsFromAdjustmentId(aAdjustment.Number);
    }

    $scope.UpdateAdjustmentDetails = function (aAdjustment) {
        $scope.buttonAdjustmentDetails = "Update";
        $scope.AdjustmentDetail.Id = aAdjustment.Id;
        $scope.ddlItem = { Id: aAdjustment.ItemId };
        $scope.ddlStoreRack = { Id: aAdjustment.RackId };
        if (aAdjustment.IsIncreased == true) {
            $scope.ddlIsIncreased = { Id: 1 };
        }
        else {
            $scope.ddlIsIncreased = { Id: 2 };
        }
       
        $scope.AdjustmentDetail.AdjustedQty = aAdjustment.AdjustedQty;
        $scope.AdjustmentDetail.AdjstedUnitPrice = aAdjustment.AdjstedUnitPrice;
        $scope.AdjustmentDetail.Remarks = aAdjustment.Remarks;
       
    }
    $scope.ResetItem = function () {
        Clear();
    }
    $scope.ClearBtn = function () {
        //clear();
        $scope.SearchItem = "";
        AdjustmentGetPaged(1);
    }
    $scope.SearchBtn = function () {
        AdjustmentGetPaged(1);
    }
});