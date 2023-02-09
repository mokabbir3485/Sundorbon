
app.controller("PurchaseRequestionReportController", function ($scope, $filter, $http, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
       
     
        var number = $cookieStore.get("RequestionReport");
    }
     Clear();

    function Clear() {
        $scope.Name = "Purchase Requisition Report";
        GetAllReportData();
        $scope.PurchaseRequestionDetailList = [];
    }

    function GetAllReportData() {
         $http({
             url: "/PurchaseRequisition/GetByPurchaseRequisitionReport?Number=" + number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.PurchaseRequestionDetailList = data;

            angular.forEach(data, function (aData) {
                var res1 = aData.RequisitionDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.RequisitionDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.RequisitionDate = date1;
                }
            })
        });
    }
});