
app.controller("WSRequestionReportController", function ($scope, $filter, $http, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
       
     
        var number = $cookieStore.get("WSRequestionReport");
    }
     Clear();

    function Clear() {
        $scope.Name = "Work shop Requisition Report";
        GetAllReportData();
        $scope.WsRequestionDetailList = [];
    }

    function GetAllReportData() {
         $http({
             url: "/WorkShopRequestion/GetByPurchaseRequisitionReport?Number=" + number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.WsRequestionDetailList = data;

            angular.forEach(data, function (aData) {
                var res1 = aData.RequistionDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.RequistionDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.RequistionDate = date1;
                }
            })
        });
    }
});