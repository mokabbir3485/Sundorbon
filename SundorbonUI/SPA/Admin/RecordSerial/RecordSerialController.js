app.controller("RecordSerialController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
    console.log(CounterData);

    $scope.ad_RecordSerial= {};
    Clear();
    function Clear() {

        $scope.ad_RecordSerial= {};
        $scope.button = "Save";
        $scope.ddlCounter = null;
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
       // CounterGetAll();
        RecordSerialGetPaged($scope.currentPage);

    }
    //function CounterGetAll() {
    //    $http({
    //        url: "/Counter/GetAll",
    //        method: 'GET',
    //        headers: { 'Content-Type': 'application/json' }
    //    }).success(function (data) {

    //        $scope.CounterList = data;


    //    });
    //}

    function RecordSerialGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "Prefix LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/RecordSerial/RecordSerialPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.RecordSerialList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.RecordSerialSave = function () {
        var isValid = true;
        if ($scope.ad_RecordSerial.Prefix == null || $scope.ad_RecordSerial.Prefix == undefined || $scope.ad_RecordSerial.Prefix == "") {
            toastr.error('Prefix can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_RecordSerial.MaxSlNo == null || $scope.ad_RecordSerial.MaxSlNo == undefined || $scope.ad_RecordSerial.MaxSlNo == "") {
            toastr.error('MaxSlNo can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_RecordSerial.TableName == null || $scope.ad_RecordSerial.TableName == undefined || $scope.ad_RecordSerial.TableName == "") {
            toastr.error('Table Name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        //if ($scope.ddlCounter== null || $scope.ddlCounter== undefined) {
        //    toastr.error('RecordSerialcan not be null or empty');
        //    isValid = false;
        //}
        //else {
        //    if (isValid) {
        //        isValid = true;
        //    }

        //}
        //if ($scope.ad_MeasurementUnit.IsActive) {

        //}
        if (isValid) {
            $scope.ad_RecordSerial.MotherCompanyId = 2;
            $scope.ad_RecordSerial.CounterId = CounterData.Id;
            $scope.ad_RecordSerial.UpdatorId = $scope.LoginUser.UserId;
            $scope.ad_RecordSerial.CreatorId = $scope.LoginUser.UserId;
            var parms = JSON.stringify({ _ad_RecordSerial: $scope.ad_RecordSerial});
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
                    $http.post('/RecordSerial/Save', parms).success(function (data) {
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
        RecordSerialGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        $scope.button = "Save";
    }
    $scope.UpdateRecordSerial= function (Itemobj) {

        $scope.button = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});
        $scope.ddlCounter = { Id: Itemobj.CounterId };
        $scope.ad_RecordSerial= Itemobj;
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            RecordSerialGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            RecordSerialGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            RecordSerialGetPaged($scope.currentPage);
        }
    }
});