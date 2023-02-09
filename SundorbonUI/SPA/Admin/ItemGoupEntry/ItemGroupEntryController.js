app.controller("ItemGroupEntryController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    $scope.ad_ItemGroup = {};
    $scope.ad_ItemGroup.GroupName = '';
    $scope.ad_ItemGroup.IsActive = true;
    $scope.ad_ItemGroup.CreatorId = 0;
    $scope.ItemGroupList = [];
    $scope.button = "Save";

    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        $scope.ad_ItemGroup.CreatorId = $scope.LoginUser.CreatorId;
        //$scope.ad_ItemGroup.UpdatorId = $scope.LoginUser.UserId;

    }
    Clear();
    function Clear() {

       
        $scope.ad_ItemGroup = {};
        $scope.ad_ItemGroup.GroupName = '';
        $scope.ad_ItemGroup.IsActive = true;
        $scope.ad_ItemGroup.CreatorId = 0;
        $scope.ad_ItemGroup.UpdatorId = 0;
        $scope.ItemGroupList = [];

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        ItemGroupGetPaged($scope.currentPage);

    }

    $scope.ItemGroupSave = function () {
        var isValid = false;
        if ($scope.ad_ItemGroup.GroupName == null || $scope.ad_ItemGroup.GroupName == undefined || $scope.ad_ItemGroup.GroupName == "") {
            toastr.error('Group name can not be null or empty');
            isValid = false;
        }
        else {
            isValid = true;
        }
        if (isValid) {
            var parms = JSON.stringify({ _ItemGroup: $scope.ad_ItemGroup });
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
                    $http.post('/ItemGroup/Save', parms).success(function (data) {
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
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            ItemGroupGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            ItemGroupGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            ItemGroupGetPaged($scope.currentPage);
        }
    }

    $scope.SearchBtn = function () {
        ItemGroupGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        ItemGroupGetPaged(1);
        $scope.ad_ItemGroup = {};
        $scope.ad_ItemGroup.IsActive = true;
        $scope.button = "Save";
    }

    $scope.DuplicateGroupName = function () {
        var ItemGroupName = $scope.ad_ItemGroup.GroupName.trim();
        angular.forEach($scope.ItemGroupList, function (aData) {
           
            if (aData.GroupName == ItemGroupName) {
                $scope.ItemGroup.GroupName = "";
                alert("Item Alredy Exists Please Enter another Item !!!!");
            }
            //if (aData.DepartmentName.match(/Production/gi)) {
            //    aData.DepartmentName = aData.DepartmentName + ' ~ ' + aData.BranchName;
            //    $scope.Storelist.push(aData);
            //}
        });      
    }

    $scope.GetCropSearch = function () {
        ItemGroupGetPaged(1);
    }

    $scope.SelGroup= function (group) {

        $scope.ad_ItemGroup = group;
        $scope.button = "Update";
      //  $scope.btnDeleleShow = false;
    }

    function ItemGroupGetPaged(curPage) {
        

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "GroupName LIKE '%" + $scope.SearchItem + "%'";

        }

        //if (curPage == null) curPage = 1;
        //var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        //var SearchCriteria = "1=1";

        $http({
            url: encodeURI('/ItemGroup/ItemGroupPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ItemGroupList = data.ListData;
            $scope.total_count = data.TotalRecord;
        });
    }


});