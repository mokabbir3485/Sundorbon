

app.controller("WSAmendController", function ($scope, $filter, $http, $window, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
        console.log(CounterData);
        Clear();

        function Clear() {
            $scope.addBtn = "Add";
            $scope.btnName = "Save";
            $scope.ShowPurchaseDetail = false;
            $scope.currentPage = 1;
            $scope.PerPage = 10;
            $scope.total_count = 0;
            AmendGetPaged($scope.currentPage);
            $scope.AmmendmentData = [];

            $scope.TotalLengthForPurchaseRequestionList = 0;
            $scope.samplePerPageForPurchaseRequestionList = 5;
            $scope.samplecurrentPageForPurchaseRequestionList = 1;

            $scope.TotalLength = 0;
            $scope.samplePerPage = 5;
            $scope.samplecurrentPage = 1;

            $scope.PurchaseRequestionDetailListFilter = [];
            $scope.PurchaseRequestionDetailList = [];
            $scope.PurchaseRequestionListFilter = [];
            $scope.amendment = {};
            $scope.ddlApprovalGivenOn = null;
            // $scope.amendment.AmendDate = new Date();
            ApprovalGivenOnGetAllActive();
        }

        function AmendGetPaged(curPage) {


            if (curPage == null) curPage = 1;
            var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

            var SearchCriteria = "";

            if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
                SearchCriteria = "ReferenceTransactionNumber LIKE '%" + $scope.SearchItem + "%' OR AmendDate LIKE '%" + $scope.SearchItem + "%'";

            }

            //if (curPage == null) curPage = 1;
            //var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

            //var SearchCriteria = "1=1";

            $http({
                url: encodeURI('/ItemAmmendment/AmendmentPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {

                $scope.AmendmentList = data.ListData;
                $scope.total_count = data.TotalRecord;
                angular.forEach($scope.AmendmentList, function (aData) {
                    if (aData.AmendDate != null) {
                        var res1 = aData.AmendDate.substring(0, 5);
                        if (res1 == "/Date") {
                            var parsedDate1 = new Date(parseInt(aData.AmendDate.substr(6)));
                            var date1 = ($filter('date')(parsedDate1, 'MMM dd, yyyy')).toString();
                            aData.AmendDate = date1;
                        }
                    }

                })
            });
        }

        $scope.getData = function (curPage) {

            // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

            if ($scope.PerPage > 100) {
                $scope.PerPage = 100;
                $scope.currentPage = curPage;
                AmendGetPaged($scope.currentPage);
                //  alertify.log('Maximum record  per page is 100', 'error', '5000');
                toastr.error('Maximum record  per page is 100');
            }
            else if ($scope.PerPage < 1) {
                $scope.PerPage = 1;
                $scope.currentPage = curPage;
                AmendGetPaged($scope.currentPage);
                // alertify.log('Minimum record  per page is 1', 'error', '5000');
                toastr.error('Maximum record  per page is 100');
            }
            else {
                $scope.currentPage = curPage;
                AmendGetPaged($scope.currentPage);
            }
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

        $scope.ReloadApprovalGivenOnGet = function () {
            $scope.ApprovalGivenOnList = {};
            $scope.ddlApprovalGivenOn = null;
            ApprovalGivenOnGetAllActive()
        }

        $scope.SearchBtn = function () {
            AmendGetPaged(1);
        }
        $scope.ClearSearchBtn = function () {
            $scope.SearchItem = "";
            AmendGetPaged(1);
        }
        $scope.Search = function () {
            var isValid = true;
            $scope.PurchaseRequestionDetailList = [];
            $scope.PurchaseRequestionDetailListFilter = [];
            if ($scope.ddlApprovalGivenOn == null || $scope.ddlApprovalGivenOn == undefined) {
                toastr.error('Approval Given On can not be null or empty');
                isValid = false;
            }
            else {
                if (isValid) {
                    if ($scope.ddlApprovalGivenOn.ApprovalGivenOn == "Issue") {
                        $scope.ddlApprovalGivenOn.ApprovalGivenOn = "IS";
                    }
                    isValid = true;
                }
            }
            if (isValid) {
                $scope.PurchaseRequestionList = [];
                if ($scope.FromDate == undefined || $scope.FromDate == null || $scope.ToDate == undefined || $scope.ToDate == null) {
                    $scope.FromDate = "default"
                    $scope.ToDate = "default"
                }
                if (isValid) {
                    $http({
                        url: encodeURI('/Ammendment/GetTableName?Status=' + $scope.ddlApprovalGivenOn.ApprovalGivenOn + '&FromDate=' + $scope.FromDate + '&ToDate=' + $scope.ToDate),
                        method: 'GET',
                        headers: { 'Content-Type': 'application/json' }
                    }).success(function (data) {
                        $scope.PurchaseRequestionListFilter = data;
                        $scope.FromDate = undefined;
                        $scope.ToDate = undefined;
                        angular.forEach($scope.PurchaseRequestionListFilter, function (aData) {
                            if (aData.DateData != null) {
                                var res1 = aData.DateData.substring(0, 5);
                                if (res1 == "/Date") {
                                    var parsedDate1 = new Date(parseInt(aData.DateData.substr(6)));
                                    var date1 = ($filter('date')(parsedDate1, 'MMM dd, yyyy')).toString();
                                    aData.DateData = date1;
                                }
                            }

                        })
                        $scope.PurchaseRequestionList = $scope.PurchaseRequestionListFilter;

                        $scope.TotalLengthForPurchaseRequestionList = $scope.PurchaseRequestionListFilter.length;
                        $scope.samplePerPageForPurchaseRequestionList = 5;
                        $scope.samplecurrentPageForPurchaseRequestionList = 1;
                    });
                }
            }
        }
        $scope.GetPurchaserRequestionDetails = function (aPur) {
            $scope.amendment.ReferenceTransactionNumber = aPur.Number;
            $scope.amendment.ApprovalGivenOnId = aPur.ApprovalStatusId;

            if (aPur.RequestedByEmployeeId != undefined) {
                $scope.amendment.AmendmentByEmployeeId = aPur.RequestedByEmployeeId;
            } else {
                $scope.amendment.AmendmentByEmployeeId = aPur.CreatorId;
            }


            $scope.PurchaseRequestionDetailList = [];
            if ($scope.ddlApprovalGivenOn.Id == 12) {
                $http({
                    url: "/PurchaseRequisition/GetByPurchaseRequisitionNumber?Number=" + aPur.Number,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    //$scope.PurchaseRequestionDetailList = data;
                    angular.forEach(data, function (aData) {
                        var itemInfo = {};
                        itemInfo.Id = aData.Id;
                        itemInfo.ItemId = aData.ItemId;
                        itemInfo.PurchaseRequisitionNumber = aData.PurchaseRequisitionNumber;
                        itemInfo.Qty = aData.RequestedQty;
                        itemInfo.Remarks = aData.Remarks;
                        itemInfo.Combination = aData.Combination;
                        itemInfo.UnitPrice = aData.UnitPrice;
                        itemInfo.AmentQty = aData.RequestedQty;
                        $scope.PurchaseRequestionDetailList.push(itemInfo);

                        $scope.PurchaseRequestionDetailListFilter = $scope.PurchaseRequestionDetailList;

                        $scope.TotalLength = $scope.PurchaseRequestionDetailList.length;
                        $scope.samplePerPage = 5;
                        $scope.samplecurrentPage = 1;
                    })
                });
            }
            else if ($scope.ddlApprovalGivenOn.Id == 1) {

                $http({
                    url: "/PurchaseBill/GetByPurchaseBillNumber?Number=" + aPur.Number,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {

                    //$scope.PurchaseRequestionDetailList = data;
                    angular.forEach(data, function (aData) {
                        var itemInfo = {};
                        itemInfo.Id = aData.Id;
                        itemInfo.PuchaseBillNumber = aData.PuchaseBillNumber;
                        itemInfo.Qty = aData.Qty;
                        itemInfo.ItemId = aData.ItemId;
                        itemInfo.Remarks = aData.Remarks;
                        itemInfo.Combination = aData.Combination;
                        itemInfo.UnitPrice = aData.UnitPrice;
                        itemInfo.VAT = aData.VAT;
                        itemInfo.SD = aData.SD;
                        itemInfo.AIT = aData.AIT;
                        itemInfo.AmendVAT = aData.VAT;
                        itemInfo.AmendSD = aData.SD;
                        itemInfo.AmentQty = aData.Qty;
                        itemInfo.AmendUnitPrice = aData.UnitPrice;
                        itemInfo.AmendAIT = aData.AIT;
                        $scope.PurchaseRequestionDetailList.push(itemInfo);
                    })

                });
            }
        }
    }
    $scope.AmmendmentPreview = function () {
        $scope.AmendedPurchaseRequestionDetailList = [];
        angular.forEach($scope.PurchaseRequestionDetailList, function (aData) {
            var item = {};
            var itemInfo = {};
            itemInfo.PuchaseBillNumber = aData.PuchaseBillNumber;
            itemInfo.Qty = aData.Qty;
            itemInfo.ItemId = aData.ItemId;
            itemInfo.Remarks = aData.Remarks;
            itemInfo.Combination = aData.Combination;
            itemInfo.UnitPrice = aData.UnitPrice;
            itemInfo.VAT = aData.VAT;
            itemInfo.SD = aData.SD;
            itemInfo.AIT = aData.AIT;
            if (aData.AmendVAT != null && aData.AmendVAT != undefined && aData.AmendVAT != aData.Vat) {
                itemInfo.Vat = aData.AmendVAT;
                IsAmended = true;
            }
            if (aData.AmendSD != null && aData.AmendSD != undefined && aData.AmendSD != aData.SD) {
                itemInfo.SD = aData.AmendSD;
                IsAmended = true;
                AmenderIDS.Id = aData.Id;
            }
            if (aData.AmentQty != null && aData.AmentQty != undefined && aData.AmentQty != aData.Qty) {
                itemInfo.Qty = aData.AmentQty;
                IsAmended = true;
            }
            if (aData.AmendUnitPrice != null && aData.AmendUnitPrice != undefined && aData.AmendUnitPrice != aData.UnitPrice) {
                itemInfo.AmendedPrice = aData.AmendUnitPrice;
                IsAmended = true;
            }
            if (aData.AmendAIT != null && aData.AmendAIT != undefined && aData.AmendAIT != aData.AIT) {
                itemInfo.AIT = aData.AmendAIT;
                IsAmended = true;
            }
            $scope.AmendedPurchaseRequestionDetailList.push(itemInfo);
        });

        $("#AmendedDataModal").modal('show');
    }
    $scope.closeModal = function () {
        $("#AmendedDataModal").modal('hide');
    }
    $scope.AmmendmentSave = function () {


        $scope.FilterData = [];
        $scope.FilterId = [];
        var Valid1 = true;
        if ($scope.amendment.AmendDate == "" || $scope.amendment.AmendDate == null) {
            toastr.error('Amendment Date  must be  entry');
            var Valid1 = false;
        } else {


            var Valid1 = true
        }
        var IsAmended = false;


        angular.forEach($scope.PurchaseRequestionDetailList, function (aData) {
            var AmenderIDS = {};
            var itemInfo = {};
            itemInfo.PuchaseBillNumber = aData.PuchaseBillNumber;
            itemInfo.AmendedQuantity = aData.Qty;
            itemInfo.ItemId = aData.ItemId;
            itemInfo.Remarks = aData.Remarks;
            itemInfo.Combination = aData.Combination;
            itemInfo.AmendedPrice = aData.UnitPrice;
            itemInfo.Vat = aData.VAT;
            itemInfo.SD = aData.SD;
            itemInfo.AIT = aData.AIT;
            itemInfo.Id = 0;
            itemInfo.DetailId = aData.Id;
            if (aData.AmendVAT != null && aData.AmendVAT != undefined && aData.AmendVAT != aData.Vat) {
                itemInfo.Vat = aData.AmendVAT;
                IsAmended = true;
            }
            if (aData.AmendSD != null && aData.AmendSD != undefined && aData.AmendSD != aData.SD) {
                itemInfo.SD = aData.AmendSD;
                IsAmended = true;
                AmenderIDS.Id = aData.Id;
            }
            if (aData.AmentQty != null && aData.AmentQty != undefined && aData.AmentQty != aData.Qty) {
                itemInfo.AmendedQuantity = aData.AmentQty;
                IsAmended = true;
            }
            if (aData.AmendUnitPrice != null && aData.AmendUnitPrice != undefined && aData.AmendUnitPrice != aData.UnitPrice) {
                itemInfo.AmendedPrice = aData.AmendUnitPrice;
                IsAmended = true;
            }
            if (aData.AmendAIT != null && aData.AmendAIT != undefined && aData.AmendAIT != aData.AIT) {
                itemInfo.AIT = aData.AmendAIT;
                IsAmended = true;
            }
            $scope.FilterData.push(itemInfo);
        });
        if (Valid1) {

            var titleText = "Do you want to save?";
            if ($scope.btnName == "Update") {
                $scope.PurchaseBill.TransactionType = "Update";
                titleText = "Do you want to update?";
            } else {
                $scope.amendment.TransactionType = "INSERT";
                $scope.amendment.Number = CounterData.ShortCode;
            }


            var AmendDate = $scope.amendment.AmendDate.split("/");
            var AmendDate2 = new Date(+AmendDate[2], AmendDate[1] - 1, +AmendDate[0]);
            $scope.amendment.AmendDate = AmendDate2;
            $scope.amendment.AmendmentByEmployeeId = $scope.LoginUser.EmployeeId;
            $scope.amendment.ApprovalGivenOnId = $scope.ddlApprovalGivenOn.Id;


            var parms = JSON.stringify({ _Ammendment: $scope.amendment, _inv_AmmendmentDetails: $scope.FilterData });


            swal.fire({
                title: titleText,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                reverseButtons: true
            }).then((result) => {
                if (result.value == true) {
                    $http.post('/Ammendment/Save', parms).success(function (data) {
                        if ($scope.btnName == "Save") {

                            toastr.success('Amendment  saved successfully.');
                        }
                        else {
                            toastr.success('Amendment successfully.');
                        }
                        Clear();
                        $scope.PurchaseRequestionDetailList = [];
                        $scope.PurchaseRequestionList = [];
                        $scope.amendment.AmendDate = "";
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
    $scope.ClearBtn = function () {
        Clear();
        $scope.amendment.AmendDate = "";
        $scope.PurchaseRequestionDetailList = [];
        $scope.PurchaseRequestionList = [];
        $scope.PurchaseRequestionListFilter = [];
        $scope.amendment.AmendDate = "";
    }
    $scope.ResetItem = function () {
        Clear();
        $scope.amendment.AmendDate = "";
        $scope.PurchaseRequestionDetailList = [];
        $scope.PurchaseRequestionList = [];
        $scope.amendment.AmendDate = "";
    }
    $scope.OpenReport = function (emp) {
        $window.open("#/AmendDetailsReport", "popup", "width=850,height=550,left=280,top=80");
        $cookieStore.put("AmendDetailsReport", emp.Id);
        $cookieStore.put("ApprovalGivenOn", emp.ApprovalGivenOnId);
        event.stopPropagation();

    }
    $scope.GetRequisitionData = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.PurchaseRequestionList = $scope.PurchaseRequestionListFilter;

        const lastIndex = $scope.samplePerPageForPurchaseRequestionList * Cur;
        const firstIndex = lastIndex - $scope.samplePerPageForPurchaseRequestionList;
        var item = $scope.PurchaseRequestionList.slice(firstIndex, lastIndex);
        $scope.PurchaseRequestionList = item;

    }

    $scope.GetSampleDate = function (Cur) {
        $scope.TempCurrentPage = Cur;

        $scope.PurchaseRequestionDetailList = $scope.PurchaseRequestionDetailListFilter;

        const lastIndex = $scope.samplePerPage * Cur;
        const firstIndex = lastIndex - $scope.samplePerPage;
        var item = $scope.PurchaseRequestionDetailList.slice(firstIndex, lastIndex);
        $scope.PurchaseRequestionDetailList = item;

    }
});