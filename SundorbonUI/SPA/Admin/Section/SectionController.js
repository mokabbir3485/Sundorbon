
app.controller("SectionController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();


    function Clear() {
        $scope.ad_Section = {};
        // $scope.ad_Section.SerialNo = 0;

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        GetPagedSection($scope.currentPage);
        $scope.SectionList = [];
        $scope.button = "Save";
        $scope.DepartmentList = [];
        $scope.ddlDepartment = null;
        //Method Call
        GetAllDepartment();

    }

    function GetAllDepartment() {
        $http({
            url: "/Department/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.DepartmentList = data;
        });
    }

    $scope.ReloadDept = function () {
        $scope.DepartmentList = [];
        $scope.ddlDepartment = null;
        GetAllDepartment();
    }



    $scope.SectionSave = function () {

        var isValid = false;
         var  isValid1 = false;

        if ($scope.ad_Section.SectionName == undefined || $scope.ad_Section.SectionName == "") {
            toastr.error('Section  can not be empty');
            isValid = false;

        } else {
            isValid = true;
        }

        if ($scope.ddlDepartment == undefined || $scope.ddlDepartment == "") {
            toastr.error('Department  can not be empty');
            isValid1 = false;

        } else {
            isValid1 = true;
        }

        if (isValid && isValid1) {
            $scope.ad_Section.DepartmentId = $scope.ddlDepartment.Id;
            $scope.ad_Section.UpdatorId = $scope.LoginUser.UserId;
            $scope.ad_Section.CreatorId = $scope.LoginUser.UserId;

            var parms = JSON.stringify({ _ad_Section: $scope.ad_Section });

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
                    $http.post('/Designation/SaveSection', parms).success(function (data) {
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
            GetPagedSection($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            GetPagedSection($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            GetPagedSection($scope.currentPage);
        }
    }

    $scope.SearchBtn = function () {
        GetPagedSection(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        //  GetPagedSection(1);
        Clear();
    }


    //$scope.GetCropSearch = function () {
    //    ItemGroupGetPaged(1);
    //}

    $scope.UpdateSection = function (Des) {

        $scope.ad_Section = Des;

        $scope.ddlDepartment = { Id: Des.DepartmentId }
        $scope.button = "Update";

    }

    function GetPagedSection(curPage) {


        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "SectionName LIKE '%" + $scope.SearchItem + "%' ";

        }

        //if (curPage == null) curPage = 1;
        //var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        //var SearchCriteria = "1=1";

        $http({
            url: encodeURI('/Designation/SectionGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.SectionList = data.ListData;
            $scope.total_count = data.TotalRecord;


        });
    }



});