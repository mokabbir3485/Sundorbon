
app.controller("StoreIssueController", function ($scope, $filter, $http, $window, $cookieStore) {
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
        $scope.ddlItem = null;

        $scope.PurchaseDetailsPaginations = false;

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        IssueGetPaged($scope.currentPage);

        $scope.currentPageForPurchaseDetails = 1;
        $scope.PerPageForPurchaseDetails = 10;
        $scope.total_countForPurchaseDetails = 0;

        $scope.btnName = "Save";
        $scope.addBtn = "Add";
        $scope.StoreIssue = {};

        $scope.PurchaseRequestionDetail = {};
        $scope.IssueRequestion = {};
        $scope.ItemList = [];
        $scope.ModelList = [];
        $scope.MeasurmentList = [];
        $scope.PurchaseRequestionDetailList = [];
        $scope.PurchaseRequestionDetailListFilter = [];
        $scope.RequestionPurposeList = [];
        $scope.EmployeeList = [];
       // $scope.StoreRackList = [];
        // $scope.CounterList = [];
        $scope.requestionStatusList = [];
        $scope.RequestionDetailList = [];

        $scope.IssueTypeList = [];
        $scope.issueItemList = [];
        $scope.RackList = [];
        $scope.ddlRack = null;

        GetIssueTypeAll();
        ///Method Call=====>>>
        GetAllItem();
        GetAllModel();
        MeasurmentGetAllActive();

        RequestionPurpose();
        GetAllEmployee();
        RequestionStatus();
        StoreAll();
        GetAllRack();


    }



    function GetIssueTypeAll() {
        $http({
            url: "/IssuesType/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.IssueTypeList = data;
        });
    }


    function GetAllRack() {
        $http({
            url: "/Store/GetAllRack",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.RackList = data;
        });
    }

    function StoreAll() {
        $http({
            url: "/Store/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.StoreList = data;
        });
    }


    $scope.SelectStoreRack = function (ddl) {
        $http({
            url: "/StoreRack/GetByStoreId?Id="+ddl.Id,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.StoreRackList = data;

            angular.forEach($scope.issueItemList,function (aData) {
                aData.RackId = $scope.StoreRackList[0].Id;
                aData.Id =0;
            })
        });
    }

    $scope.GetIssueForDetails = function (NumberObj) {
        //$scope.ItemReceive.Number = NumberObj.Number;
        if ($scope.ddlIssueType.Id == 2) {
            $scope.StoreIssue.ReferenceId = NumberObj.Number;
            $http({
                url: "/PurchaseBill/GetByPurchaseBillNumber?Number=" + NumberObj.Number,
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {


                angular.forEach(data, function (aData) {
                    aData.PurchaseQty = aData.Qty;
          
                    aData.IssuedPrice = aData.UnitPrice;

                   // aData.RackId = $scope.StoreRackList.StoreId;

                })
                $scope.issueItemList = data;

            });
        }
        else if ($scope.ddlIssueType.Id == 1) {
            $scope.StoreIssue.ReferenceId = NumberObj.Number;
            $http({
                url: "/WorkShopRequestion/GetByPurchaseRequisitionNumber?Number=" + NumberObj.Number,
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
               
                angular.forEach(data,function (aData) {
                  //  aData.RackId = $scope.StoreRackList[0].StoreId;
                })
                $scope.issueItemList = data;
            });
        }

    }




    
    $scope.addIssueDetail = function () {
        $scope.IssueRequestion.Combination = $scope.IssueRequestion.ddlItem.Combination;
        $scope.IssueRequestion.ItemId = $scope.IssueRequestion.ddlItem.Id;

        var item = {};
        item.Combination = $scope.IssueRequestion.Combination;
        item.IssuedQty = $scope.IssueRequestion.IssuedQty;
        item.IssuedPrice = $scope.IssueRequestion.IssuedPrice;
        item.Remarks = $scope.IssueRequestion.Remarks;
        item.ItemId = $scope.IssueRequestion.ddlItem.Id;
        item.RackId = $scope.IssueRequestion.RackId;

        $scope.issueItemList.push(item);
        $scope.IssueRequestion = {};
        $scope.ddlItem = null;
        $scope.ddlRack = null;
    }
    

    $scope.LoadForIssue = function () {
        if ($scope.FormDate =="" || $scope.FormDate == undefined) {
            $scope.FormDate = null;
        }
        if ($scope.ToDate == "" || $scope.ToDate == undefined) {
            $scope.ToDate= null;
        }

        if ($scope.ddlIssueType.Id == 1) {
            $scope.LoadForIssueList = [];
            $scope.issueItemList = [];
            IssueForLoadWS()
            $scope.StoreIssue.ReferenceId = "";
        } else if ($scope.ddlIssueType.Id == 2) {
            $scope.StoreIssue.ReferenceId = "";
            $scope.issueItemList = [];
            $scope.LoadForIssueList = [];
            IssueForLoadPb()
        } else {
            $scope.issueItemList = [];
            $scope.LoadForIssueList = [];
            $scope.StoreIssue.ReferenceId = "00001";
        }
      
    }

    $scope.LoadForWSAndPB = function () {
        $scope.LoadForIssue();
    }


    function IssueForLoadWS() {
      
        $http({
            url: "/WorkShopRequestion/ws_RequistionSlip_GetByIssue?fromdate=" + $scope.FormDate + "&toDate=" + $scope.ToDate,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.LoadForIssueList = data;
            $scope.LoadForIssueFilterList = data;

            angular.forEach(data, function (aData) {
                var res1 = aData.RequistionDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.RequistionDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.RequistionDate = date1;
                }
            })

            IssueGetPagedList();
        });
    }
    function IssueForLoadPb() {

        $http({
            url: "/PurchaseBill/p_PurchaseBill_GetByIssue?fromdate=" + $scope.FormDate + "&toDate=" + $scope.ToDate,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.LoadForIssueList = data;
            $scope.LoadForIssueFilterList = data;
            angular.forEach(data, function (aData) {
                var res1 = aData.BillDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.BillDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.BillDate = date1;
                }
            })

            IssueGetPagedList();
           
        });
    }

    $scope.ClearForIssue = function () {

        $scope.ddlIssueType = null;
        $scope.FormDate = "";
        $scope.ToDate = "";
        $scope.LoadForIssueList =[];
        $scope.LoadForIssueFilterList = [];
        $scope.issueItemList = [];
        IssueGetPaged();
    }
    function IssueGetPagedList() {

        $scope.TotalLength = $scope.LoadForIssueList.length;
        $scope.samplePerPage = 3;
        $scope.samplecurrentPage = 1;
    }

    $scope.GetSampleDate = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.LoadForIssueList = $scope.LoadForIssueFilterList;

        const lastIndex = $scope.samplePerPage * Cur;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.LoadForIssueList.slice(firstIndex, lastIndex);
        $scope.LoadForIssueList = item;

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

   

   

    $scope.IssueSave = function () {
        var isValid = true;
        var isValid1 = true;
        var isValid2 = true;
        var isValid3 = true;
        var isValid4 = true;
        var isValid5 = true;

        if ($scope.StoreIssue.IssueDate == "" || $scope.StoreIssue.IssueDate == undefined) {
            toastr.error('Issue Date can not be null or empty');
            isValid = false;
        }
        else {
            if (isValid) {
                isValid = true;
            }
        }
        if ($scope.StoreIssue.IssueNo == "" || $scope.StoreIssue.IssueNo == undefined ) {
            toastr.error('Issue No can not be null or empty');
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
        if ($scope.ddlIssuedByUserId == null || $scope.ddlIssuedByUserId == undefined) {
            toastr.error('Issued By can not be null or empty');
            isValid3 = false;
        }
        else {
            isValid3 = true;
        }

        if ($scope.ddlIssuedFromStore == null || $scope.ddlIssuedFromStore == undefined) {
            toastr.error('Issued From Store can not be null or empty');
            isValid4 = false;
        }
        else {
            isValid4 = true;
        }

        if ($scope.issueItemList.length == 0) {
            toastr.error('Item detail Info must entry');
            isValid5 = false;
        } else {
            isValid5 = true;
        }

        if (isValid && isValid1 && isValid2 && isValid3 && isValid5 && isValid4) {

            $scope.StoreIssue.CreatorId = $scope.LoginUser.UserId;
            $scope.StoreIssue.UpdatorId = $scope.LoginUser.UserId;
            $scope.StoreIssue.CounterId = CounterData.Id;
            $scope.StoreIssue.PurposeId = $scope.ddlPurpose.Id;
            $scope.StoreIssue.IssuedByUserId = $scope.ddlIssuedByUserId.EmployeeId;
            $scope.StoreIssue.IssueTypeId = $scope.ddlIssueType.Id;
            $scope.StoreIssue.IssuedFromStoreId = $scope.ddlIssuedFromStore.Id;



           // $scope.StoreIssue.DetailNumber = $scope.StoreIssue.Number;

            //var RequisitionDate = $("#RequisitionDate").val();
            //var RequisitionDate1 = RequisitionDate.split("/");
            //var RequisitionDate2 = new Date(+RequisitionDate1[2], RequisitionDate1[1] - 1, +RequisitionDate1[0]);
            //$scope.StoreIssue.RequisitionDate = RequisitionDate2;

            var titleText = "Do you want to save?";
            if ($scope.btnName == "Update") {
                $scope.StoreIssue.TransactiontionType = "Update";
                titleText = "Do you want to update?";
                $scope.StoreIssue.ApprovalStatusId = $scope.ddlApprovalStatus.Id;
            } else {
                $scope.StoreIssue.TransactiontionType = "INSERT";
                $scope.StoreIssue.IssueNo = CounterData.ShortCode;
                $scope.StoreIssue.ApprovalStatusId = 2;
            }
            var parms = JSON.stringify({ _StoreIssue: $scope.StoreIssue, _StoreIssueDetails: $scope.issueItemList });



            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/Issue/Save', parms).success(function (data) {
                        toastr.success('Issue saved successfully.');
                        Clear();
                        $scope.issueItemList = [];
                    
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

  

    $scope.ResetItem = function () {
        Clear();
       

    }

    function IssueGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "(IssueDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (IssueNo LIKE '%" + $scope.SearchItem + "%')";

        }
        else if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
            SearchCriteria = "IssueNo LIKE '%" + $scope.SearchItem + "%'";

        }
        else if ($scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "IssueDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";

        }


        $http({
            url: encodeURI('/Issue/IssuedGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {



            $scope.IssuegepagedList = data.ListData;
            $scope.total_count = data.TotalRecord;

            angular.forEach(data.ListData, function (aData) {
                var res1 = aData.IssueDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.IssueDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.IssueDate = date1;
                }
            })


            if (data.TotalRecord > 0) {
                var num1 = 0;
                var num2 = 0;
                var NumberString = data.ListData[0].IssueNo;
                var num1 = Number(NumberString.substr(7, 17));
                num2 = num1 + 1;
                $scope.StoreIssue.IssueNo = NumberString.substr(0, 7) + (num2).toString();
            }
            else {
                $scope.StoreIssue.IssueNo = CounterData.ShortCode + "-" + "PR-1000000001";

            }
        });
    }


    $scope.SearchBtn = function () {
        IssueGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        $scope.TormDate = "";
        $scope.TormDate = "";
        $("#FormDate").val("");
        $("#ToDate").val("");
        IssueGetPaged(1);
    }

    $scope.getData = function (curPage) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            IssueGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            IssueGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            IssueGetPaged($scope.currentPage);
        }
    }

    $scope.OpenReport = function (emp) {
        $window.open("#/StoreIssueReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("IssueReport", emp);
        event.stopPropagation();

    }

});