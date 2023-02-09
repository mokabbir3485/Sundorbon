app.controller("CounterController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.ad_Counter = {};
    Clear();
    function Clear() {

        $scope.ad_Counter = {};
        $scope.button = "Save";
        $scope.ddlDepartments = null;
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        GetAllDepartments();
        _CounterGetPaged($scope.currentPage);

    }
    function GetAllDepartments() {
        $http({
            url: "/Department/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.DepartmentList = data;


        });
    }

    $scope.ReloadDept = function () {
        $scope.ddlDepartments = null;
        $scope.DepartmentList = {};
        GetAllDepartments();
    }

    function _CounterGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "CounterName LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/Counter/CounterPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.CounterList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.SearchBtn = function () {
        _CounterGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        $scope.button = "Save";
    }
    $scope.CounterSave = function () {
        var isValid = true;
        if ($scope.ad_Counter.CounterName == null || $scope.ad_Counter.CounterName == undefined || $scope.ad_Counter.CounterName == "") {
            toastr.error('Counter name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
            
        }
        if ($scope.ddlDepartments == null || $scope.ddlDepartments == undefined ) {
            toastr.error('Department can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_Counter.IPAddress == null || $scope.ad_Counter.IPAddress == undefined ) {
            toastr.error('IPAddress can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_Counter.ShortCode == null || $scope.ad_Counter.ShortCode == undefined || $scope.ad_Counter.ShortCode == "") {
            toastr.error('ShortCode can not be null or empty');
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
            $scope.ad_Counter.DepartmentId = $scope.ddlDepartments.Id;
            var parms = JSON.stringify({ _ad_Counter: $scope.ad_Counter });
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
                    $http.post('/Counter/Save', parms).success(function (data) {
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
    $scope.UpdateItem = function (Itemobj) {

        $scope.button = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});
        $scope.ad_Counter = Itemobj;
        $scope.ddlDepartments = { Id: Itemobj.DepartmentId };
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            _CounterGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            _CounterGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            _CounterGetPaged($scope.currentPage);
        }
    }
});