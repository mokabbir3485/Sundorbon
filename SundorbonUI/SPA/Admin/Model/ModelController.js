app.controller("ModelController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");


    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
     
        //$scope.ad_ItemGroup.UpdatorId = $scope.LoginUser.UserId;

    }
    Clear();
    function Clear() {

        $scope.ad_Model = {};
        $scope.ad_Model.Name = '';
        $scope.ad_Model.IsActive = true;
        $scope.ad_Model.CreatorId = 0;
        $scope.ModelList = [];

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        $scope.button = "SAVE";
        ModelGetPaged($scope.currentPage);

    }

    $scope.ModelSave = function () {
        var isValid = false;
        if ($scope.ad_Model.Name == null || $scope.ad_Model.Name == undefined || $scope.ad_Model.Name == "") {
            toastr.error('Model Name can not be null or empty');
            isValid = false;
        }
        else {
            isValid = true;
        }
        if (isValid) {
            $scope.ad_Model.CreatorId = $scope.LoginUser.UserId;
            $scope.ad_Model.UpdatorId = $scope.LoginUser.UserId;
            var aa = $scope.ad_Model;
            var parms = JSON.stringify({ _ad_Model: $scope.ad_Model });
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
                    $http.post('/Model/Save', parms).success(function (data) {
                        if (data > 0) {
                            if ($scope.button == "Update") {
                                toastr.success('Item updated successfully.');
                            }
                            else {
                                toastr.success('Item saved successfully.');
                            }
                            Clear();
                        } else {
                            toastr.error('Data Not save.');
                        }
                    }).error(function (data) {
                        toastr.error('Server Errors!');
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
        var ModelName = $scope.ad_Model.Name.trim();
        angular.forEach($scope.ModelList, function (aData) {

            if (aData.Name == ModelName) {
                $scope.Model.Name = "";
                alert("Item Alredy Exists Please Entry another Item !!!!");
            }
            //if (aData.DepartmentName.match(/Production/gi)) {
            //    aData.DepartmentName = aData.DepartmentName + ' ~ ' + aData.BranchName;
            //    $scope.Storelist.push(aData);
            //}
        });



    }
    $scope.SelModel = function (Model) {

        $scope.ad_Model = Model;
        $scope.button = "Update";
        //  $scope.btnDeleleShow = false;
    }
    
    function ModelGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "Name LIKE '%" + $scope.SearchItem + "%'";

        }
        //if ($scope.SearchIWOAndCompanyName != undefined && $scope.SearchIWOAndCompanyName != "" && $scope.FromDate != "" && $scope.ToDate != "") {
        //    SearchCriteria = "([IWO].[InternalWorkOrderDate] between '" + $scope.FromDate + "' and '" + $scope.ToDate + "') and ([IWO].[InternalWorkOrderNo] LIKE '%" + $scope.SearchIWOAndCompanyName + "%' OR [SO].[CompanyNameBilling] LIKE '%" + $scope.SearchIWOAndCompanyName + "%')";

        //}


        $http({
            url: encodeURI('/Model/ModelPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ModelList = data.ListData;
            $scope.total_count = data.TotalRecord;

        });
    }
    $scope.SearchBtn = function () {
        ModelGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        ModelGetPaged(1);
        $scope.ad_Model = {};
        $scope.ad_Model.IsActive = true;
        $scope.button = "Save";
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            ModelGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            ModelGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            ModelGetPaged($scope.currentPage);
        }
    }
});