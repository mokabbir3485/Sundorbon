app.controller("RequisitionTypeController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();
    function Clear() {


        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        RequisitionTypeGetPaged($scope.currentPage);

        $scope.RequisitionType = {};
        $scope.RequisitionType.IsActive = true;

        $scope.BtnName = "Save";
        // GetAllData();
    }


    $scope.RequisitionTypeSave = function () {
        var isValid = true;
        if ($scope.RequisitionType.RequistionType == null || $scope.RequisitionType.RequistionType == undefined || $scope.RequisitionType.RequistionType == "") {
            toastr.error('RequisitionType can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.RequisitionType.IsActive == null || $scope.RequisitionType.IsActive == undefined) {
            toastr.error('Is Active can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }

        if (isValid) {
            $scope.RequisitionType.UpdatorId = $scope.LoginUser.UserId;
            $scope.RequisitionType.CreatorId = $scope.LoginUser.UserId;
            var parms = JSON.stringify({ _ad_RequistionType: $scope.RequisitionType });
            var titleText = "Do you want to save?";
            if ($scope.BtnName == "Update") {
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
                    $http.post('/RequisitionType/Save', parms).success(function (data) {
                        if (data > 0) {
                            if ($scope.BtnName == "Update") {
                                toastr.success('Item updated successfully.');
                            }
                            else {
                                toastr.success('Item saved successfully.');
                            }
                            Clear();
                        } else {

                        }
                    }).error(function (data) {

                    });
                }
                else if (result.dismiss == "cancel") {
                    Swal.DismissReason.cancel;
                }
            })
        }




    }

    $scope.SelRequisitionType = function (Itemobj) {

        $scope.BtnName = "Update";

        $scope.RequisitionType = Itemobj;

    }

    $scope.ResetItem = function () {
        Clear();
    }

    function RequisitionTypeGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "RequistionType LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/RequisitionType/RequisitionTypeGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.RequisitionTypeList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }



    $scope.SearchBtn = function () {

        RequisitionTypeGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        //RequisitionTypeGetPaged(1);
    }

    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            RequisitionTypeGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            RequisitionTypeGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            RequisitionTypeGetPaged($scope.currentPage);
        }
    }

  

});