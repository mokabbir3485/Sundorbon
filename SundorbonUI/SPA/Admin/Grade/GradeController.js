app.controller("GradeController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();


    function Clear() {
        $scope.ad_Grade = {};
        // $scope.ad_Grade.SerialNo = 0;

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        GradeGetPaged($scope.currentPage);
        $scope.GradeList = [];
        $scope.button = "Save";
   

     
    }


   



    $scope.GradeSave = function () {

        var isValid = false;
       
        if ($scope.ad_Grade.Grade == undefined || $scope.ad_Grade.Grade == "") {
            toastr.error('Grade  can not be empty');
            isValid = false;

        } else {
            isValid = true;
        }
      
        if (isValid) {
          
            $scope.ad_Grade.UpdatorId = $scope.LoginUser.UserId;
            $scope.ad_Grade.CreatorId = $scope.LoginUser.UserId;

            var parms = JSON.stringify({ _ad_Grade: $scope.ad_Grade });

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
                    $http.post('/Designation/GradeSave', parms).success(function (data) {
                        if (data > 0) {
                            if ($scope.button == "Update") {
                                toastr.success('Grade updated successfully.');
                            }
                            else {
                                toastr.success('Grade saved successfully.');
                            }
                            Clear();
                        } else {
                            toastr.error('Server Errors  5000');
                        }
                    }).error(function (data) {
                        toastr.error('Server Errors!', 'error', '5000');
                    });
                }
                else if (result.dismiss == "cancel") {
                    Swal.DismissReason.cancel;
                }
            })

        }


    }



    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            GradeGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            GradeGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            GradeGetPaged($scope.currentPage);
        }
    }

    $scope.SearchBtn = function () {
        GradeGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        //  GradeGetPaged(1);
        Clear();
    }


    //$scope.GetCropSearch = function () {
    //    ItemGroupGetPaged(1);
    //}

    $scope.UpdateGrade = function (Des) {

        $scope.ad_Grade = Des;

        $scope.ddlDepartment = { Id: Des.DepartmentId }
        $scope.button = "Update";

    }

    function GradeGetPaged(curPage) {


        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "Grade LIKE '%" + $scope.SearchItem + "%' ";

        }

        //if (curPage == null) curPage = 1;
        //var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        //var SearchCriteria = "1=1";

        $http({
            url: encodeURI('/Designation/GetGradeGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.GradeList = data.ListData;
            $scope.total_count = data.TotalRecord;

           
        });
    }



});