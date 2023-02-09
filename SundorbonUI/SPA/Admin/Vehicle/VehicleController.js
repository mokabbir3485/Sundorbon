app.controller("VehicleController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();

    function Clear() {
        $scope.HasOwnership = [
            { Id: 1, Ownership: "YES" },
            { Id: 2, Ownership: "NO" }
        ];

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        VehicleGetPaged($scope.currentPage);

        $scope.Vehicle = {};
        $scope.Vehicle.IsActive = true;
        $scope.ModelList = [];

        $scope.ddlModel = null;
        $scope.ddlOwnership = null;
        $scope.ddlEmployee = null;
        $scope.ddlVehicleGroup = null;
        ///Method Call=========>>>
        GetAllModel();
        GetAllEmployee();
        GetAllVehicleGroup();
        $scope.BtnName = "Save";
        // GetAllData();
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
    function GetAllEmployee() {
        $http({
            url: "/Employee/GetAllItem",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.EmployeeList = data;


        });
    }
    function GetAllVehicleGroup() {
        $http({
            url: "/VehicleGroup/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.VehicleGroupList = data;


        });
    }
    $scope.SaveVehicle = function () {
        var isValid = true;
        if ($scope.Vehicle.VehicleNo == null || $scope.Vehicle.VehicleNo == undefined || $scope.Vehicle.VehicleNo=="") {
            toastr.error('Vehicle No can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }
        //if ($scope.Vehicle.VehicleCode == null || $scope.Vehicle.ProductName == undefined) {
        //    toastr.error('Vehicle Code Must be Entry');
        //    isValid = false;
        //} 
        //else {
        //    isValid = true;
        //}
        if ($scope.Vehicle.EngineNo == null || $scope.Vehicle.EngineNo == undefined || $scope.Vehicle.EngineNo == "") {
            toastr.error('Engine No can not be null or less then ZERO');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Vehicle.ChasisNo == null || $scope.Vehicle.ChasisNo == undefined || $scope.Vehicle.ChasisNo == "") {
            toastr.error('Chasis No can not be null or less then ZERO');
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
        if ($scope.ddlEmployee == null || $scope.ddlEmployee.EmployeeId == undefined) {
            toastr.error('Employee can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlVehicleGroup == null || $scope.ddlVehicleGroup.Id == undefined) {
            toastr.error('Vehicle Group can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlOwnership == null || $scope.ddlOwnership == undefined) {
            toastr.error('Is Ownership  can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

            if ($scope.ddlOwnership.Id == 1) {
                $scope.Vehicle.IsOwnership = true;
            } else {
                $scope.Vehicle.IsOwnership = false;
            }
        }


        if (isValid) {


            $scope.Vehicle.ModelId = $scope.ddlModel.Id;
            $scope.Vehicle.VehicleGroupId = $scope.ddlVehicleGroup.Id;
            $scope.Vehicle.EmployeeId = $scope.ddlEmployee.EmployeeId;
            $scope.Vehicle.IsActive = $scope.Vehicle.IsActive;
            $scope.Vehicle.UpdatorId = $scope.LoginUser.UserId;
            $scope.Vehicle.CreatorId = $scope.LoginUser.UserId;
            var parms = JSON.stringify({ _ad_Vehicle: $scope.Vehicle });
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
                    $http.post('/Vehicle/Save', parms).success(function (data) {
                        if (data > 0) {
                            if ($scope.BtnName == "Update") {
                                toastr.success('Vehicle updated successfully.');
                            }
                            else {
                                toastr.success('Vehicle saved successfully.');
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

    $scope.UpdateVehicle = function (Vehicleobj) {

        $scope.BtnName = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});



        $scope.Vehicle = Vehicleobj;
        $scope.ddlModel = { Id: Vehicleobj.ModelId };

        $scope.ddlEmployee = { EmployeeId: Vehicleobj.EmployeeId };
        $scope.ddlVehicleGroup = { Id: Vehicleobj.VehicleGroupId };

        if (Vehicleobj.IsOwnership == true) {
            $scope.Vehicle.IsOwnership = true;
            $scope.ddlOwnership = { Id: 1 };
        } else {
            $scope.Vehicle.IsOwnership = false;
            $scope.ddlOwnership = { Id: 2 };
        }
    }

    $scope.ResetVehicle = function () {
        Clear();
    }

    function VehicleGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchVehicle != undefined && $scope.SearchVehicle != "") {
            SearchCriteria = "VehicleNo LIKE '%" + $scope.SearchVehicle + "%'";

        }


        $http({
            url: encodeURI('/Vehicle/VehiclePaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.VehicleList = data.ListData;
            $scope.total_count = data.TotalRecord;
            //  $scope.VehicleList = data.dTable.results; 

        });
    }
    //function GetAllData () {
    //    $http({
    //        method: 'GET',
    //        url: "/Vehicle/GetAllVehicle/",
    //        headers: {
    //            "Accept": "application/json;odata=verbose"
    //        }
    //    }).success(function (data, status, headers, config) {

    //        //$scope.VehicleList = data;

    //    }).error(function (data, status, headers, config) { }); 
    //}



    $scope.SearchBtn = function () {

        VehicleGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchVehicle = "";
        VehicleGetPaged(1);
    }

    $scope.getData = function (curPage) {
        //alert(curPage);
        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            VehicleGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            VehicleGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            VehicleGetPaged($scope.currentPage);
        }
    }



  

});