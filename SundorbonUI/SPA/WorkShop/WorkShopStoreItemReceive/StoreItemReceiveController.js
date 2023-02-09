app.controller("StoreItemReceiveController", function ($scope, $filter, $http, $window, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
        console.log(CounterData);
        Clear();

        function Clear() {
            $scope.TormDate = "";
            $scope.FormDate = "";
            $scope.currentPage = 1;
            $scope.PerPage = 10;
            $scope.total_count = 0;
            StoreItemReceiveGetPaged($scope.currentPage);
            //$scope.ddlEmployee = { EmployeeId: $scope.LoginUser.EmployeeId }
            $scope.addBtn = "Add";
            $scope.btnName = "Save";
            $scope.TotalLength = 0;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;
            $scope.StoreItemReceive = {};
            $scope.ItemReceive = {};
            $scope.SearchPBOrPSN = "";
            $scope.inv_StoreIssueDetailList = [];

            $scope.inv_StoreIssueList = [];
            $scope.inv_StoreIssueFilter = [];
            $scope.StoreReceiveGetPagedList = [];
            $scope.EmployeeList = [];
            $scope.ApprovalGivenOnList = [];
            $scope.ddlApprovalGivenOn = null;
            $scope.ddlStore = null;
            $scope.ddlStoreRack = null;
            // GetAllPurchase();
            GetAllEmployee();
            ApprovalGivenOnGetAllActive();
            GetAllStore();
        }
        function GetAllStore() {
            $http({
                url: "/Store/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {

                $scope.StoreList = data;


            });
        }

        $scope.ReloadStore = function () {
            $scope.ddlStore = null;
            $scope.StoreList = {};
            GetAllStore();
        }

        $scope.SelectStoreRack = function () {
            GetAllStoreRack();
        }

        function GetAllStoreRack() {
            if ($scope.ddlStore != null || $scope.ddlStore != undefined) {
                $http({
                    url: "/StoreRack/GetByStoreId?Id=" + $scope.ddlStore.Id,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    $scope.StoreRackList = data;
                });
            }
            else {
                toastr.error("Please select store");
            }

        }

        $scope.ReloadStoreRack = function () {
            $scope.StoreRackList = [];
            GetAllStoreRack();
        }



        function ApprovalGivenOnGetAllActive() {
            $http({
                url: "/ApprovalGivenOn/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {

                $scope.ApprovalGivenOnList = data;


            });
        }


        $scope.ApprovalChange = function () {
            var statusID = $scope.ddlApprovalGivenOn.Id;
            if (statusID == 15) {
                $scope.inv_StoreIssueList = [];
                GetAllIssueItem();
            }
            else if (statusID == 14) {
                $scope.inv_StoreIssueList = [];
                GetAllStoreIssue();
            }
        }
        function GetAllIssueItem() {
            $http({
                url: "/WorkShopItemIssue/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                angular.forEach(data, function (aData) {
                    $scope.inv_StoreIssueList = data;
                    var res1 = aData.IssueDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.IssueDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd-MMM-yyyy')).toString();
                        aData.IssueDate = date1;
                    }
                })
                $scope.inv_StoreIssueFilter = data;
                TEst(data[0].Number);
                PurchaseRequestionDetailGetPaged();
            });
        }
        function GetAllStoreIssue() {
            $http({
                url: "/StoreIssue/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                angular.forEach(data, function (aData) {
                    $scope.inv_StoreIssueList = data;
                    var res1 = aData.IssueDate.substring(0, 5);
                    var res2 = aData.RequistionDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.IssueDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd-MMM-yyyy')).toString();
                        aData.IssueDate = date1;
                    }
                    if (res2 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.RequistionDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd-MMM-yyyy')).toString();
                        aData.RequistionDate = date1;
                    }
                })
                $scope.inv_StoreIssueFilter = data;
                PurchaseRequestionDetailGetPaged();
            });
        }
        $scope.ReloadApprovalGivenOnGet = function () {
            $scope.ApprovalGivenOnList = {};
            $scope.ddlApprovalGivenOn = null;
            ApprovalGivenOnGetAllActive()
        }

        function PurchaseRequestionDetailGetPaged() {

            $scope.TotalLength = $scope.inv_StoreIssueList.length;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;
        }

        function DetailGetPaged() {

            $scope.DetailsTotalLength = $scope.inv_StoreIssueDetailList.length;
            $scope.DetailsPerPage = 5;
            $scope.DetailscurrentPage = 1;
        }

        $scope.GetSampleDate = function (Cur) {
            $scope.TempCurrentPage = Cur;

            $scope.inv_StoreIssueList = $scope.inv_StoreIssueFilter;

            const lastIndex = $scope.samplePerPage * Cur;
            const firstIndex = lastIndex - $scope.samplePerPage;
            var item = $scope.inv_StoreIssueList.slice(firstIndex, lastIndex);
            $scope.inv_StoreIssueList = item;

        }

        $scope.GetDetailsDate = function (Cur) {
            $scope.DetailsTempCurrentPage = Cur;

            $scope.inv_StoreIssueDetailList = $scope.inv_StoreIssueDetailFilter;

            const lastIndex = $scope.DetailsPerPage * Cur;
            const firstIndex = lastIndex - $scope.DetailsPerPage;
            var item = $scope.inv_StoreIssueDetailList.slice(firstIndex, lastIndex);
            $scope.inv_StoreIssueDetailList = item;

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

        $scope.Getinv_StoreIssueDetail = function (NumberObj) {
            $scope.ItemReceive.RequistionSlipNo = NumberObj.RequisitionNo;
             if ($scope.ddlApprovalGivenOn.Id == 14) {
                $scope.ItemReceive.StoreIssueNumber = NumberObj.IssueNo;
                $http({
                    url: "/StoreIssueDetail/GetByStoreIssueNumber?Number=" + NumberObj.IssueNo,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    $scope.inv_StoreIssueDetailList = data;
                    $scope.inv_StoreIssueDetailFilter = $scope.inv_StoreIssueDetailList;
                    DetailGetPaged();
                });
            }
             else if ($scope.ddlApprovalGivenOn.Id == 15) {
                 $scope.ItemReceive.StoreIssueNumber = NumberObj.IssueNo;
                 $http({
                     url: "/WorkShopItemIssueDetails/GetAll?Number=" + NumberObj.IssueNo,
                     method: 'GET',
                     headers: { 'Content-Type': 'application/json' }
                 }).success(function (data) {
                     $scope.inv_StoreIssueDetailList = data;
                     $scope.inv_StoreIssueDetailFilter = $scope.inv_StoreIssueDetailList;
                     DetailGetPaged();
                 });
             }

        }


      



        $scope.ReloadSupplier = function () {
            $scope.SupplierList = {};
            $scope.ddlSupplierId = null;
            GetAllSupplier();
        }
        $scope.ReloadPurchase = function () {
            $scope.PurchaseRequestionList = {};
            $scope.ddlApprovalStatus = null;
            GetAllPurchase();
        }



        //============ SAVE  ===========>>>>>>

        $scope.SaveStoreItemReceive = function () {

            var isValid = true;
            if ($scope.ItemReceive.StoreIssueNumber == undefined || $scope.ItemReceive.StoreIssueNumber == "") {
                toastr.error(' Store Issue Number can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
            }

            if (($scope.ItemReceive.RequistionSlipNo == undefined || $scope.ItemReceive.RequistionSlipNo == "") && $scope.ddlApprovalGivenOn.Id == 14) {
                toastr.error('Requisition Slip No can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
            }
            if (($scope.ItemReceive.ReceivedPrice == undefined || $scope.ItemReceive.ReceivedPrice == "") && $scope.ddlApprovalGivenOn.Id == 15) {
                toastr.error('Received Price can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
            }
            if ($scope.ItemReceive.ManualReferenceNumber == undefined || $scope.ItemReceive.ManualReferenceNumber == "") {
                toastr.error('Manual Reference Number can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
            }
            if ($scope.ddlEmployee == null || $scope.ddlEmployee == undefined) {
                toastr.error('Received by can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
            }
            if ($scope.ddlEmployeeForInspected == null || $scope.ddlEmployeeForInspected == undefined) {
                toastr.error('Inspected by can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
            }
            if ($scope.ddlStoreRack == null || $scope.ddlStoreRack == undefined) {
                toastr.error('Store Rack can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }

            }
            if ($scope.ddlStore == null || $scope.ddlStore == undefined) {
                toastr.error('Store can not be null or empty');
                isValid = false;
            } else {
                if (isValid) {
                    isValid = true;
                }
               
            }

            if (isValid) {

                $scope.StockReciveObj = {};
                $scope.ItemReceive.CounterId = CounterData.Id;
                $scope.ItemReceive.CreatorId = $scope.LoginUser.UserId;
                $scope.ItemReceive.UpdatorId = $scope.LoginUser.UserId;
                $scope.ItemReceive.ReceivedByEmployeeId = $scope.ddlEmployee.EmployeeId;
                $scope.ItemReceive.InspectedByEmployeeId = $scope.ddlEmployeeForInspected.EmployeeId;
                if ($scope.ddlApprovalGivenOn.Id == 15) {
                    $scope.ItemReceive.RequistionSlipNo = "NA";
                }
                //$scope.ItemReceive.StockReceivedFrom = 1;
                if ($scope.ItemReceive.Remarks == null || $scope.ItemReceive.Remarks == undefined) {
                    $scope.ItemReceive.Remarks = "NA";
                }

                //$scope.ItemReceive.inv_StoreIssueOrRequisitionSlipNo = $scope.ItemReceive.Number;

                var titleText = "Do you want to save?";
                var IsUppdate = false;
                if ($scope.btnName == "Update") {
                    $scope.ItemReceive.TransactiontionType = "Update";
                    titleText = "Do you want to update?";
                    IsUppdate = true;
                } else {
                    $scope.ItemReceive.TransactiontionType = "INSERT";
                    $scope.ItemReceive.Number = CounterData.ShortCode;
                }

                var FilterList = [];
                angular.forEach($scope.inv_StoreIssueDetailList, function (aData) {
                    var reciveItem = {};
                    reciveItem.StoreId = 1;
                    reciveItem.RackId = $scope.ddlStoreRack.Id;
                    reciveItem.ItemId = aData.ItemId;
                    reciveItem.ReceiveQty = aData.IssuedQty;
                    reciveItem.ReceivedPrice = $scope.ItemReceive.ReceivedPrice;
                    reciveItem.IsVoid = false;
                    reciveItem.Remarks = aData.Remarks;
                    if (IsUppdate) {
                        reciveItem.TransactiontionType = "Update";
                    }
                    else {
                        reciveItem.TransactiontionType = "INSERT";
                    }
                    FilterList.push(reciveItem);
                });

                var parms = JSON.stringify({ _StoreItemReceive: $scope.ItemReceive, _inv_StoreItemReceiveDetail: FilterList });

                swal.fire({
                    title: titleText,
                    icon: 'warning',
                    showCancelButton: true,
                    cancelButtonText: 'Cancel',
                    reverseButtons: true
                }).then((result) => {
                    if (result.value == true) {
                        $http.post('/WSStoreItemReceive/Save', parms).success(function (data) {
                            if ($scope.btnName == "Save") {

                                toastr.success('Item Received saved successfully.');
                            }
                            else {
                                toastr.success('Item Received successfully.');
                            }
                            Clear();

                        }).error(function (data) {
                            toastr.error('Server Errors!');

                        });
                    }
                    else if (result.dismiss == "cancel") {
                        Swal.DismissReason.cancel;
                    }
                })
                //  }
                //else {
                // toastr.error('Item quantity and  unit price must be entry!');
                //}

            }
        }

        $scope.UpdatePurchaserBill = function (aPb) {
            $scope.inv_StoreIssueDetailList = [];
            $scope.btnName = "Update"
            $scope.ddlApprovalStatus = { Id: aPb.ApprovalStatusId };
            $scope.StoreItemReceive.CounterId = aPb.CounterId;
            $scope.ddlSupplierId = { Id: aPb.SupplierId };
            $scope.StoreItemReceive = aPb;
            $scope.TotalPrice = 0;
            $http({
                url: "/StoreItemReceive/GetByinv_StoreIssueNumber?Number=" + aPb.Number,
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {


                angular.forEach(data, function (aData) {
                    aData.TotalAmount = aData.AfterDiscount + aData.SD + aData.VAT + aData.AIT;
                    $scope.TotalPrice += aData.AfterDiscount + aData.SD + aData.VAT + aData.AIT;
                    $scope.inv_StoreIssueDetailList.push(aData);
                })
            });

        }

        $scope.AmountCalculation = function (aPB) {
            var Total = 0;
            aPB.Amount = aPB.Qty * aPB.UnitPrice;
            aPB.AfterDiscount = aPB.Amount - aPB.Discount;
            aPB.TotalAmount = aPB.AfterDiscount + aPB.SD + aPB.VAT + aPB.AIT;

            Total = aPB.TotalAmount;


            //angular.forEach($scope.inv_StoreIssueDetailList, function (aData) {
            //    if (aData.ItemId == aPB.ItemId) {
            //        $scope.TotalPrice += Total;
            //    }
            //})
        }



        //============ Reset  ===========>>>>>>

        $scope.ResetItem = function () {
            Clear();
        }

        function StoreItemReceiveGetPaged(curPage) {

            if (curPage == null) curPage = 1;
            var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

            //var SearchCriteria = "";


            //if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            //    SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%' OR BillDate LIKE '%" + $scope.SearchItem + "%'";

            //}

            var SearchCriteria = "";

            //if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" && $scope.TormDate != "") {
            //    SearchCriteria = "(SR.[StockReceiveDate] between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (Number LIKE '%" + $scope.SearchItem + "%')";

            //}
            if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
                SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%'";
            }
            //else if ($scope.SearchPBOrPSN !== undefined && $scope.SearchPBOrPSN != null && $scope.SearchPBOrPSN != "") {
            //    SearchCriteria = "inv_StoreIssueOrRequisitionSlipNo LIKE '%" + $scope.SearchPBOrPSN + "%'";
            //}
            else if ($scope.FormDate != "" && $scope.TormDate != "") {
                SearchCriteria = "ReceiveDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";
            }



            $http({
                url: encodeURI('/WSStoreItemReceive/StoreItemPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {

                $scope.StoreReceiveGetPagedList = data.ListData;
                $scope.total_count = data.TotalRecord;

                angular.forEach(data.ListData, function (aData) {
                    var res1 = aData.ReceiveDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.ReceiveDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd-MMMM-yyyy')).toString();
                        aData.ReceiveDate = date1;
                    }
                })




                //if (data.TotalRecord > 0) {
                //    var num1 = 0;
                //    var num2 = 0;
                //    var NumberString = data.ListData[0].Number;
                //    var num1 = Number(NumberString.substr(7, 17));
                //    num2 = num1 + 1;
                //    $scope.PurchaseRequestion.Number = NumberString.substr(0, 7) + (num2).toString();
                //}
                //else {
                //    $scope.PurchaseRequestion.Number = CounterData.ShortCode + "-" + "PR-1000000001";

                //}
            });
        }


        $scope.SearchBtn = function () {
            StoreItemReceiveGetPaged(1);
        }

        $scope.ClearBtn = function () {
            $scope.SearchItem = "";
            $scope.SearchItem = "";
            $scope.TormDate = "";
            $scope.TormDate = "";
            $("#FormDate").val("");
            $("#ToDate").val("");
            StoreItemReceiveGetPaged(1);
        }

        $scope.getData = function (curPage) {

            // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

            if ($scope.PerPage > 100) {
                $scope.PerPage = 100;
                $scope.currentPage = curPage;
                StoreItemReceiveGetPaged($scope.currentPage);
                //  alertify.log('Maximum record  per page is 100', 'error', '5000');
                toastr.error('Maximum record  per page is 100');
            }
            else if ($scope.PerPage < 1) {
                $scope.PerPage = 1;
                $scope.currentPage = curPage;
                StoreItemReceiveGetPaged($scope.currentPage);
                // alertify.log('Minimum record  per page is 1', 'error', '5000');
                toastr.error('Maximum record  per page is 100');
            }
            else {
                $scope.currentPage = curPage;
                StoreItemReceiveGetPaged($scope.currentPage);
            }
        }


    }

    $scope.OpenReport = function (Number) {
        // $scope.Number = emp.Number;
        $window.open("#/WorkshopItemReceiveDetailsReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("Number", Number);
        event.stopPropagation();

    }

});