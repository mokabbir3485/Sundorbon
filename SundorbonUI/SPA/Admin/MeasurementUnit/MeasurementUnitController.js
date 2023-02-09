app.controller("MeasurementUnitController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    $scope.ad_MeasurementUnit = {};
    $scope.ad_MeasurementUnit.UnitDescription = '';
    $scope.ad_MeasurementUnit.IsActive = true;
    $scope.ad_MeasurementUnit.CreatorId = 0;
    $scope.MeasurementUnitList = [];
    $scope.button = "SAVE";

    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
       // $scope.ad_MeasurementUnit.CreatorId = $scope.LoginUser.CreatorId;
        //$scope.ad_ItemGroup.UpdatorId = $scope.LoginUser.UserId;

    }
    Clear();
    function Clear() {

        $scope.ad_MeasurementUnit = {};
        $scope.ad_MeasurementUnit.UnitDescription = '';
        $scope.ad_MeasurementUnit.IsActive = true;
        $scope.ad_MeasurementUnit.CreatorId = $scope.LoginUser.CreatorId;
        $scope.ad_MeasurementUnit.UpdatorId = $scope.LoginUser.UserId;
        $scope.button = "SAVE";

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        MeasurementUnitGetPaged($scope.currentPage);

    }

    $scope.MeasurementUnitSave = function () {
        var isValid = false;
        if ($scope.ad_MeasurementUnit.UnitDescription == null || $scope.ad_MeasurementUnit.UnitDescription == undefined || $scope.ad_MeasurementUnit.UnitDescription == "") {
            toastr.error('Measurement unit name can not be null or empty');
            isValid = false;
        }
        else {
            isValid = true;
        }
        //if ($scope.ad_MeasurementUnit.IsActive) {

        //}
        if (isValid) {
            var parms = JSON.stringify({ _MeasurementUnit: $scope.ad_MeasurementUnit });
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
                    $http.post('/MeasurementUnit/Save', parms).success(function (data) {
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
    $scope.SelGroup = function (group) {

        $scope.ad_MeasurementUnit = group;
        $scope.button = "Update";
        //  $scope.btnDeleleShow = false;
    }
    
    $scope.DuplicateGroupName = function () {
        var MeasurementUnit = $scope.ad_MeasurementUnit.UnitDescription.trim();
        angular.forEach($scope.MeasurementUnitList, function (aData) {

            if (aData.UnitDescription == MeasurementUnit) {
                $scope.MeasurementUnit.UnitDescription = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            //if (aData.DepartmentName.match(/Production/gi)) {
            //    aData.DepartmentName = aData.DepartmentName + ' ~ ' + aData.BranchName;
            //    $scope.Storelist.push(aData);
            //}
        });



    }

    function MeasurementUnitGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "UnitDescription LIKE '%" + $scope.SearchItem + "%'";

        }

        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/MeasurementUnit/MeasurementUnitPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.MeasurementUnitList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            MeasurementUnitGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            MeasurementUnitGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            MeasurementUnitGetPaged($scope.currentPage);
        }
    }
    $scope.SearchBtn = function () {
        MeasurementUnitGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        MeasurementUnitGetPaged(1);
        $scope.ad_MeasurementUnit = {};
        $scope.ad_MeasurementUnit.IsActive = true;
        $scope.button = "Save";
    }
    //function MeasurementUnitGetPaged(curPage) {


    //    if (curPage == null) curPage = 1;
    //    var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

    //    var SearchCriteria = "";

    //    if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
    //        SearchCriteria = "UnitDescription LIKE '%" + $scope.SearchItem + "%'";

    //    }

    //    //if (curPage == null) curPage = 1;
    //    //var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

    //    //var SearchCriteria = "1=1";

    //    $http({
    //        url: encodeURI('/MeasurementUnit/ItemGroupPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
    //        method: 'GET',
    //        headers: { 'Content-Type': 'application/json' }
    //    }).success(function (data) {

    //        $scope.MeasurementUnitList = data.ListData;
    //        $scope.total_count = data.TotalRecord;
    //    });
    //}
});