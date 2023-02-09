app.controller("JobController", function ($scope, $filter, $http, $window, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    var val = 0;
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
        console.log(CounterData);
    }
    var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
    console.log(CounterData);
    Clear();

    function Clear() {
        $scope.isEdit = true;
        $scope.TormDate = "";
        $scope.FormDate = "";
        $scope.MeasurmentId = 0;

        $scope.PurchaseDetailsPaginations = false;

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        JobGetPaged($scope.currentPage);

        $scope.currentPageForPurchaseDetails = 1;
        $scope.PerPageForPurchaseDetails = 10;
        $scope.total_countForPurchaseDetails = 0;

        $scope.btnName = "Save";
        $scope.addBtn = "Add";
        $scope.addJobItemDetailsBtn = "Add";
        $scope.Job = {};
        $scope.JobDetails = {};
        $scope.JobDetailsList = [];
        $scope.JobDetailListFilter = [];
        $scope.JobItemDetails = {};
        $scope.JobItemDetailsList = [];
        $scope.JobItemDetailListFilter = [];

        $scope.PurposeList = [];
        $scope.EmployeeList = [];
        $scope.VehicleList = [];
        $scope.ItemList = [];
        // $scope.CounterList = [];
        //$scope.JobStatusList = [];
        //$scope.JobDetailList = [];
        ///Method Call=====>>>
        Purpose();
        Vehicle();
        GetAllEmployee();
        GetAllItem();

    }
    function GetAllItem() {
        $http({
            url: "/Item/GetAllItem",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ItemList = data;

        });
    }
    function Purpose() {
        $http({
            url: "/Item/RequestionPurpose",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.PurposeList = data;
        });
    }
    function Vehicle() {
        $http({
            url: "/Vehicle/GetAllActive",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.VehicleList = data;
        });
    }
    function GetAllEmployee() {
        $http({
            url: "/Employee/GetAllEmployee",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.EmployeeList = data;
        });
    }

    $scope.ReloadItem = function () {
        $scope.ItemList = [];
        $scope.ddlItem = null;
        GetAllItem();
    }
    $scope.ReloadVehicle = function () {
        $scope.VehicleList = [];
        $scope.ddlVehicle = null;
        Vehicle();
    }
    $scope.ReloadPurpose = function () {
        $scope.PurposeList = [];
        $scope.ddlPurpose = null;
        Purpose();
    }
    $scope.ReloadEmployee = function () {
        $scope.EmployeeList = [];
        $scope.ddlEmployee = null;
        GetAllEmployee();
    }
   
    $scope.Remove = function (aReqDetail) {
        var ind = $scope.JobDetailsList.indexOf(aReqDetail);
        $scope.JobDetailsList.splice(ind, 1);
        $scope.JobDetailListFilter.splice(ind, 1);

        $scope.JobDetailsList = $scope.JobDetailListFilter;

        //$scope.TotalLength = $scope.JobDetailList.length;

        $scope.TotalLength = $scope.JobDetailsList.length;
        $scope.samplePerPage = 2;
        $scope.samplecurrentPage = 1;
        const lastIndex = $scope.samplePerPage * $scope.TempCurrentPage;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.JobDetailsList.slice(firstIndex, lastIndex);
        $scope.JobDetailsList = item;


    }
    $scope.RemoveItem = function (aReqDetail) {
        var ind = $scope.JobItemDetailsList.indexOf(aReqDetail);
        $scope.JobItemDetailsList.splice(ind, 1);
        $scope.JobItemDetailListFilter.splice(ind, 1);

        $scope.JobItemDetailsList = $scope.JobItemDetailListFilter;

        //$scope.TotalLength = $scope.JobDetailList.length;

        $scope.ItemTotalLength = $scope.JobItemDetailsList.length;
        $scope.ItemsamplePerPage = 2;
        $scope.ItemsamplecurrentPage = 1;
        const lastIndex = $scope.ItemsamplePerPage * $scope.TempCurrentPage;
        const firstIndex = lastIndex - $scope.ItemsamplePerPage;
        var item = $scope.JobItemDetailsList.slice(firstIndex, lastIndex);
        $scope.JobItemDetailsList = item;


    }


    $scope.JobSave = function () {
        var isValid = true;
        
        if ($scope.Job.JobDate == null || $scope.Job.JobDate == undefined) {
            toastr.error("Job date can not be null");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlVehicle == null || $scope.ddlVehicle == undefined) {
            toastr.error("Vehicle can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlEmployee == null || $scope.ddlEmployee == undefined) {
            toastr.error("Employee can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ddlPurpose == null || $scope.ddlPurpose == undefined) {
            toastr.error("Purpose can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Job.DriverInformation == null || $scope.Job.DriverInformation == undefined) {
            toastr.error("Driver Information can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.Job.Remarks == null || $scope.Job.Remarks == undefined) {
            toastr.error("Remarks can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.JobDetailListFilter == null || $scope.JobDetailListFilter == undefined || $scope.JobDetailListFilter.length==0) {
            toastr.error("Job details can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.JobItemDetailListFilter == null || $scope.JobItemDetailListFilter == undefined || $scope.JobItemDetailListFilter.length==0) {
            toastr.error("Job Item Detail can not be null or empty");
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if (isValid) {

            $scope.Job.CreatorId = $scope.LoginUser.UserId;
            $scope.Job.UpdatorId = $scope.LoginUser.UserId;
            $scope.Job.CounterId = CounterData.Id;
            $scope.Job.PurposeId = $scope.ddlPurpose.Id;
            $scope.Job.JobCreatedByEmployeeId = $scope.ddlEmployee.EmployeeId;
            $scope.Job.ApprovalStatusId = 2;
            $scope.Job.VehicleId = $scope.ddlVehicle.Id;

            var titleText = "Do you want to save?";
            if ($scope.btnName == "Update") {
                $scope.Job.transactionType = "Update";
                titleText = "Do you want to update?";
                $scope.Job.ApprovalStatusId = $scope.ddlApprovalStatus.Id;
            } else {
                $scope.Job.transactionType = "INSERT";
                $scope.Job.Number = CounterData.ShortCode;
                $scope.Job.ApprovalStatusId = 2;
            }
            var parms = JSON.stringify({ _Job: $scope.Job, _JobDetails: $scope.JobDetailListFilter, JobItem: $scope.JobItemDetailListFilter });



            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/Job/Save', parms).success(function (data) {
                        if ($scope.btnName == "Save") {
                            toastr.success('Job saved successfully.');
                        }
                        else {
                            toastr.success('Job Updated successfully.');
                        }
                        Clear();
                        JobDetailGetPaged();
                        JobItemDetailGetPaged();
                    }).error(function (data) {
                        toastr.error('Server Errors!');

                    });
                }
                else if (result.dismiss == "cancel") {
                    Swal.DismissReason.cancel;
                }
            })

        }


    }

    $scope.DetailRowEdit = function (aItem) {
        $scope.addBtn = "Update";
        $scope.JobDetails = aItem;
    }
    $scope.ItemDetailRowEdit = function (aItem) {
        $scope.addJobItemDetailsBtn = "Update";
        $scope.ddlItem = { Id: aItem.ItemId };
        $scope.JobItemDetails = aItem;
    }

    $scope.addJobDetails = function () {
        var IsValid = true;
        if ($scope.JobDetails.WorkDetails == null && $scope.JobDetails.WorkDetails == undefined || $scope.JobDetails.WorkDetails=="") {
            toastr.error("Work details can not be null or empty");
            IsValid = false
        }
        else {
            if (IsValid) {
                IsValid = true;
            }
        }
        if (IsValid) {
            if ($scope.JobDetailsList.length != $scope.JobDetailListFilter.length) {
                $scope.JobDetailsList = [];
                $scope.JobDetailsList = $scope.JobDetailListFilter;
            }
            if ($scope.JobDetails.Id == 0 || $scope.JobDetails.Id == undefined) {
                $scope.JobDetailsList.push($scope.JobDetails);
            }
            else {
                angular.forEach($scope.JobDetailsList, function (aData) {
                    aData.WorkDetails = $scope.JobDetails.WorkDetails;
                });
            }
           
            $scope.addBtn = "Add";
            $scope.JobDetailListFilter = $scope.JobDetailsList;
            JobDetailGetPaged();
            $scope.JobDetails = {};
        }

    }
    $scope.addJobItemDetails = function () {
        var IsValid = true;
        if ($scope.ddlItem == null && $scope.ddlItem == undefined) {
            toastr.error("Item can not be null or empty");
            IsValid = false
        }
        else {
            if (IsValid) {
                IsValid = true;
            }
        }
        if ($scope.JobItemDetails.ItemRequiredFromStoreQty == null && $scope.JobItemDetails.ItemRequiredFromStoreQty == undefined || $scope.JobItemDetails.ItemRequiredFromStoreQty == "") {
            toastr.error("Item Required From Store Qty can not be null or empty");
            IsValid = false
        }
        else {
            if (IsValid) {
                IsValid = true;
            }
        }
        if ($scope.JobItemDetails.ItemReusableQty == null && $scope.JobItemDetails.ItemReusableQty == undefined ) {
            toastr.error("Item Reusable Qty can not be null or empty");
            IsValid = false
        }
        else {
            if (IsValid) {
                IsValid = true;
            }
        }
        if ($scope.JobItemDetails.ItemDamagedQty == null && $scope.JobItemDetails.ItemDamagedQty == undefined ) {
            toastr.error("Item Damaged Qty can not be null or empty");
            IsValid = false
        }
        else {
            if (IsValid) {
                IsValid = true;
            }
        }
        if ($scope.JobItemDetails.Remarks == null && $scope.JobItemDetails.Remarks == undefined || $scope.JobItemDetails.Remarks == "") {
            toastr.error("Remarks can not be null or empty");
            IsValid = false
        }
        else {
            if (IsValid) {
                IsValid = true;
            }
        }
        if (IsValid) {
            if ($scope.JobItemDetails.length != $scope.JobItemDetailListFilter.length) {
                $scope.JobItemDetailsList = [];
                $scope.JobItemDetailsList = $scope.JobItemDetailListFilter;
            }
            if ($scope.JobItemDetails.Id == undefined || $scope.JobItemDetails.Id == 0) {
                $scope.JobItemDetails.ItemId = $scope.ddlItem.Id;
                $scope.JobItemDetails.Combination = $scope.ddlItem.Combination;
                $scope.JobItemDetailsList.push($scope.JobItemDetails);
            }
            else {
                angular.forEach($scope.JobItemDetailsList, function (aData) {
                    aData.ItemId = $scope.ddlItem.Id;
                    aData.ItemRequiredFromStoreQty = $scope.JobItemDetails.ItemRequiredFromStoreQty;
                    aData.ItemReusableQty = $scope.JobItemDetails.ItemReusableQty;
                    aData.ItemDamagedQty = $scope.JobItemDetails.ItemDamagedQty;
                    aData.Remarks = $scope.JobItemDetails.Remarks;
                });
            }
          

            $scope.JobItemDetailListFilter = $scope.JobItemDetailsList;
            $scope.addJobItemDetailsBtn = "Add";
            JobItemDetailGetPaged();
            $scope.JobItemDetails = {};
            $scope.ddlItem = {};
        }

    }

    /// Item Detail Pagination==============>>>>

    function JobDetailGetPaged() {

        $scope.TotalLength = $scope.JobDetailListFilter.length;
        $scope.samplePerPage = 2;
        $scope.samplecurrentPage = 1;
    }
    function JobItemDetailGetPaged() {

        $scope.ItemTotalLength = $scope.JobItemDetailListFilter.length;
        $scope.ItemsamplePerPage = 2;
        $scope.ItemsamplecurrentPage = 1;
    }



    $scope.GetSampleDate = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.JobDetailsList = $scope.JobDetailListFilter;

        const lastIndex = $scope.samplePerPage * Cur;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.JobDetailsList.slice(firstIndex, lastIndex);
        $scope.JobDetailsList = item;

    }
    $scope.GetSampleItem = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.JobItemDetailsList = $scope.JobItemDetailListFilter;

        const lastIndex = $scope.ItemsamplePerPage * Cur;
        const firstIndex = lastIndex - $scope.ItemsamplePerPage;
        var item = $scope.JobItemDetailsList.slice(firstIndex, lastIndex);
        $scope.JobItemDetailsList = item;

    }

    $scope.UpdateJob = function (aPur) {
        $scope.isEdit = false;
        $scope.ddlApprovalStatus = { Id: aPur.ApprovalStatusId };
        $scope.Job.JobDate = aPur.JobDate;
        $scope.Job.Number = aPur.Number;
        //  $scope.CounterId = { Id: aPur.CounterId, ShortCode: aPur.ShortCode };

        $scope.Job.CounterId = aPur.CounterId;
        $scope.ddlPurpose = { Id: aPur.PurposeId };
        $scope.ddlEmployee = { EmployeeId: aPur.JobCreatedByEmployeeId };
        $scope.ddlVehicle = { Id: aPur.VehicleId };
        $scope.Job.DriverInformation = aPur.DriverInformation;
        $scope.Job.Remarks = aPur.Remarks;

        $scope.btnName = "Update";
        $scope.JobDetailsList = [];
        /*$scope.JobId = aPur.Number;*/

        $http({
            url: "/Job/GetAllJobDetailsByJobNumber?Number=" + aPur.Number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            angular.forEach(data, function (aData) {
                $scope.JobDetailsList.push(aData);
                $scope.JobDetailListFilter = $scope.JobDetailsList;

                
            })
            $scope.TotalLength = $scope.JobDetailsList.length;
            $scope.samplePerPage = 2;
            $scope.samplecurrentPage = 1;

        });
        $http({
            url: "/Job/GetAllJobItemDetailsByJobNumber?Number=" + aPur.Number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            angular.forEach(data, function (aData) {
                $scope.JobItemDetailsList.push(aData);
                $scope.JobItemDetailListFilter = $scope.JobItemDetailsList;
            })
            $scope.ItemTotalLength = $scope.JobItemDetailsList.length;
            $scope.ItemsamplePerPage = 2;
            $scope.ItemsamplecurrentPage = 1;

        });

    }



    $scope.ResetItem = function () {
        Clear();
        JobDetailGetPaged();
        $scope.JobDetailListFilter = [];
        $scope.JobDetailList = [];

    }

    function JobGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "(JobDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (Number LIKE '%" + $scope.SearchItem + "%')";

        }
        else if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
            SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%'";

        }
        else if ($scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "JobDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";

        }


        $http({
            url: encodeURI('/Job/JobGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {



            $scope.JobList = data.ListData;
            $scope.total_count = data.TotalRecord;

            angular.forEach(data.ListData, function (aData) {
                var res1 = aData.JobDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.JobDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.JobDate = date1;
                }
            })


            if (data.TotalRecord > 0) {
                var num1 = 0;
                var num2 = 0;
                var NumberString = data.ListData[0].Number;
                var num1 = Number(NumberString.substr(7, 17));
                num2 = num1 + 1;
                $scope.Job.Number = NumberString.substr(0, 7) + (num2).toString();
            }
            else {
                $scope.Job.Number = CounterData.ShortCode + "-" + "PR-1000000001";

            }
        });
    }


    $scope.SearchBtn = function () {
        JobGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        $scope.TormDate = "";
        $scope.TormDate = "";
        $("#FormDate").val("");
        $("#ToDate").val("");
        JobGetPaged(1);
    }

    $scope.getData = function (curPage) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            JobGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            JobGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            JobGetPaged($scope.currentPage);
        }
    }


    $scope.SetItemRequiredFromStoreQty = function () {
        val = $scope.JobItemDetails.ItemRequiredFromStoreQty;
        $scope.MaxValue = val;
    }
    $scope.SetItemReusableQty = function () {
       if ($scope.JobItemDetails.ItemReusableQty > 0 && $scope.JobItemDetails.ItemReusableQty <= val) {
            $scope.JobItemDetails.ItemDamagedQty = val - $scope.JobItemDetails.ItemReusableQty;
        }
       else if ($scope.JobItemDetails.ItemReusableQty == "" || $scope.JobItemDetails.ItemReusableQty == null) {
            $scope.JobItemDetails.ItemReusableQty = "";
            $scope.JobItemDetails.ItemDamagedQty = "";
        }
        else {
            $scope.JobItemDetails.ItemReusableQty = "";
            toastr.error("Item Reusable Qty can not greater then Item Required From Store Qty or less then 0!!!!");
        }
       
    }
    $scope.SetItemDamagedQty = function () {
        if ($scope.JobItemDetails.ItemDamagedQty > 0 && $scope.JobItemDetails.ItemDamagedQty <= val) {
            $scope.JobItemDetails.ItemReusableQty = val - $scope.JobItemDetails.ItemDamagedQty;
        }
        else if ($scope.JobItemDetails.ItemDamagedQty == "" || $scope.JobItemDetails.ItemDamagedQty == null) {
            $scope.JobItemDetails.ItemReusableQty = "";
            $scope.JobItemDetails.ItemDamagedQty = "";
        }
        else {
            $scope.JobItemDetails.ItemDamagedQty = "";
            toastr.error("Item Damaged Qty can not greater then Item Required From Store Qty or less then 0!!!!");
        }
    }
});