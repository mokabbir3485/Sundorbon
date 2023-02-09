
app.controller("PurchaseBillReportController", function ($scope, $filter, $http, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));


        var number = $cookieStore.get("PurchaseBillReportNumber");
    }
    Clear();

    function Clear() {
        $scope.Name = "Purchase Bill Report";
        GetAllReportData();
        $scope.PurchaseBillDetailList = [];
    }

    function GetAllReportData() {
        $http({
            url: "/PurchaseBill/p_PurchaseBillDetails_GetBy_Report?Number=" + number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.PurchaseBillDetailList = data;

            angular.forEach(data, function (aData) {

                var res1 = aData.BillDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.BillDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.BillDate = date1;
                }


            })
        });
    }
});