app.controller("StoreController", function ($scope, $filter,$http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.ad_Store = {};
    Clear();
    function Clear() {

        $scope.ad_Store = {};
        $scope.BranchList = null;
        $scope.DeptList = {};
        $scope.button = "Save";
        $scope.ad_Store.IsActive = true;
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        GetAllDept();
        _StoreGetPaged($scope.currentPage);
    }
    function GetAllDept() {
        $http({
            url: "/Department/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.DeptList = data;


        });
    }

    $scope.ReloadDept = function () {
        $scope.ddlDept = null;
        $scope.DeptList = data;
        GetAllDept();
    }

    function _StoreGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "StoreName LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/Store/StoreGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.StoreList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.StoreSave = function () {
        var isValid = true;
        if ($scope.ad_Store.StoreName == null || $scope.ad_Store.StoreName == undefined || $scope.ad_Store.StoreName == "") {
            toastr.error('Store name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_Store.StoreLocation == null || $scope.ad_Store.StoreLocation == undefined || $scope.ad_Store.StoreLocation == "") {
            toastr.error('Store Location One can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_Store.IsActive == null || $scope.ad_Store.IsActive == undefined ) {
            toastr.error('IsActive can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ddlDept == null || $scope.ddlDept == undefined) {
            toastr.error('branch can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        //if ($scope.ad_MeasurementUnit.IsActive) {

        //}
        if (isValid) {
            $scope.ad_Store.DepartmentId = $scope.ddlDept.Id;
            var parms = JSON.stringify({ _ad_Store: $scope.ad_Store });
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
                    $http.post('/Store/Save', parms).success(function (data) {
                        if (data > 0) {
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
    $scope.SearchBtn = function () {
        _StoreGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        $scope.button = "Save";
    }
    $scope.UpdateStore = function (Itemobj) {

        $scope.button = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});
        $scope.ad_Store = Itemobj;
        $scope.ddlDept = { Id: Itemobj.DepartmentId };
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            _StoreGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            _StoreGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            _StoreGetPaged($scope.currentPage);
        }
    }
  

});