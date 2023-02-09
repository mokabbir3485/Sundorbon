app.controller("ItemController", function ($scope, $filter,$http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();

    function Clear() {
        $scope.HasExpiryList = [
            { Id: 1, HasExpiry: "YES" },
            { Id: 2, HasExpiry: "NO" }
        ];
     
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        ItemGetPaged($scope.currentPage);

        $scope.Item = {};
        $scope.Item.IsActive = true;
        $scope.MeasurmentList = [];
        $scope.ModelList = [];
        $scope.VatList = [];
        $scope.RoleList = [];
        $scope.ItemGroupList = [];

        $scope.ddlGroup = null;
        $scope.ddlMeasurmentUnit = null;
        $scope.ddlModel = null;
        $scope.ddlRole = null;
        $scope.ddlVat = null;
        $scope.ddlSupplimentaryDutyId = null;
        $scope.ddlHasExpiry = null;

        ///Method Call=========>>>
        MeasurmentGetAllActive();
        GetAllModel();
        GetAllItemGroup();
        GetAllRole();
        GetAllPurchaseVat();
        $scope.BtnName = "Save";
       // GetAllData();
    }


    function MeasurmentGetAllActive() {
        $http({
            url: "/MeasurementUnit/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.MeasurmentList = data;


        });
    }
    function GetAllModel() {
        $http({
            url: "/Model/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ModelList = data;


        });
    }
    function GetAllItemGroup() {
        $http({
            url: "/ItemGroup/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ItemGroupList = data;
        });
    }

    function GetAllRole() {
        $http({
            url: "/Role/GetAllRole",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.RoleList = data;


        });
    }
    function GetAllPurchaseVat() {
        $http({
            url: "/VAT/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.VatList = data;


        });
    }

    $scope.SaveItem = function () {
        var isValid = true;
        if ($scope.Item.ProductName == null || $scope.Item.ProductName == undefined) {
            toastr.error('Product Name can not be null or empty');
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
        if ($scope.Item.ROL == null || $scope.Item.ROL == undefined) {
            toastr.error('Roll can not be null or less then ZERO');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }

        if ($scope.ddlGroup == null || $scope.ddlGroup.Id == undefined) {
            toastr.error('Group Name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlModel == null || $scope.ddlModel.Id == undefined) {
            toastr.error('Model Name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlVat == null || $scope.ddlVat.Id == undefined) {
            toastr.error('Vat can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlSupplimentaryDutyId == null || $scope.ddlSupplimentaryDutyId.Id == undefined) {
            toastr.error('Supplimentary Duty can not be null or empty');
            isValid = false;       
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlMeasurmentUnit == null || $scope.ddlMeasurmentUnit.Id == undefined) {
            toastr.error('Measurment Unit can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlHasExpiry == null || $scope.ddlHasExpiry == undefined) {
            toastr.error('Has Expiry  can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

            if ($scope.ddlHasExpiry.Id == 1) {
                $scope.Item.HasExpiry = true;
            } else {
                $scope.Item.HasExpiry = false;
            }
        }


        if (isValid) {
         

            $scope.Item.ItemGroupId = $scope.ddlGroup.Id;
            $scope.Item.MeasureUnitId = $scope.ddlMeasurmentUnit.Id;
            $scope.Item.ModelId = $scope.ddlModel.Id;
            $scope.Item.ItemCode = '0';
            $scope.Item.PurchaseVatId = $scope.ddlVat.Id;
            $scope.Item.SupplimentaryDutyId = $scope.ddlSupplimentaryDutyId.Id;
            $scope.Item.UpdatorId = $scope.LoginUser.UserId;
            $scope.Item.CreatorId = $scope.LoginUser.UserId;

            var parms = JSON.stringify({ _ad_Item: $scope.Item });
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
                    $http.post('/Item/Save', parms).success(function (data) {
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
       
    $scope.UpdateItem = function (Itemobj) {

        $scope.BtnName = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});

       

        $scope.Item = Itemobj;
        $scope.ddlGroup = { Id: Itemobj.ItemGroupId};
        $scope.ddlMeasurmentUnit = { Id: Itemobj.MeasureUnitId };
        $scope.ddlModel = { Id: Itemobj.ModelId };
        $scope.ddlVat = { Id: Itemobj.PurchaseVatId };
        $scope.ddlSupplimentaryDutyId = { Id: Itemobj.SupplimentaryDutyId };

        $scope.ddlHasExpiry = { Id: Itemobj.HasExpiry };

        if (Itemobj.HasExpiry == true) {
            $scope.Item.HasExpiry = true;
            $scope.ddlHasExpiry = { Id:1};
        } else {
            $scope.Item.HasExpiry = false;
            $scope.ddlHasExpiry = { Id: 2 };
        }
    }

    $scope.ResetItem = function () {
        Clear();
    }

    function ItemGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";
       

        if ($scope.SearchItem != undefined && $scope.SearchItem != "" ) {
            SearchCriteria = "ProductName LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/Item/ItemPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ItemList = data.ListData;
            $scope.total_count = data.TotalRecord;
          //  $scope.ItemList = data.dTable.results;  
            ChangeClassForPaginationAndReport();

        });
    }
    function ChangeClassForPaginationAndReport(){
        if ($scope.total_count > $scope.PerPage) {
            $scope.PaginationAndReport = "Pagination-And-Report";
        }
        else {
            $scope.PaginationAndReport = "Only-Report";
        }
        
    }
    //function GetAllData () {
    //    $http({
    //        method: 'GET',
    //        url: "/Item/GetAllItem/",
    //        headers: {
    //            "Accept": "application/json;odata=verbose"
    //        }
    //    }).success(function (data, status, headers, config) {

    //        //$scope.ItemList = data;
         
    //    }).error(function (data, status, headers, config) { }); 
    //}
 


    $scope.SearchBtn = function () {
       
        ItemGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        ItemGetPaged(1);
    }

    
    $scope.ReloadModel = function () {
        $scope.ddlModel = null;
        $scope.ModelList = {};
        GetAllModel();
    }
    $scope.ReloadMeasurment = function () {
        $scope.ddlMeasurmentUnit = null;
        $scope.MeasurmentList = {};
        MeasurmentGetAllActive();
    }
    $scope.ReloadItemGroup = function () {
        $scope.ddlGroup = null;
        $scope.ItemGroupList = {};
        GetAllItemGroup();
    }
    $scope.ReloadRole = function () {
        GetAllRole();
    }
    $scope.ReloadPurchaseVat = function () {
        $scope.ddlSupplimentaryDutyId = null;
        $scope.ddlVat = null;
        $scope.VatList = {};
        GetAllPurchaseVat();
    }
    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            ItemGetPaged($scope.currentPage);
          //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            ItemGetPaged($scope.currentPage);
           // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            ItemGetPaged($scope.currentPage);
        }
    }

    $scope.OpenReport = function () {
        var $popup = window.open("#/ItemReport", "popup", "width=800,height=550,left=280,top=80");
        event.stopPropagation();
    }


});