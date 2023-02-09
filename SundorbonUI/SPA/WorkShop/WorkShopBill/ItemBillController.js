app.controller("ItemBillController", function ($scope, $filter, $http, $window, $cookieStore) {
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
            ItemBillGetPaged($scope.currentPage);

            $scope.addBtn = "Add";
            $scope.btnName = "Save";

            $scope.ItemBill = {};

            $scope.ItemBillDetailList = [];

            $scope.PurchaseRequestionList = [];
            $scope.PurchaseStatusList = [];
            $scope.SupplierList = [];
            $scope.ItemBillGetPagedList = [];
            $scope.ItemBillFilterList = [];

            GetAllPurchase();
            RequestionStatus();
            GetAllSupplier();
        }

        $scope.GetPurchaseRequestionDetail = function (NumberObj) {
            $scope.ItemBill.PurchaseRequisitionNumber = NumberObj.Number;
            $scope.ItemBillDetailList = [];

            $http({
                url: "/PurchaseRequisition/GetByPurchaseRequisitionNumber?Number=" + NumberObj.Number,
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                angular.forEach(data, function (aData) {
                    var itemInfo = {};
                    itemInfo.Qty = aData.RequestedQty;
                    itemInfo.ItemId = aData.ItemId;
                    itemInfo.Remarks = aData.Remarks;
                    itemInfo.Combination = aData.Combination;
                    itemInfo.UnitPrice = 0;
                    itemInfo.AIT = 0;
                    itemInfo.VAT = 0;
                    itemInfo.SD = 0;
                    itemInfo.Discount = 0;
                    itemInfo.Amount = 0;
                    itemInfo.AfterDiscount = 0;
                    itemInfo.TotalAmount = 0;

                    $scope.ItemBillDetailList.push(itemInfo);
                })


            });


        }





        function GetAllPurchase() {
            $http({
                url: "/PurchaseRequisition/GetAllPurchaseRequestion",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.PurchaseRequestionList = data;
                $scope.ItemBillFilterList = data;
                angular.forEach(data, function (aData) {

                    var res1 = aData.RequisitionDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.RequisitionDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                        aData.RequisitionDate = date1;
                    }


                })

                $scope.TotalLength = $scope.PurchaseRequestionList.length;
                $scope.samplePerPage = 5;
                $scope.samplecurrentPage = 1;
            });


        }

        $scope.ClearSearch = function () {
            $scope.SearchPBFilter = "";
            GetAllPurchase();
        }
        $scope.CheckFilter = function () {
            ItemBillGetPaged();
        }
        function ItemBillGetPaged() {

            $scope.TotalLength = $scope.PurchaseRequestionList.length;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;
        }

        $scope.GetSampleDate = function (Cur) {
            $scope.TempCurrentPage = Cur;

            $scope.PurchaseRequestionList = $scope.ItemBillFilterList;

            const lastIndex = $scope.samplePerPage * Cur;
            const firstIndex = lastIndex - $scope.samplePerPage;
            var item = $scope.PurchaseRequestionList.slice(firstIndex, lastIndex);
            $scope.PurchaseRequestionList = item;

        }

        function GetAllSupplier() {
            $http({
                url: "/Supplier/GetAllSupplier",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.SupplierList = data;
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

        function RequestionStatus() {
            $http({
                url: "/ApprovalStatus/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.PurchaseStatusList = data;


                $scope.ddlApprovalStatus = { Id: 13 };
            });

            PuchaseRequisitionDetailsGetAllActive();

        }
        function PuchaseRequisitionDetailsGetAllActive() {
            $http({
                url: "/PurchaseRequisition/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.PurchaseRequisitionDetailsList = data;






            });
        }
        //$scope.GetPurchaseRequestionDetail = function () {



        //============ SAVE  ===========>>>>>>

        $scope.ItemBillSave = function () {

            var isValid = true;
            var isValid1 = true;
            var isValid2 = true;
            var isValid3 = true;
            var isValid4 = true;
            var isValid5 = true;

            if ($scope.ItemBill.BillDate == undefined || $scope.ItemBill.BillDate == "") {
                toastr.error('Bill Date can not be null or empty');
                isValid = false;
            } else {
                isValid = true;
            }

            if ($scope.ItemBill.PurchaseRequisitionNumber == undefined || $scope.ItemBill.PurchaseRequisitionNumber == "") {
                toastr.error('Purchase Requisition Number can not be null or empty');
                isValid1 = false;
            } else {
                isValid1 = true;
            }

            if ($scope.ItemBill.ManualBillNo == undefined || $scope.ItemBill.ManualBillNo == "") {
                toastr.error('Manual Bill No can not be null or empty');
                isValid2 = false;
            } else {
                isValid2 = true;
            }

            if ($scope.ddlSupplierId == null || $scope.ddlSupplierId == undefined) {
                toastr.error('Supplier Name No can not be null or empty');
                isValid3 = false;
            } else {
                isValid3 = true;
            }

            if ($scope.ddlApprovalStatus == null || $scope.ddlApprovalStatus == undefined) {
                toastr.error('Approval Status can not be null or empty');
                isValid4 = false;
            } else {
                isValid4 = true;
            }

            if ($scope.ItemBillDetailList == 0) {
                toastr.error('Item Info  must be  entry');
                isValid5 = false;
            } else {
                isValid5 = true;
            }


            if (isValid && isValid1 && isValid2 && isValid3 && isValid4 && isValid5) {

                $scope.ItemBill.ApprovalStatusId = $scope.ddlApprovalStatus.Id;
                $scope.ItemBill.CounterId = CounterData.Id;
                $scope.ItemBill.SupplierId = $scope.ddlSupplierId.Id;
                $scope.ItemBill.CreatorId = $scope.LoginUser.UserId;
                $scope.ItemBill.UpdatorId = $scope.LoginUser.UserId;

                var titleText = "Do you want to save?";
                if ($scope.btnName == "Update") {
                    $scope.ItemBill.TransactionType = "Update";
                    titleText = "Do you want to update?";
                } else {
                    $scope.ItemBill.TransactionType = "INSERT";
                    $scope.ItemBill.Number = CounterData.ShortCode;
                }
                var parms = JSON.stringify({ _ItemBill: $scope.ItemBill, _p_ItemBillDetails: $scope.ItemBillDetailList });

                var isFlag = true;

                angular.forEach($scope.ItemBillDetailList, function (aData) {

                    if (aData.Qty == 0 || aData.Qty == undefined) {
                        isFlag = false;
                    }
                    if (aData.UnitPrice == 0 || aData.UnitPrice == undefined) {
                        isFlag = false;
                    }
                })
                if (isFlag) {

                    swal.fire({
                        title: titleText,
                        icon: 'warning',
                        showCancelButton: true,
                        cancelButtonText: 'Cancel',
                        reverseButtons: true
                    }).then((result) => {
                        if (result.value == true) {
                            $http.post('/ItemBill/Save', parms).success(function (data) {
                                if ($scope.btnName == "Save") {

                                    toastr.success('Purchase bill saved successfully.');
                                }
                                else {
                                    toastr.success('Purchase bill successfully.');
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
                }
                else {
                    toastr.error('Item quantity and  unit price must be entry!');
                }

            }
        }

        $scope.UpdatePurchaserBill = function (aPb) {
            $scope.ItemBillDetailList = [];
            $scope.btnName = "Update"
            $scope.ddlApprovalStatus = { Id: aPb.ApprovalStatusId };
            $scope.ItemBill.CounterId = aPb.CounterId;
            $scope.ddlSupplierId = { Id: aPb.SupplierId };
            $scope.ItemBill = aPb;
            $scope.TotalPrice = 0;
            $http({
                url: "/ItemBill/GetByItemBillNumber?Number=" + aPb.Number,
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {


                angular.forEach(data, function (aData) {
                    aData.TotalAmount = aData.AfterDiscount + aData.SD + aData.VAT + aData.AIT;
                    $scope.TotalPrice += aData.AfterDiscount + aData.SD + aData.VAT + aData.AIT;
                    $scope.ItemBillDetailList.push(aData);
                })
            });

        }

        $scope.AmountCalculation = function (aPB) {
            var Total = 0;
            aPB.Amount = aPB.Qty * aPB.UnitPrice;
            aPB.AfterDiscount = aPB.Amount - aPB.Discount;
            aPB.TotalAmount = aPB.AfterDiscount + aPB.SD + aPB.VAT + aPB.AIT;

            Total = aPB.TotalAmount;


            //angular.forEach($scope.ItemBillDetailList, function (aData) {
            //    if (aData.ItemId == aPB.ItemId) {
            //        $scope.TotalPrice += Total;
            //    }
            //})
        }



        //============ Reset  ===========>>>>>>

        $scope.ResetItem = function () {
            Clear();
        }

        function ItemBillGetPaged(curPage) {

            if (curPage == null) curPage = 1;
            var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

            //var SearchCriteria = "";


            //if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            //    SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%' OR BillDate LIKE '%" + $scope.SearchItem + "%'";

            //}

            var SearchCriteria = "";

            if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" && $scope.TormDate != "") {
                SearchCriteria = "(BillDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (Number LIKE '%" + $scope.SearchItem + "%')";

            }
            else if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
                SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%'";

            }
            else if ($scope.FormDate != "" && $scope.TormDate != "") {
                SearchCriteria = "BillDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "'";

            }



            $http({
                url: encodeURI('/ItemBill/ItemBillGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {

                $scope.ItemBillGetPagedList = data.ListData;
                $scope.total_count = data.TotalRecord;

                angular.forEach(data.ListData, function (aData) {
                    var res1 = aData.BillDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.BillDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                        aData.BillDate = date1;
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
            ItemBillGetPaged(1);
        }

        $scope.ClearBtn = function () {
            $scope.SearchItem = "";
            $scope.SearchItem = "";
            $scope.TormDate = "";
            $scope.TormDate = "";
            $("#FormDate").val("");
            $("#ToDate").val("");
            ItemBillGetPaged(1);
        }

        $scope.getData = function (curPage) {

            // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

            if ($scope.PerPage > 100) {
                $scope.PerPage = 100;
                $scope.currentPage = curPage;
                ItemBillGetPaged($scope.currentPage);
                //  alertify.log('Maximum record  per page is 100', 'error', '5000');
                toastr.error('Maximum record  per page is 100');
            }
            else if ($scope.PerPage < 1) {
                $scope.PerPage = 1;
                $scope.currentPage = curPage;
                ItemBillGetPaged($scope.currentPage);
                // alertify.log('Minimum record  per page is 1', 'error', '5000');
                toastr.error('Maximum record  per page is 100');
            }
            else {
                $scope.currentPage = curPage;
                ItemBillGetPaged($scope.currentPage);
            }
        }


    }

    $scope.OpenReport = function (emp) {
        // $scope.Number = emp.Number;
        $window.open("#/ItemBillReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("ItemBillReportNumber", emp);
        event.stopPropagation();

    }

});