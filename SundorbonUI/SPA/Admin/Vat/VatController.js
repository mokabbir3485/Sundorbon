app.controller("VATController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    $scope.ad_MeasurementUnit = {};
    $scope.ad_MeasurementUnit.UnitDescription = '';
    $scope.ad_MeasurementUnit.IsActive = true;
    $scope.ad_MeasurementUnit.CreatorId = 0;
    $scope.button = "Save";
    $scope.VATList = [];

    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        // $scope.ad_MeasurementUnit.CreatorId = $scope.LoginUser.CreatorId;
        //$scope.ad_ItemGroup.UpdatorId = $scope.LoginUser.UserId;

    }
    Clear();
    function Clear() {

        $scope.ad_VAT = {};
        $scope.ad_VAT.VatPercent = '';
        $scope.ad_VAT.PercentNumber = '';
        $scope.ad_VAT.IsActive = true;
        $scope.ad_VAT.CreatorId = $scope.LoginUser.CreatorId;
        $scope.ad_VAT.UpdatorId = $scope.LoginUser.UserId;
        $scope.button = "Save";

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        _VatGetPaged($scope.currentPage);

    }

    $scope.VATSave = function () {
        var isValid = true;
        if ($scope.ad_VAT.VatPercent == null || $scope.ad_VAT.VatPercent == undefined || $scope.ad_VAT.VatPercent == "") {
            toastr.error('Vat percent can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_VAT.PercentNumber == null || $scope.ad_VAT.PercentNumber == undefined || $scope.ad_VAT.PercentNumber == "") {
            toastr.error('Percent Number can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            var parms = JSON.stringify({ _VAT: $scope.ad_VAT });
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
                    $http.post('/VAT/Save', parms).success(function (data) {
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
        var VAT = $scope.ad_VAT.VatPercent.trim();
        var VAT = $scope.ad_VAT.PercentNumber.trim();
        angular.forEach($scope.VATList, function (aData) {

            if (aData.VatPercent == VAT) {
                $scope.VAT.VatPercent = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            if (aData.PercentNumber == VAT) {
                $scope.VAT.PercentNumber = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            //if (aData.DepartmentName.match(/Production/gi)) {
            //    aData.DepartmentName = aData.DepartmentName + ' ~ ' + aData.BranchName;
            //    $scope.Storelist.push(aData);
            //}
        });



    }
    $scope.SelVat = function (Vat) {

        $scope.ad_VAT = Vat;
        $scope.button = "Update";
        //  $scope.btnDeleleShow = false;
    }

    function _VatGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "VatPercent LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/VAT/VATPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.VATList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.SearchBtn = function () {
        _VatGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        _VatGetPaged(1);
        $scope.ad_VAT = {};
        $scope.ad_VAT.IsActive = true;
        $scope.button = "Save";
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            _VatGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            _VatGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            _VatGetPaged($scope.currentPage);
        }
    }
});