app.controller("PurchaseRequisitionController", function ($scope, $filter, $http, $window, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
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
        $scope.PerPage = 5;
        $scope.total_count = 0;
        RequestionGetPaged($scope.currentPage);
      
        $scope.currentPageForPurchaseDetails = 1;
        $scope.PerPageForPurchaseDetails = 5;
        $scope.total_countForPurchaseDetails = 0;

        $scope.btnName = "Save";
        $scope.addBtn = "Add Item";
        $scope.PurchaseRequestion = {};
        $scope.PurchaseRequestionDetail = {};
        $scope.ItemList = [];
        $scope.ModelList = [];
        $scope.MeasurmentList = [];
        $scope.PurchaseRequestionDetailList = [];
        $scope.PurchaseRequestionDetailListFilter = [];
        $scope.RequestionPurposeList = [];
        $scope.EmployeeList = [];
        // $scope.CounterList = [];
        $scope.requestionStatusList = [];
        $scope.RequestionDetailList = [];
        ///Method Call=====>>>
        GetAllItem();
        GetAllModel();
        MeasurmentGetAllActive();

        RequestionPurpose();
        GetAllEmployee();
        RequestionStatus();
        
    }

 
    function RequestionPurpose() {
        $http({
            url: "/Item/RequestionPurpose",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.RequestionPurposeList = data;
        });
    }

    function RequestionStatus() {
        $http({
            url: "/ApprovalStatus/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.requestionStatusList = data;
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

    function GetAllItem() {
        $http({
            url: "/Item/GetAllItem",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ItemList = data;
            
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

    function MeasurmentGetAllActive() {
        $http({
            url: "/MeasurementUnit/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.MeasurmentList = data;
        });
    }

    $scope.ReloadMeasurment = function () {
        $scope.MeasurmentList = [];
        MeasurmentGetAllActive();
    }
    $scope.ReloadItem = function () {
        $scope.ItemList = [];
        $scope.ddlItem = null;
        GetAllItem();
    }
    $scope.ReloadModel = function () {
        $scope.ModelList = [];
        GetAllModel();
    }
    $scope.ReloadRequestionPurpose = function () {
        $scope.RequestionPurposeList = [];
        $scope.ddlPurpose = null;
        RequestionPurpose();
    }
    $scope.ReloadEmployee = function () {
        $scope.EmployeeList = [];
        $scope.ddlEmployee = null;
        GetAllEmployee();
    }
    $scope.ReloadRequestionStatus = function () {
        $scope.requestionStatusList = [];
        $scope.ddlApprovalStatus = null;
        RequestionStatus();
    }
    $scope.Remove = function (aReqDetail) {
        var ind = $scope.PurchaseRequestionDetailList.indexOf(aReqDetail);
        $scope.PurchaseRequestionDetailList.splice(ind, 1);
        $scope.PurchaseRequestionDetailListFilter.splice(ind, 1);

        $scope.PurchaseRequestionDetailList = $scope.PurchaseRequestionDetailListFilter;

        //$scope.TotalLength = $scope.PurchaseRequestionDetailList.length;

        $scope.TotalLength = $scope.PurchaseRequestionDetailList.length;
        $scope.samplePerPage = 5;
        $scope.samplecurrentPage = 1;
        const lastIndex = $scope.samplePerPage * $scope.TempCurrentPage;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.PurchaseRequestionDetailList.slice(firstIndex, lastIndex);
        $scope.PurchaseRequestionDetailList = item;

        
    }

    $scope.PurchaseRequisitionSave = function () {
        var isValid = true;
        var isValid1 = true;
        var isValid2 = true;
        var isValid3 = true;
        var isValid4 = true;
        var isValid5 = true;

        if ($scope.PurchaseRequestion.RequisitionDate == null || $scope.PurchaseRequestion.RequisitionDate == undefined) {
            toastr.error('Requisition Date can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.PurchaseRequestion.Number == null || $scope.PurchaseRequestion.Number == undefined || $scope.PurchaseRequestion.Number == "") {
            toastr.error('Purchase Requestion Number Date can not be null or empty');
            isValid1 = false;
        }
        else {

            isValid1 = true;

        }
        if ($scope.ddlPurpose == null || $scope.ddlPurpose == undefined) {
            toastr.error('Purpose can not be null or empty');
            isValid2 = false;
        }
        else {
            isValid2 = true;

        }
        if ($scope.ddlEmployee == null || $scope.ddlEmployee == undefined) {
            toastr.error('Purpose can not be null or empty');
            isValid3 = false;
        }
        else {

            isValid3 = true;

        }
    
        if ($scope.PurchaseRequestionDetailList.length == 0) {
            toastr.error('Item detail Info must entry');
            isValid5 = false;
        } else {
            isValid5 = true;
        }

        if (isValid && isValid1 && isValid2 && isValid3 && isValid5) {

            $scope.PurchaseRequestion.CreatorId = $scope.LoginUser.UserId;
            $scope.PurchaseRequestion.UpdatorId = $scope.LoginUser.UserId;
            $scope.PurchaseRequestion.CounterId = CounterData.Id;
            $scope.PurchaseRequestion.PurposeId = $scope.ddlPurpose.Id;
            $scope.PurchaseRequestion.RequestedByEmployeeId = $scope.ddlEmployee.EmployeeId;


            $scope.PurchaseRequestion.DetailNumber = $scope.PurchaseRequestion.Number;

            //var RequisitionDate = $("#RequisitionDate").val();
            //var RequisitionDate1 = RequisitionDate.split("/");
            //var RequisitionDate2 = new Date(+RequisitionDate1[2], RequisitionDate1[1] - 1, +RequisitionDate1[0]);
            //$scope.PurchaseRequestion.RequisitionDate = RequisitionDate2;

            var titleText = "Do you want to save?";
            if ($scope.btnName == "Update") {
                $scope.PurchaseRequestion.TransactiontionType = "Update";
                titleText = "Do you want to update?";
                $scope.PurchaseRequestion.ApprovalStatusId = $scope.ddlApprovalStatus.Id;
            } else {
                $scope.PurchaseRequestion.TransactiontionType = "INSERT";
                $scope.PurchaseRequestion.Number = CounterData.ShortCode;
                $scope.PurchaseRequestion.ApprovalStatusId = 12;
            }
            var parms = JSON.stringify({ _PurchaseRequisition: $scope.PurchaseRequestion, _PurchaseRequisitionDetails: $scope.PurchaseRequestionDetailListFilter });



            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/PurchaseRequisition/Save', parms).success(function (data) {
                        if ($scope.btnName == "Save") {
                            toastr.success('Purchase Requisition saved successfully.');
                        }
                        else {
                            toastr.success('Purchase Requisition successfully.');
                        }
                        Clear();
                        $scope.PurchaseRequestionDetailList = [];
                        $scope.PurchaseRequestionDetailListFilter = [];
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

    $scope.RowEdit = function (aItem) {
        $scope.addBtn = "Item Update";
        $scope.ddlItem = { Id: aItem.ItemId, Combination: aItem.Combination };
        $scope.PurchaseRequestionDetail = aItem;
        $scope.PurchaseRequestionDetailId = aItem.Id;
       // $scope.PurchaseRequestionId = aItem.Id;
        $scope.DetailItemId = aItem.ItemId;
    }

    $scope.addPurchaseRequestionDetail = function () {

     

        let isValid1 = true;
        let isValid2 = true;
        let isValid3 = true;

        if ($scope.ddlItem == null || $scope.ddlItem == undefined) {
            toastr.error('Item can not be null or empty');
            isValid1 = false;
        }
        else {
            $scope.MeasurmentId = $scope.ddlItem.MeasureUnitId;
            isValid1 = true;
        }
     

        if ($scope.PurchaseRequestionDetail.RequestedQty == null || $scope.PurchaseRequestionDetail.RequestedQty == undefined || $scope.PurchaseRequestionDetail.RequestedQty == "") {
            toastr.error('Purchase Requestion Detail can not be null or empty');
            isValid3 = false;
        }
        else {
            if ($scope.MeasurmentId == 41) {
                
                var y = Number.isInteger(Number($scope.PurchaseRequestionDetail.RequestedQty));
                if (!y) {
                    toastr.error('Requested Qty can not be double for pcs');
                    isValid3 = false;
                }
                else {
                    isValid3 = true;
                }
            }
            else {
                isValid3 = true;
            }


        }

        if (isValid1 && isValid3) {

            if ($scope.PurchaseRequestionDetailList.length != $scope.PurchaseRequestionDetailListFilter.length) {
                $scope.PurchaseRequestionDetailList = [];
                $scope.PurchaseRequestionDetailList = $scope.PurchaseRequestionDetailListFilter;
            }
            if ($scope.PurchaseRequestionDetailId == 0 || $scope.PurchaseRequestionDetailId == undefined) {

                $scope.PurchaseRequestionDetail.ItemId = $scope.ddlItem.Id;
                $scope.PurchaseRequestionDetail.Combination = $scope.ddlItem.Combination;
                $scope.PurchaseRequestionDetail.RequestedQty;
                $scope.PurchaseRequestionDetail.RequestQty = $scope.PurchaseRequestionDetail.RequestedQty;
                $scope.PurchaseRequestionDetail.DetailRemarks = $scope.PurchaseRequestionDetail.Remarks;
                $scope.PurchaseRequestionDetailList.push($scope.PurchaseRequestionDetail);
                $scope.PurchaseRequestionDetailListFilter = $scope.PurchaseRequestionDetailList;
                PurchaseRequestionDetailGetPaged();
                $scope.PurchaseRequestionDetail = {};
                $scope.ddlPurchaseRequisitionNumber = null;
                $scope.ddlItem = null;
                $scope.ddlModel = null;
            }
            else {

                angular.forEach($scope.PurchaseRequestionDetailList, function (aData) {
                    if (aData.ItemId == $scope.DetailItemId && $scope.PurchaseRequestionDetailId == aData.Id) {
                        aData.Combination = $scope.ddlItem.Combination;
                        aData.ItemId = $scope.ddlItem.Id;
                        aData.RequestedQty = $scope.PurchaseRequestionDetail.RequestedQty;
                        aData.Remarks = $scope.PurchaseRequestionDetail.Remarks;
                        $scope.PurchaseRequestionDetail.RequestQty = $scope.PurchaseRequestionDetail.RequestedQty;
                        $scope.PurchaseRequestionDetail.DetailRemarks = $scope.PurchaseRequestionDetail.Remarks;

                        PurchaseRequestionDetailGetPaged();
                        $scope.PurchaseRequestionDetail = {};
                        $scope.ddlPurchaseRequisitionNumber = null;
                        $scope.PurchaseRequestionDetail = {};
                        $scope.ddlPurchaseRequisitionNumber = null;
                        $scope.ddlItem = null;
                        $scope.ddlModel = null;
                        $scope.addBtn = "Add";
                    }
                })
                $scope.PurchaseRequestionDetailId = 0;
                //$scope.DetailItemId = 0;
            }

          

        }

    }

    /// Item Detail Pagination==============>>>>

    function PurchaseRequestionDetailGetPaged() {
      
        $scope.TotalLength = $scope.PurchaseRequestionDetailList.length;
        $scope.samplePerPage = 5;
        $scope.samplecurrentPage = 1;
    }

    $scope.GetSampleDate = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.PurchaseRequestionDetailList = $scope.PurchaseRequestionDetailListFilter;

        const lastIndex = $scope.samplePerPage * Cur;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.PurchaseRequestionDetailList.slice(firstIndex, lastIndex);
        $scope.PurchaseRequestionDetailList = item;

    }

  
    $scope.UpdatePurchaserRequestion = function (aPur) {
        $scope.isEdit = false;
        $scope.ddlApprovalStatus = { Id: aPur.ApprovalStatusId };
        $scope.PurchaseRequestion.RequisitionDate = aPur.RequisitionDate;
        $scope.PurchaseRequestion.Number = aPur.Number;
        //  $scope.CounterId = { Id: aPur.CounterId, ShortCode: aPur.ShortCode };

        $scope.PurchaseRequestion.CounterId = aPur.CounterId;
        $scope.ddlPurpose = { Id: aPur.PurposeId };
        $scope.ddlEmployee = { EmployeeId: aPur.RequestedByEmployeeId };
        $scope.btnName = "Update";
        $scope.PurchaseRequestionDetailList = [];
        $scope.PurchaseRequestionId = aPur.Number;
      
        $http({
            url: "/PurchaseRequisition/GetByPurchaseRequisitionNumber?Number=" + aPur.Number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            angular.forEach(data, function (aData) {
                aData.RequestQty = aData.RequestedQty;
                aData.DetailRemarks = aData.Remarks;
                $scope.PurchaseRequestionDetailList.push(aData);
                $scope.PurchaseRequestionDetailListFilter = $scope.PurchaseRequestionDetailList;

                $scope.TotalLength = $scope.PurchaseRequestionDetailList.length;
                $scope.samplePerPage = 5;
                $scope.samplecurrentPage = 1;
           })


        });


    }



    $scope.ResetItem = function () {
        Clear();
        PurchaseRequestionDetailGetPaged();
        $scope.PurchaseRequestionDetailListFilter = [];
        $scope.PurchaseRequestionDetailList = [];

    }

    function RequestionGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        //if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" &&  $scope.TormDate != "" ) {
        //    SearchCriteria = "(RequisitionDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (Number LIKE '%" + $scope.SearchItem + "%')";

        //}
        if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
            SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%'";

        }
        else if ($scope.FormDate != ""  && $scope.TormDate != "" ) {
            SearchCriteria = "RequisitionDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";

        }
        else if ($scope.SearchPurpose !== undefined && $scope.SearchPurpose != null && $scope.SearchPurpose != "") {
            SearchCriteria = "P.Purpose LIKE '%" + $scope.SearchPurpose + "%'";
        }


        $http({
            url: encodeURI('/PurchaseRequisition/PurchaseRequestionGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {



            $scope.PurchaseRequestionList = data.ListData;
            $scope.total_count = data.TotalRecord;

            angular.forEach(data.ListData, function (aData) {
                var res1 = aData.RequisitionDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.RequisitionDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd-MM-yyyy')).toString();
                    aData.RequisitionDate = date1;
                }
            })


            if (data.TotalRecord > 0) {
                var num1 = 0;
                var num2 = 0;
                var NumberString = data.ListData[0].Number;
                var num1 = Number(NumberString.substr(7, 17));
                num2 = num1 + 1;
                $scope.PurchaseRequestion.Number = NumberString.substr(0, 7) + (num2).toString();
            }
            else {
                $scope.PurchaseRequestion.Number = CounterData.ShortCode + "-" + "PR-1000000001";

            }
        });
    }


    $scope.SearchBtn = function () {
        RequestionGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        $scope.SearchPurpose = "";
        $scope.TormDate = "";
        $scope.TormDate = "";
        $("#FormDate").val("");
        $("#ToDate").val("");
        RequestionGetPaged(1);
    }

    $scope.getData = function (curPage) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            RequestionGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            RequestionGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            RequestionGetPaged($scope.currentPage);
        }
    }

    $scope.OpenReport = function (emp) {
        $window.open("#/PurchaseRequestionReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("RequestionReport",emp);
        event.stopPropagation();
      
    }

});