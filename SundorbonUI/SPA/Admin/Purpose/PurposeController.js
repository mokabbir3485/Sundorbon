app.controller("PurposeController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();
    function Clear() {


        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        PurposeGetPaged($scope.currentPage);

        $scope.Purpose = {};
        $scope.Purpose.IsActive = true;

        $scope.BtnName = "Save";
        // GetAllData();
    }


    $scope.PurposeSave = function () {
        var isValid = true;
        if ($scope.Purpose.Purpose == null || $scope.Purpose.Purpose == undefined || $scope.Purpose.Purpose=="") {
            toastr.error('Purpose can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.Purpose.IsActive == null || $scope.Purpose.IsActive == undefined) {
            toastr.error('Is Active can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }

        if (isValid) {
            $scope.Purpose.UpdatorId = $scope.LoginUser.UserId;
            $scope.Purpose.CreatorId = $scope.LoginUser.UserId;
            var parms = JSON.stringify({ _ad_Purpose: $scope.Purpose });
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
                    $http.post('/Purpose/Save', parms).success(function (data) {
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

    $scope.SelPurpose = function (Itemobj) {

        $scope.BtnName = "Update";

        $scope.Purpose = Itemobj;

    }

    $scope.ResetItem = function () {
        Clear();
    }

    function PurposeGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "Purpose LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/Purpose/PurposeGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.PurposeList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }



    $scope.SearchBtn = function () {

        PurposeGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        //PurposeGetPaged(1);
    }

    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            PurposeGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            PurposeGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            PurposeGetPaged($scope.currentPage);
        }
    }




  

});