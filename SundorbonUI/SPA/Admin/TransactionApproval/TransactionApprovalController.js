app.controller("TransactionApprovalController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    Clear();
    
    function Clear() {
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        TransactionApprovalGetPaged($scope.currentPage);

        $scope.TransactionApproval = {};
        $scope.DepartmentList = [];
        $scope.ApprovalStatusList = [];
        $scope.ApprovalGivenOnList = [];
        $scope.ddlDepartment = null;
        $scope.ddlApprovalStatus = null;
        $scope.ddlApprovalGivenOn = null;

        ///Method Call=========>>>
        //DepartmentGetAllActive();
        GetAllApprovalStatus();
        GetAllApprovalGivenOn();
        $scope.BtnName = "Save";
        // GetAllData();
    }


    //function DepartmentGetAllActive() {
    //    $http({
    //        url: "/Department/GetAll",
    //        method: 'GET',
    //        headers: { 'Content-Type': 'application/json' }
    //    }).success(function (data) {

    //        $scope.DepartmentList = data;


    //    });
    //}
    function GetAllApprovalStatus() {
        $http({
            url: "/ApprovalStatus/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ApprovalStatusList = data;


        });
    }
    function GetAllApprovalGivenOn() {
        $http({
            url: "/ApprovalGivenOn/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ApprovalGivenOnList = data;
        });
    }

    $scope.ReloadApprovalGivenOn = function () {
        $scope.ddlApprovalGivenOn = null;
        $scope.ApprovalGivenOnList = {};
        GetAllApprovalGivenOn();
    }
    $scope.ReloadApprovalStatus = function () {
        $scope.ddlApprovalStatus = null;
        $scope.ApprovalStatusList = {};
        GetAllApprovalStatus();
    }
    $scope.ReloadDepartment = function () {
        $scope.ddlDepartment = null;
        $scope.ApprovalStatusList = {};
        DepartmentGetAllActive();
    }
    $scope.SaveTransactionApproval = function () {
        var isValid = true;
        if ($scope.TransactionApproval.ApprovalDate == null || $scope.TransactionApproval.ApprovalDate == undefined || $scope.TransactionApproval.ApprovalDate == "") {
            toastr.error('Approval Date can not be null or empty');
            isValid = false;
        } else {
            if (isValid) {
                isValid = true;
            }

        }
        //if ($scope.TransactionApproval.TransactionApprovalCode == null || $scope.TransactionApproval.ProductName == undefined) {
        //    toastr.error('TransactionApproval Code Must be Entry');
        //    isValid = false;
        //} 
        //else {
        //    isValid = true;
        //}
        if ($scope.ddlReferenceTransactionNumber == null || $scope.ddlReferenceTransactionNumber == undefined ) {
            toastr.error('Reference Transaction Number can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.TransactionApproval.Remarks == null || $scope.TransactionApproval.Remarks == undefined || $scope.TransactionApproval.Remarks == "") {
            toastr.error('Remarks can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlApprovalStatus == null || $scope.ddlApprovalStatus.Id == undefined) {
            toastr.error('Approval Status Name can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlApprovalGivenOn == null || $scope.ddlApprovalGivenOn.Id == undefined) {
            toastr.error('Approval Given On can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        //if ($scope.ddlDepartment == null || $scope.ddlDepartment.Id == undefined) {
        //    toastr.error('Department can not be null or empty');
        //    isValid = false;
        //}
        //else {
        //    if (isValid) {
        //        isValid = true;
        //    }
        //}


        if (isValid) {
            var User = JSON.parse(UserData);

            $scope.TransactionApproval.ApprovalGivenOnId = $scope.ddlApprovalGivenOn.Id;
            $scope.TransactionApproval.DepartmentId = User.DepartmentId;
            $scope.TransactionApproval.ApprovalStatusId = $scope.ddlApprovalStatus.Id;
            $scope.TransactionApproval.UpdatorId = $scope.LoginUser.UserId;
            $scope.TransactionApproval.CreatorId = $scope.LoginUser.UserId;
            $scope.TransactionApproval.ReferenceTransactionNumber = $scope.ddlReferenceTransactionNumber.Number;
            var parms = JSON.stringify({ _ad_TransactionApproval: $scope.TransactionApproval });
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
                    $http.post('/TransactionApproval/Save', parms).success(function (data) {
                        if (data > 0) {
                            if ($scope.BtnName == "Update") {
                                toastr.success('TransactionApproval updated successfully.');
                            }
                            else {
                                toastr.success('TransactionApproval saved successfully.');
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

    $scope.SearchApproval = function () {
        $scope.ReferenceTransactionNumberList = [];
        var isValid = true;
        var searchTerm="";
        if ($scope.ddlApprovalGivenOn == null || $scope.ddlApprovalGivenOn.Id == undefined) {
            toastr.error('Approval Given On can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                if ($scope.ddlApprovalGivenOn.ApprovalGivenOn=="Issue") {
                    $scope.ddlApprovalGivenOn.ApprovalGivenOn = "IS";
                }
                isValid = true;
            }
        }
        if ($scope.FromDate == null || $scope.ToDate == null || $scope.FromDate == "" || $scope.ToDate == "" || $scope.FromDate == undefined || $scope.ToDate == undefined ) {
            //searchTerm = 'between ' + "'" + $scope.FromDate + "'" + ' and ' + "'" + $scope.ToDate + "'" + '';
            //toastr.error('From Date or To Date can not be null or empty');
            //isValid = false;
            $scope.FromDate = "Nodate";
            $scope.ToDate = "Nodate";
        } else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {
            $http({
                url: encodeURI('/TransactionApproval/GetTableName?Status=' + $scope.ddlApprovalGivenOn.ApprovalGivenOn + '&FromDate=' + $scope.FromDate + '&ToDate=' + $scope.ToDate),
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.ReferenceTransactionNumberList = data;
                $scope.FromDate = "";
                $scope.ToDate = "";
            });
        }
    }


    $scope.UpdateTransactionApproval = function (aTransactionApproval) {

        $scope.BtnName = "Update";
        //swal("Are you sure?", {
        //    dangerMode: true,
        //    buttons: true,
        //});



        $scope.TransactionApproval.Id = aTransactionApproval.Id;
        $scope.ddlApprovalGivenOn = { Id: aTransactionApproval.ApprovalGivenOnId };
        $scope.ddlDepartment = { Id: aTransactionApproval.DepartmentId };
        $scope.ddlApprovalStatus = { Id: aTransactionApproval.ApprovalStatusId };
        var date = aTransactionApproval.ApprovalDate;
        //$scope.TransactionApproval.ApprovalDate = date;
        $scope.TransactionApproval.ApprovalDate = new Date((date).toString());
        $scope.TransactionApproval.ApprovalGivenOn = aTransactionApproval.ApprovalGivenOn;
        $scope.TransactionApproval.Remarks = aTransactionApproval.Remarks;
        $scope.TransactionApproval.ReferenceTransactionNumber = aTransactionApproval.ReferenceTransactionNumber;
        //TransactionApprovalobj.ApprovalDate = ($filter('date')(TransactionApprovalobj.ApprovalDate, 'MMM dd, yyyy')).toString();;
    }


    $scope.ResetTransactionApproval = function () {
        Clear();
    }

    function TransactionApprovalGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchTransactionApproval != undefined && $scope.SearchTransactionApproval != "") {
            SearchCriteria = "ReferenceTransactionNumber LIKE '%" + $scope.SearchTransactionApproval + "%'";

        }


        $http({
            url: encodeURI('/TransactionApproval/TransactionApprovalPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.TransactionApprovalList = data.ListData;
            $scope.total_count = data.TotalRecord;
            angular.forEach($scope.TransactionApprovalList, function (aData) {
                if (aData.ApprovalDate != null) {
                    var res1 = aData.ApprovalDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.ApprovalDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'MMM dd, yyyy')).toString();
                        aData.ApprovalDate = date1;
                    }
                }

            })
            //  $scope.TransactionApprovalList = data.dTable.results;  


        });
    }

    //function GetAllData () {
    //    $http({
    //        method: 'GET',
    //        url: "/TransactionApproval/GetAllTransactionApproval/",
    //        headers: {
    //            "Accept": "application/json;odata=verbose"
    //        }
    //    }).success(function (data, status, headers, config) {

    //        //$scope.TransactionApprovalList = data;

    //    }).error(function (data, status, headers, config) { }); 
    //}



    $scope.SearchBtn = function () {

        TransactionApprovalGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchTransactionApproval = "";
        TransactionApprovalGetPaged(1);
    }

    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            TransactionApprovalGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            TransactionApprovalGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            TransactionApprovalGetPaged($scope.currentPage);
        }
    }





});