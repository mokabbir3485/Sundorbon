app.controller("WorkShopRequestionController", function ($scope, $filter, $http, $window, $cookieStore) {
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
        $scope.PerPage = 10;
        $scope.total_count = 0;
        WsRequestionGetPaged($scope.currentPage);

        $scope.currentPageForPurchaseDetails = 1;
        $scope.PerPageForPurchaseDetails = 10;
        $scope.total_countForPurchaseDetails = 0;

        $scope.btnName = "Save";
        $scope.addBtn = "Add";
        $scope.ws_Requestion = {};
        $scope.WSRequestionDetail = {};
        $scope.ItemList = [];
        $scope.ModelList = [];
        $scope.MeasurmentList = [];
        $scope.WsRequestionDetailList = [];
        $scope.WSRequestionDetailListFilter = [];
        $scope.RequestionTypeList = []; 
        $scope.StoreItemList = [];
        $scope.EmployeeList = [];
        // $scope.CounterList = [];
        $scope.requestionStatusList = [];
        $scope.RequestionDetailList = [];
        $scope.JobListForRequestion = [];
        ///Method Call=====>>>
        GetAllItem();
      
        MeasurmentGetAllActive();

        RequestionType();
        GetAllEmployee();
        RequestionStatus();
        GetAllJob();

    }


    function GetAllJob() {
        $http({
            url: "/Job/GetAllJob",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.JobListForRequestion = data;

            angular.forEach(data, function (aData) {
                var res1 = aData.JobDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.JobDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.JobDate = date1;
                }
            })

            PurchaseRequestionDetailGetPaged()
            $scope.JobListForRequestionFilterList = data;
        });
    }

    $scope.StockReportView = function (aReq) {
        $http({
            url: "/Job/GetAllJobItem?Number="+ aReq,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.StoreItemList = data;
            $("#exampleModal").modal('show');

        });
    }

    function RequestionType() {
      
        $http({
            url: "/RequisitionType/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.RequestionTypeList = data;
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
  
    $scope.ReloadRequestionPurpose = function () {
        $scope.RequestionTypeList = [];
        $scope.ddlPurpose = null;
        RequestionType();
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
        var ind = $scope.WsRequestionDetailList.indexOf(aReqDetail);
        $scope.WsRequestionDetailList.splice(ind, 1);
        $scope.WSRequestionDetailListFilter.splice(ind, 1);

        $scope.WsRequestionDetailList = $scope.WSRequestionDetailListFilter;

        //$scope.TotalLength = $scope.WsRequestionDetailList.length;

        $scope.wsTotalLength = $scope.WsRequestionDetailList.length;
        $scope.wsPerPage = 2;
       // $scope.WsCurrentPage = 1;
        const lastIndex = $scope.wsPerPage * $scope.WsCurrentPage;
        const firstIndex = lastIndex - $scope.wsPerPage;
        var item = $scope.WsRequestionDetailList.slice(firstIndex, lastIndex);
        $scope.WsRequestionDetailList = item;


    }


    function WSReqDetailGetPaged() {

        $scope.wsTotalLength = $scope.WsRequestionDetailList.length;
        $scope.wsPerPage = 2;
        $scope.WsCurrentPage = 1;
    }

    $scope.GetReqDetailsDate = function (Cur) {
        $scope.WsCurrentPage = Cur;

        $scope.WsRequestionDetailList = $scope.WSRequestionDetailListFilter;

        const lastIndex = $scope.wsPerPage * Cur;
        const firstIndex = lastIndex - $scope.wsPerPage;
        var item = $scope.WsRequestionDetailList.slice(firstIndex, lastIndex);
        $scope.WsRequestionDetailList = item;

    }


    $scope.SelectJob = function (ajob) {
        $scope.ws_Requestion.JobNumber = ajob.Number;
        $http({
            url: "/Job/GetAllJobItem?Number=" + ajob.Number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.WsRequestionDetailList = data;
            //$("#exampleModal").modal('show');
            $scope.WSRequestionDetailListFilter = $scope.WsRequestionDetailList;

            $scope.TotalLength = $scope.WsRequestionDetailList.length;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;
        });
    }
    $scope.PurchaseRequisitionSave = function () {
        var isValid = true;
        var isValid1 = true;
        var isValid2 = true;
        var isValid3 = true;
        var isValid4 = true;
        var isValid5 = true;

        if ($scope.ws_Requestion.RequistionDate == "" || $scope.ws_Requestion.RequistionDate == undefined) {
            toastr.error('Requisition Date can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.ws_Requestion.JobNumber == null || $scope.ws_Requestion.JobNumber == undefined || $scope.ws_Requestion.Number == "") {
            toastr.error('Job Number Date can not be null or empty');
            isValid1 = false;
        }
        else {

            isValid1 = true;

        }
        if ($scope.ddlRequestionType == null || $scope.ddlRequestionType == undefined) {
            toastr.error('Purpose can not be null or empty');
            isValid2 = false;
        }
        else {
            isValid2 = true;

        }
        if ($scope.ddlEmployee == null || $scope.ddlEmployee == undefined) {
            toastr.error('Employee can not be null or empty');
            isValid3 = false;
        }
        else {

            isValid3 = true;

        }

        if ($scope.WsRequestionDetailList.length == 0) {
            toastr.error('Item detail Info must entry');
            isValid5 = false;
        } else {
            isValid5 = true;
        }

        if (isValid && isValid1 && isValid2 && isValid3 && isValid5) {

            $scope.ws_Requestion.CreatorId = $scope.LoginUser.UserId;
            $scope.ws_Requestion.UpdatorId = $scope.LoginUser.UserId;
            $scope.ws_Requestion.CounterId = CounterData.Id;
          
            $scope.ws_Requestion.RequistionGivenByEmployeeId = $scope.ddlEmployee.EmployeeId;
            $scope.ws_Requestion.SlipAdjForDriverEmloyeeId = $scope.ddlEmployee1.EmployeeId;
            $scope.ws_Requestion.RequistionSlipTypeId = $scope.ddlRequestionType.Id;
         //   $scope.ws_Requestion.ApprovalStatusId =13;
            $scope.ws_Requestion.SlipAdjForDriverEmloyeeId =13;


            $scope.ws_Requestion.DetailNumber = $scope.ws_Requestion.Number;

            //var RequisitionDate = $("#RequisitionDate").val();
            //var RequisitionDate1 = RequisitionDate.split("/");
            //var RequisitionDate2 = new Date(+RequisitionDate1[2], RequisitionDate1[1] - 1, +RequisitionDate1[0]);
            //$scope.ws_Requestion.RequisitionDate = RequisitionDate2;
            $scope.WSRequestionDetailListData = [];
            angular.forEach($scope.WSRequestionDetailListFilter, function (aData) {
                var Item = {};
                Item.ItemId = aData.ItemId;
                Item.RequestedQty = aData.ItemRequiredFromStoreQty;
                Item.DamagedItemQty = aData.ItemDamagedQty;
                Item.Remarks = aData.Remarks;
                Item.IsVoid = 0;
                $scope.WSRequestionDetailListData.push(Item);
            });


            var titleText = "Do you want to save?";
            if ($scope.btnName == "Update") {
                $scope.ws_Requestion.TransactiontionType = "Update";
                titleText = "Do you want to update?";
                $scope.ws_Requestion.ApprovalStatusId = $scope.ddlApprovalStatus.Id;
            } else {
                $scope.ws_Requestion.TransactiontionType = "INSERT";
                $scope.ws_Requestion.Number = CounterData.ShortCode;
                $scope.ws_Requestion.ApprovalStatusId = 2;
            }
            var parms = JSON.stringify({ _ws_Requestion: $scope.ws_Requestion, _ws_RequestionSlipDetails: $scope.WSRequestionDetailListData });



            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/WorkShopRequestion/Save', parms).success(function (data) {
                        if ($scope.btnName == "Save") {
                            toastr.success('Work Shope Requisition saved successfully.');
                        }
                        else {
                            toastr.success('Work Shope Requisition successfully.');
                        }
                        Clear();
                        $scope.WsRequestionDetailList = [];
                        $scope.WSRequestionDetailListFilter = [];
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
        $scope.WSRequestionDetail = aItem;
        $scope.WSRequestionDetailId = aItem.Id;
        // $scope.PurchaseRequestionId = aItem.Id;
        $scope.DetailItemId = aItem.ItemId;
    }




    $scope.addWsRequestionDetail = function () {

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


        if ($scope.WSRequestionDetail.RequestedQty == null || $scope.WSRequestionDetail.RequestedQty == undefined || $scope.WSRequestionDetail.RequestedQty == "") {
            toastr.error('WS Requestion Requested Qty can not be null or empty');
            isValid3 = false;
        }
        else {
            if ($scope.MeasurmentId == 41) {

                var y = Number.isInteger(Number($scope.WSRequestionDetail.RequestedQty));
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

            if ($scope.WsRequestionDetailList.length != $scope.WSRequestionDetailListFilter.length) {
                $scope.WsRequestionDetailList = [];
                $scope.WsRequestionDetailList = $scope.WSRequestionDetailListFilter;
            }
            //if ($scope.WSRequestionDetailId == 0 || $scope.WSRequestionDetailId == undefined) {

                $scope.WSRequestionDetail.ItemId = $scope.ddlItem.Id;
                $scope.WSRequestionDetail.Combination = $scope.ddlItem.Combination;
                $scope.WSRequestionDetail.RequestedQty;
                $scope.WSRequestionDetail.RequestQty = $scope.WSRequestionDetail.RequestedQty;
                $scope.WSRequestionDetail.DamagedItemQty = $scope.WSRequestionDetail.DamagedItemQty;
                $scope.WSRequestionDetail.DetailRemarks = $scope.WSRequestionDetail.Remarks;
                $scope.WsRequestionDetailList.push($scope.WSRequestionDetail);
                $scope.WSRequestionDetailListFilter = $scope.WsRequestionDetailList;
                WSReqDetailGetPaged();
                $scope.WSRequestionDetail = {};
                $scope.ddlPurchaseRequisitionNumber = null;
                $scope.ddlItem = null;
                $scope.ddlModel = null;
            //}
            //else {

            //    angular.forEach($scope.WsRequestionDetailList, function (aData) {
            //        if (aData.ItemId == $scope.DetailItemId && $scope.WSRequestionDetailId == aData.Id) {
            //            aData.Combination = $scope.ddlItem.Combination;
            //            aData.ItemId = $scope.ddlItem.Id;
            //            aData.RequestedQty = $scope.WSRequestionDetail.RequestedQty;
            //            aData.Remarks = $scope.WSRequestionDetail.Remarks;
            //            $scope.WSRequestionDetail.RequestQty = $scope.WSRequestionDetail.RequestedQty;
            //            $scope.WSRequestionDetail.DetailRemarks = $scope.WSRequestionDetail.Remarks;

            //            WSReqDetailGetPaged();

            //            $scope.WSRequestionDetail = {};
            //            $scope.ddlPurchaseRequisitionNumber = null;
            //            $scope.WSRequestionDetail = {};
            //            $scope.ddlPurchaseRequisitionNumber = null;
            //            $scope.ddlItem = null;
            //            $scope.ddlModel = null;
            //            $scope.addBtn = "Add";
            //        }
            //    })
            //    $scope.WSRequestionDetailId = 0;
            //    //$scope.DetailItemId = 0;
            //}



        }

    }

    /// Item Detail Pagination==============>>>>

    $scope.CheckFilter = function () {
        PurchaseRequestionDetailGetPaged();
     
    }
    $scope.ClearSearch = function () {
        $scope.SearchPBFilter = "";
        GetAllJob();
    }

    $scope.ClearSearchBtn = function () {
        PurchaseRequestionDetailGetPaged();
    }
    function PurchaseRequestionDetailGetPaged() {

        $scope.TotalLength = $scope.JobListForRequestion.length;
        $scope.samplePerPage = 3;
        $scope.samplecurrentPage = 1;
    }

    $scope.GetSampleDate = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.JobListForRequestion = $scope.JobListForRequestionFilterList;

        const lastIndex = $scope.samplePerPage * Cur;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.JobListForRequestion.slice(firstIndex, lastIndex);
        $scope.JobListForRequestion = item;

    }


   

    $scope.UpdatePurchaserRequestion = function (aPur) {
        $scope.isEdit = false;
        $scope.ddlApprovalStatus = { Id: aPur.ApprovalStatusId };
        $scope.ws_Requestion.RequisitionDate = aPur.RequisitionDate;
        $scope.ws_Requestion.Number = aPur.Number;
        //  $scope.CounterId = { Id: aPur.CounterId, ShortCode: aPur.ShortCode };

        $scope.ws_Requestion.CounterId = aPur.CounterId;
        $scope.ddlPurpose = { Id: aPur.PurposeId };
        $scope.ddlEmployee = { EmployeeId: aPur.RequestedByEmployeeId };
        $scope.btnName = "Update";
        $scope.WsRequestionDetailList = [];
        $scope.PurchaseRequestionId = aPur.Number;

        $http({
            url: "/PurchaseRequisition/GetByPurchaseRequisitionNumber?Number=" + aPur.Number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            angular.forEach(data, function (aData) {
                aData.RequestQty = aData.RequestedQty;
                aData.DetailRemarks = aData.Remarks;
                $scope.WsRequestionDetailList.push(aData);
                $scope.WSRequestionDetailListFilter = $scope.WsRequestionDetailList;

                $scope.TotalLength = $scope.WsRequestionDetailList.length;
                $scope.samplePerPage = 5;
                $scope.samplecurrentPage = 1;
            })


        });


    }



    $scope.ResetItem = function () {
        Clear();
        PurchaseRequestionDetailGetPaged();
        WSReqDetailGetPaged();
        $scope.WSRequestionDetailListFilter = [];
        $scope.WsRequestionDetailList = [];

    }

    function WsRequestionGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "(RequistionDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (Number LIKE '%" + $scope.SearchItem + "%')";

        }
        else if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
            SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%'";

        }
        else if ($scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "RequistionDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";

        }


        $http({
            url: encodeURI('/WorkShopRequestion/WSRequestionGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {



            $scope.WorkShopRequestionList = data.ListData;
            $scope.total_count = data.TotalRecord;

            angular.forEach(data.ListData, function (aData) {
                var res1 = aData.RequistionDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.RequistionDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.RequistionDate = date1;
                }
            })


            if (data.TotalRecord > 0) {
                var num1 = 0;
                var num2 = 0;
                var NumberString = data.ListData[0].Number;
                var num1 = Number(NumberString.substr(7, 17));
                num2 = num1 + 1;
                $scope.ws_Requestion.Number = NumberString.substr(0, 7) + (num2).toString();
            }
            else {
                $scope.ws_Requestion.Number = CounterData.ShortCode + "-" + "PR-1000000001";

            }
        });
    }


    $scope.SearchBtn = function () {
        WsRequestionGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        $scope.TormDate = "";
        $scope.TormDate = "";
        $("#FormDate").val("");
        $("#ToDate").val("");
        WsRequestionGetPaged(1);
    }

    $scope.getData = function (curPage) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            WsRequestionGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            WsRequestionGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            WsRequestionGetPaged($scope.currentPage);
        }
    }

    $scope.OpenReport = function (emp) {
        $window.open("#/RequestionSlipReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("WSRequestionReport", emp);
        event.stopPropagation();

    }

});