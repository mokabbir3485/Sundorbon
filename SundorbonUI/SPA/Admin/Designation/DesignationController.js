app.controller("DesignationController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();


    function Clear() {
        $scope.ad_Designation = {};
       // $scope.ad_Designation.SerialNo = 0;

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        DesignationGetPaged($scope.currentPage);

        $scope.button = "Save";
        $scope.ddlDepartment = null;
        $scope.ddlSerial = null;
        $scope.DepartmentList = [];
        $scope.DesignationList = [];
     
        //=====Method Call 
        GetAllDepartment();

        $scope.Serial = 0;
      
      
       

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
        $scope.ddlDepartment = null;
        $scope.DepartmentList = [];
        GetAllDepartment();
    }
  

    $scope.DesignationSave = function () {

        var isValid = false;
        var isValid1 = false;
        if ($scope.ad_Designation.DesignationName == undefined || $scope.ad_Designation.DesignationName == "") {
            toastr.error('Designation  can not be empty');
            isValid = false;
          
        }
        else {
            isValid = true;
          
        }
        if ($scope.ddlDepartment == null || $scope.ddlDepartment == undefined) {
            toastr.error('Department  can not be  empty');
            isValid1 = false;
           
        } else {
            isValid1 = true;
          
        }
        if (isValid && isValid1) {

            $scope.ad_Designation.DepartmentId = $scope.ddlDepartment.Id;
            $scope.ad_Designation.UpdatorId = $scope.LoginUser.UserId;
            $scope.ad_Designation.CreatorId = $scope.LoginUser.UserId;

            var parms = JSON.stringify({ _ad_Designation: $scope.ad_Designation });
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
                    $http.post('/Designation/Save', parms).success(function (data) {
                        if (data > 0) {
                            if ($scope.button == "Update") {
                                toastr.success('Designation updated successfully.');
                            }
                            else {
                                toastr.success('Designation saved successfully.');
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
            DesignationGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            DesignationGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            DesignationGetPaged($scope.currentPage);
        }
    }

    $scope.SearchBtn = function () {
        DesignationGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
      //  DesignationGetPaged(1);
        Clear();
    }


    //$scope.GetCropSearch = function () {
    //    ItemGroupGetPaged(1);
    //}

    $scope.UpdateDesignation = function (Des) {

        $scope.ad_Designation = Des;

        $scope.ddlDepartment = { Id: Des.DepartmentId}
        $scope.button = "Update";
     
    }

    function DesignationGetPaged(curPage) {


        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "DesignationName LIKE '%" + $scope.SearchItem + "%' OR SerialNo LIKE '%" + $scope.SearchItem + "%'";

        }

        //if (curPage == null) curPage = 1;
        //var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        //var SearchCriteria = "1=1";

        $http({
            url: encodeURI('/Designation/GetDesignationPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.DesignationList = data.ListData;
            $scope.total_count = data.TotalRecord;

            angular.forEach(data.ListData,function (adata) {
                if ($scope.ad_Designation.SerialNo == undefined || $scope.ad_Designation.SerialNo == null) {

                    $scope.ad_Designation.SerialNo = adata.SerialNo + 1;
                }
            })
        });
    }



});