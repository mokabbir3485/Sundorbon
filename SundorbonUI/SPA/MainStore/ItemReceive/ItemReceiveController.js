

app.controller("ItemReceiveController", function ($scope, $filter, $http, $window, $cookieStore) {
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
            $scope.ddlEmployee = { EmployeeId: $scope.LoginUser.EmployeeId }
            $scope.addBtn = "Add";
            $scope.btnName = "Save";
            $scope.TotalLength = 0;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;
            $scope.StoreItemReceive = {};
            $scope.ItemReceive = {};
            $scope.SearchPBOrPSN = "";
            $scope.PurchaseBillDetailList = [];

            $scope.PurchaseBillList = [];
            $scope.PurchaseBillFilter = [];
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
            if (statusID == 1) {
                $scope.PurchaseBillList = [];
                GetAllPurchase();
            }
            else if (statusID == 13) {
                $scope.PurchaseBillList = [];
                GetAllWorkShopRequisitionSlip();
            }
        }
        function GetAllWorkShopRequisitionSlip() {
            $http({
                url: "/WorkShopRequestion/GetAllRequisitionSlip",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                angular.forEach(data, function (aData) {
                    $scope.PurchaseBillList = data;
                    var res1 = aData.RequistionDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.RequistionDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                        aData.RequistionDate = date1;
                    }
                })
                $scope.PurchaseBillFilter = data;
                PurchaseRequestionDetailGetPaged();
            });
        }
        $scope.ReloadApprovalGivenOnGet = function () {
            $scope.ApprovalGivenOnList = {};
            $scope.ddlApprovalGivenOn = null;
            ApprovalGivenOnGetAllActive()
        }

        function PurchaseRequestionDetailGetPaged() {

            $scope.TotalLength = $scope.PurchaseBillList.length;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;
        }

        $scope.GetSampleDate = function (Cur) {
            $scope.TempCurrentPage = Cur;

            $scope.PurchaseBillList = $scope.PurchaseBillFilter;

            const lastIndex = $scope.samplePerPage * Cur;
            const firstIndex = lastIndex - $scope.samplePerPage;
            var item = $scope.PurchaseBillList.slice(firstIndex, lastIndex);
            $scope.PurchaseBillList = item;

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

        $scope.GetPurchaseBillDetail = function (NumberObj) {
            $scope.ItemReceive.Number = NumberObj.Number;
            if ($scope.ddlApprovalGivenOn.Id == 1) {
                $scope.ItemReceive.PurchaseBillOrRequisitionSlipNo = NumberObj.PurchaseRequisitionNumber;
                $http({
                    url: "/PurchaseBill/GetByPurchaseBillNumber?Number=" + NumberObj.Number,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {


                    angular.forEach(data, function (aData) {
                        aData.ReceivedQty = aData.Qty;
                        aData.ReceivedUnitPrice = aData.UnitPrice;

                    })
                    $scope.PurchaseBillDetailList = data;

                });
            }
            else if ($scope.ddlApprovalGivenOn.Id == 13) {
                $scope.ItemReceive.PurchaseBillOrRequisitionSlipNo = NumberObj.Number;
                $http({
                    url: "/WorkShopRequestion/GetByPurchaseRequisitionNumber?Number=" + NumberObj.Number,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    //angular.forEach(data, function (aData) {
                    //    $scope.PurchaseBillList = data;
                    //    var res1 = aData.RequistionDate.substring(0, 5);
                    //    if (res1 == "/Date") {
                    //        var parsedDate1 = new Date(parseInt(aData.RequistionDate.substr(6)));
                    //        var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    //        aData.RequistionDate = date1;
                    //    }
                    //})
                    $scope.PurchaseBillDetailList = data;
                });
            }

        }


        function GetAllPurchase() {
            $http({
                url: "/PurchaseBill/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                angular.forEach(data, function (aData) {
                    $scope.PurchaseBillList = data;
                    var res1 = aData.BillDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.BillDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                        aData.BillDate = date1;
                    }
                })
                $scope.PurchaseBillFilter = data;
                PurchaseRequestionDetailGetPaged();
            });
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

        $scope.StoreItemReceive = function () {

            var isValid = true;
            var isValid1 = true;
            var isValid2 = true;
            var isValid3 = true;
            var isValid4 = true;
            var isValid5 = true;

            //if ($scope.ItemReceive.StockReceiveDate == undefined || $scope.ItemReceive.StockReceiveDate == "") {
            //    toastr.error(' Receive Date can not be null or empty');
            //    isValid = false;
            //} else {
            //    isValid = true;
            //}

            if ($scope.ItemReceive.Number == undefined || $scope.ItemReceive.Number == "") {
                toastr.error(' Number can not be null or empty');
                isValid1 = false;
            } else {
                isValid1 = true;
            }

            if ($scope.ItemReceive.PurchaseBillOrRequisitionSlipNo == undefined || $scope.ItemReceive.PurchaseBillOrRequisitionSlipNo == "") {
                toastr.error('Purchase Bill Or RequisitionSlipNo can not be null or empty');
                isValid2 = false;
            } else {
                isValid2 = true;
            }

            if ($scope.ddlEmployee == null || $scope.ddlEmployee == undefined) {
                toastr.error('Received by can not be null or empty');
                isValid3 = false;
            } else {
                isValid3 = true;
            }
            if ($scope.ddlStoreRack == null || $scope.ddlStoreRack == undefined) {
                toastr.error('Store Rack can not be null or empty');
                isValid4 = false;
            } else {
                isValid4 = true;
            }

            if (isValid && isValid1 && isValid2 && isValid3 && isValid4) {

                $scope.StockReciveObj = {};
                $scope.ItemReceive.CounterId = CounterData.Id;
                $scope.ItemReceive.CreatorId = $scope.LoginUser.UserId;
                $scope.ItemReceive.UpdatorId = $scope.LoginUser.UserId;
                $scope.ItemReceive.ReceivedByUserId = $scope.ddlEmployee.EmployeeId;
                $scope.ItemReceive.StockReceivedFrom = 1;

                $scope.ItemReceive.PurchaseBillOrRequisitionSlipNo = $scope.ItemReceive.Number;

                var titleText = "Do you want to save?";
                if ($scope.btnName == "Update") {
                    $scope.StoreItemReceive.TransactionType = "Update";
                    titleText = "Do you want to update?";
                } else {
                    $scope.ItemReceive.TransactionType = "INSERT";
                    $scope.ItemReceive.Number = CounterData.ShortCode;
                }

                var FilterList = [];
                var isFlag = true;
                angular.forEach($scope.PurchaseBillDetailList, function (aData) {
                    //if (aData.Qty == 0 || aData.Qty == undefined) {

                    var reciveItem = {};
                    reciveItem.StockReceiveId = 1;
                    reciveItem.StoreRackId = $scope.ddlStoreRack.Id;
                    reciveItem.ItemId = aData.ItemId;
                    if (aData.Qty == undefined || aData.Qty == null) {
                        reciveItem.ReceivedQty = aData.DamagedItemQty;
                    }
                    else {
                        reciveItem.ReceivedQty = aData.Qty;
                    }
                    reciveItem.ReceivedUnitPrice = aData.UnitPrice;
                    reciveItem.Id = 0;
                    FilterList.push(reciveItem);
                    // isFlag = false;
                    // }

                });

                var parms = JSON.stringify({ _StoreItemReceive: $scope.ItemReceive, _inv_StoreItemReceiveDetail: FilterList });




                // if (isFlag) {

                swal.fire({
                    title: titleText,
                    icon: 'warning',
                    showCancelButton: true,
                    cancelButtonText: 'Cancel',
                    reverseButtons: true
                }).then((result) => {
                    if (result.value == true) {
                        $http.post('/StoreItemRecive/Save', parms).success(function (data) {
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
            $scope.PurchaseBillDetailList = [];
            $scope.btnName = "Update"
            $scope.ddlApprovalStatus = { Id: aPb.ApprovalStatusId };
            $scope.StoreItemReceive.CounterId = aPb.CounterId;
            $scope.ddlSupplierId = { Id: aPb.SupplierId };
            $scope.StoreItemReceive = aPb;
            $scope.TotalPrice = 0;
            $http({
                url: "/StoreItemReceive/GetByPurchaseBillNumber?Number=" + aPb.Number,
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {


                angular.forEach(data, function (aData) {
                    aData.TotalAmount = aData.AfterDiscount + aData.SD + aData.VAT + aData.AIT;
                    $scope.TotalPrice += aData.AfterDiscount + aData.SD + aData.VAT + aData.AIT;
                    $scope.PurchaseBillDetailList.push(aData);
                })
            });

        }

        $scope.AmountCalculation = function (aPB) {
            var Total = 0;
            aPB.Amount = aPB.Qty * aPB.UnitPrice;
            aPB.AfterDiscount = aPB.Amount - aPB.Discount;
            aPB.TotalAmount = aPB.AfterDiscount + aPB.SD + aPB.VAT + aPB.AIT;

            Total = aPB.TotalAmount;


            //angular.forEach($scope.PurchaseBillDetailList, function (aData) {
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
            else if ($scope.SearchPBOrPSN !== undefined && $scope.SearchPBOrPSN != null && $scope.SearchPBOrPSN != "") {
                SearchCriteria = "PurchaseBillOrRequisitionSlipNo LIKE '%" + $scope.SearchPBOrPSN + "%'";
            }
            else if ($scope.FormDate != "" && $scope.TormDate != "") {
                SearchCriteria = "SR.[StockReceiveDate] between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";
            }



            $http({
                url: encodeURI('/StoreItemRecive/StoreReceiveGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {

                $scope.StoreReceiveGetPagedList = data.ListData;
                $scope.total_count = data.TotalRecord;

                angular.forEach(data.ListData, function (aData) {
                    var res1 = aData.StockReceiveDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.StockReceiveDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                        aData.StockReceiveDate = date1;
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

    $scope.OpenReport = function (emp) {
        // $scope.Number = emp.Number;
        $window.open("#/ItemReceiveReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("ItemReciveReport", emp);
        event.stopPropagation();

    }

});