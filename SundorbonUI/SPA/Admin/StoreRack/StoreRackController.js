app.controller("StoreRackController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.button = "Save";
    $scope.StoreRackList = [];

    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        // $scope.ad_MeasurementUnit.CreatorId = $scope.LoginUser.CreatorId;
        //$scope.ad_ItemGroup.UpdatorId = $scope.LoginUser.UserId;

    }
    Clear();
    function Clear() {

        $scope.ad_StoreRack = {};
        $scope.ad_StoreRack.IsActive = true;
        $scope.ddlStore = null;
        $scope.ad_StoreRack.CreatorId = $scope.LoginUser.CreatorId;
        $scope.ad_StoreRack.UpdatorId = $scope.LoginUser.UserId;
        $scope.button = "Save";

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        GetAllStore();
        _StoreRackGetPaged($scope.currentPage);

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
        $scope.ddlStore = null;
        $scope.StoreList = {};
        GetAllStore();
    }


    $scope.StoreRackSave = function () {
        var isValid = true;
        if ($scope.ad_StoreRack.RackDescription == null || $scope.ad_StoreRack.RackDescription == undefined || $scope.ad_StoreRack.RackDescription == "") {
            toastr.error('Rack Description can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ddlStore == null || $scope.ddlStore == undefined ) {
            toastr.error('Store can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            $scope.ad_StoreRack.StoreId = $scope.ddlStore.Id;
            var parms = JSON.stringify({ _ad_StoreRack: $scope.ad_StoreRack });
            var titleText = "Do you want to save?";
            if ($scope.button == "Update") {
                titleText = "Do you want to update?";
            }
            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/StoreRack/Save', parms).success(function (data) {
                        if (data > 0) {

                            //$scope.paymentGroupForm.$setPristine();
                            //$scope.paymentGroupForm.$setUntouched();
                            if ($scope.button == "Update") {
                                toastr.success('Item updated successfully.');
                            }
                            else {
                                toastr.success('Item saved successfully.');
                            }
                            Clear();
                        } else {
                            alertify.log('Server Errors!', 'error', '5000');
                        }
                    }).error(function (data) {
                        alertify.log('Server Errors!', 'error', '5000');
                    });
                }
                else if (result.dismiss == "cancel") {
                    Swal.DismissReason.cancel;
                }
            })

        }


    }


    $scope.DuplicateGroupName = function () {
        var StoreRack = $scope.ad_StoreRack.StoreRackPercent.trim();
        var StoreRack = $scope.ad_StoreRack.PercentNumber.trim();
        angular.forEach($scope.StoreRackList, function (aData) {

            if (aData.StoreRackPercent == StoreRack) {
                $scope.StoreRack.StoreRackPercent = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            if (aData.PercentNumber == StoreRack) {
                $scope.StoreRack.PercentNumber = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            //if (aData.DepartmentName.match(/Production/gi)) {
            //    aData.DepartmentName = aData.DepartmentName + ' ~ ' + aData.BranchName;
            //    $scope.Storelist.push(aData);
            //}
        });



    }
    $scope.SelStoreRack = function (StoreRack) {

        $scope.ad_StoreRack = StoreRack;
        $scope.button = "Update";
        $scope.ddlStore = { Id: StoreRack.StoreId };
        //  $scope.btnDeleleShow = false;
    }

    function _StoreRackGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "RackDescription LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/StoreRack/StoreRackGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.StoreRackList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.SearchBtn = function () {
        _StoreRackGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            _StoreRackGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            _StoreRackGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            _StoreRackGetPaged($scope.currentPage);
        }
    }
  

});