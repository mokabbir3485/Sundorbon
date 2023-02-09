app.controller("SupplierController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.Supplier = {};
    Clear();
    function Clear() {

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        SupplierGetPaged($scope.currentPage);
        $scope.BtnName = "Save";
        $scope.Supplier = {};
        $scope.Supplier.IsActive = true;
        // GetAllData();
    }
    function SupplierGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "SupplierName LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/Supplier/ItemPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.SupplierList = data.ListData;
            $scope.total_count = data.TotalRecord;
            //  $scope.ItemList = data.dTable.results; 

        });
    }
    $scope.SearchBtn = function () {

        SupplierGetPaged(1);
    }
    $scope.ResetItem = function () {
        Clear();
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            SupplierGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            SupplierGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            SupplierGetPaged($scope.currentPage);
        }
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        SupplierGetPaged(1);
    }
    $scope.UpdateSupplier = function (Itemobj) {

        $scope.BtnName = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});
        $scope.Supplier = Itemobj;
        
    }

    $scope.SaveItem = function () {
        var isValid = true;
        if ($scope.Supplier.SupplierName == null || $scope.Supplier.SupplierName == undefined) {
            toastr.error('Supplier Name can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }
        //if ($scope.Item.ItemCode == null || $scope.Item.ProductName == undefined) {
        //    toastr.error('Item Code Must be Entry');
        //    isValid = false;
        //} 
        //else {
        //    isValid = true;
        //}
        if ($scope.Supplier.Address == null || $scope.Supplier.Address == undefined) {
            toastr.error('Supplier Address can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }

        if ($scope.Supplier.Mobile == null || $scope.Supplier.Mobile == undefined) {
            toastr.error('Supplier Mobile can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Supplier.Email == null || $scope.Supplier.Email == undefined) {
            toastr.error('Supplier Email can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Supplier.BIN == null || $scope.Supplier.BIN == undefined) {
            toastr.error('Supplier BIN can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Supplier.TIN == null || $scope.Supplier.TIN == undefined) {
            toastr.error('Supplier TIN can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Supplier.VATRegNo == null || $scope.Supplier.VATRegNo == undefined) {
            toastr.error('Supplier VAT Reg. No. can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Supplier.ContactPerson == null || $scope.Supplier.ContactPerson == undefined) {
            toastr.error('Supplier ContactPerson can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Supplier.IsActive == null || $scope.Supplier.IsActive == undefined) {
            toastr.error('Supplier IsActive can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }
        }

        if (isValid) {

            $scope.Supplier.UpdatorId = $scope.LoginUser.UserId;
            $scope.Supplier.CreatorId = $scope.LoginUser.UserId;
            var parms = JSON.stringify({ _ad_Supplier: $scope.Supplier });
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
                    $http.post('/Supplier/Save', parms).success(function (data) {
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


});