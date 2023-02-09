
app.controller("ItemReceiveReportController", function ($scope, $filter, $http, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));


        var number = $cookieStore.get("ItemReciveReport");
    }
    Clear();

    function Clear() {
        $scope.Name = "Item Receive Report";
        GetAllReportData();
        $scope.ReceiveDetailList = [];
    }

    function GetAllReportData() {
        $http({
            url: "/StoreItemRecive/StoreReciveDetails_GetBy_Number?Number=" + number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ReceiveDetailList = data;

            angular.forEach(data, function (aData) {
                var res1 = aData.StockReceiveDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.StockReceiveDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.StockReceiveDate = date1;
                }
            })
        });
    }
});