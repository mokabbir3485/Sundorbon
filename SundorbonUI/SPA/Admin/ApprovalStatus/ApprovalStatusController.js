app.controller("ApprovalStatusController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();
    function Clear() {
        $scope.SearchItem = "";
        $scope.ad_ApprovalStatus = {};
        $scope.ad_ApprovalStatus.Isactive = true;
        $scope.ad_ApprovalStatus.CreatorId = $scope.LoginUser.CreatorId;
        $scope.ad_ApprovalStatus.UpdatorId = $scope.LoginUser.UserId;
        $scope.button = "Save";

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        ApprovalStatusGetPaged($scope.currentPage);

    }
    function ApprovalStatusGetPaged(curPage) {
        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "Status LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/ApprovalStatus/ApprovalStatusPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ApprovalStatusList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.SearchBtn = function () {
        ApprovalStatusGetPaged(1);
    }
    $scope.ClearBtn = function () {
        Clear();
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            ApprovalStatusGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            ApprovalStatusGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            ApprovalStatusGetPaged($scope.currentPage);
        }
    }
    $scope.SelApprovalStatus = function (ApprovalStatus) {

        $scope.ad_ApprovalStatus = ApprovalStatus;
        $scope.button = "Update";
        //  $scope.btnDeleleShow = false;
    }
    $scope.VATSave = function () {
        var isValid = true;
        if ($scope.ad_ApprovalStatus.Status == null || $scope.ad_ApprovalStatus.Status == undefined || $scope.ad_ApprovalStatus.Status == "") {
            toastr.error('Status can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.ad_ApprovalStatus.Isactive == null || $scope.ad_ApprovalStatus.Isactive == undefined ) {
            toastr.error('Is Active can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            var parms = JSON.stringify({ _ApprovalStatus: $scope.ad_ApprovalStatus });
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
                    $http.post('/ApprovalStatus/Save', parms).success(function (data) {
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
        var VAT = $scope.ad_ApprovalStatus.Status.trim();
        angular.forEach($scope.ApprovalStatusList, function (aData) {

            if (aData.ad_ApprovalStatus.Status == VAT) {
                $scope.VAT.VatPercent = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            //if (aData.DepartmentName.match(/Production/gi)) {
            //    aData.DepartmentName = aData.DepartmentName + ' ~ ' + aData.BranchName;
            //    $scope.Storelist.push(aData);
            //}
        });



    }
});