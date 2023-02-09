app.controller("DepartmentController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.ad_Department = {};
    Clear();
    function Clear() {

        $scope.ad_Department = {};
        $scope.BranchList = null;
        $scope.button = "Save";

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        GetAllBranch();
        _DepartmentGetPaged($scope.currentPage);
    }
    function GetAllBranch() {
        $http({
            url: "/Branch/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.BranchList = data;


        });
    }

    $scope.ReloadBranch = function () {
        $scope.BranchList = null;
        $scope.BranchList = {};
        GetAllBranch();
    }

    function _DepartmentGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "DepartmentName LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/Department/DepartmentPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.DepartmentList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.DepartmentSave = function () {
        var isValid = true;
        if ($scope.ad_Department.DepartmentName == null || $scope.ad_Department.DepartmentName == undefined || $scope.ad_Department.DepartmentName == "") {
            toastr.error('Department name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_Department.Address1 == null || $scope.ad_Department.Address1 == undefined || $scope.ad_Department.Address1=="") {
            toastr.error('Address One can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_Department.Address2 == null || $scope.ad_Department.Address2 == undefined || $scope.ad_Department.Address2 == "") {
            toastr.error('Address two can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ddlBranch == null || $scope.ddlBranch == undefined) {
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
            $scope.ad_Department.BranchId = $scope.ddlBranch.Id;
            var parms = JSON.stringify({ _ad_Depertment: $scope.ad_Department });
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
                    $http.post('/Department/Save', parms).success(function (data) {
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
        _DepartmentGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        $scope.button = "Save";
    }
    $scope.UpdateDepartment = function (Itemobj) {

        $scope.button = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});
        $scope.ad_Department = Itemobj;
        $scope.ddlBranch = { Id: Itemobj.BranchId };
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            _DepartmentGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            _DepartmentGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            _DepartmentGetPaged($scope.currentPage);
        }
    }
});