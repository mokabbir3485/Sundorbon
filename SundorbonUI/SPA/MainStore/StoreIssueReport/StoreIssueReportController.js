
app.controller("StoreIssueReportController", function ($scope, $filter, $http, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));


        var number = $cookieStore.get("IssueReport");
    }
    Clear();

    function Clear() {
        $scope.Name = "Issue Report";
        GetAllReportData();
        $scope.IssueList = [];
    }

    function GetAllReportData() {
        $http({
            url: "/Issue/StoreIssueDetails_Reports?Number=" + number,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.IssueList = data;

            angular.forEach(data, function (aData) {
                var res1 = aData.IssueDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.IssueDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                    aData.IssueDate = date1;
                }
            })
        });
    }
});