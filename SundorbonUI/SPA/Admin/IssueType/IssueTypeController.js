app.controller("IssueTypeController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();
    function Clear() {
       

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        IssueTypeGetPaged($scope.currentPage);

        $scope.IssueType = {};
        $scope.IssueType.IsActive = true;

        $scope.BtnName = "Save";
        // GetAllData();
    }


    $scope.IssueTypeSave = function () {
        var isValid = true;
        if ($scope.IssueType.IssueType == null || $scope.IssueType.IssueType== undefined) {
            toastr.error('Issue Type can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }
        if ($scope.IssueType.IsActive == null || $scope.IssueType.IsActive == undefined) {
            toastr.error('Is Active can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }

        if (isValid) {
            $scope.IssueType.UpdatorId = $scope.LoginUser.UserId;
            $scope.IssueType.CreatorId = $scope.LoginUser.UserId;
            var parms = JSON.stringify({ _ad_IssueType: $scope.IssueType });
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
                    $http.post('/IssuesType/Save', parms).success(function (data) {
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

    $scope.SelIssueType = function (Itemobj) {

        $scope.BtnName = "Update";

        $scope.IssueType = Itemobj;
       
    }

    $scope.ResetItem = function () {
        Clear();
    }

    function IssueTypeGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "IssueType LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/IssuesType/IssuesTypePaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.IssueTypeList = data.ListData;
            $scope.total_count = data.TotalRecord; 
            ChangeClassForPaginationAndReport();

        });
    }



    $scope.SearchBtn = function () {

        IssueTypeGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        Clear();
        //IssueTypeGetPaged(1);
    }

    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            IssueTypeGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            IssueTypeGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            IssueTypeGetPaged($scope.currentPage);
        }
    }

   


});