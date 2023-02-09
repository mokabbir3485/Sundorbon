app.controller("AdminDashboardController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    var CounterData = sessionStorage.getItem("CounterData");

    Clear();
    function Clear() {
        var x = "";
        if (CounterData == null || CounterData == undefined) {
            GetAllCounter();
        }
        //  $scope.ToDateBooking = new Date();
        $scope.TotalBooking = '100 K';
        $scope.ToDateBooking = $filter('date')(new Date().toJSON().slice(0, 10), 'MMM dd, yyyy');
    }
    $scope.BookingHistory = function () {
        window.location = '/Home/Index#/BookingHistory';
    }

    function GetAllCounter() {
        if ($scope.LoginUser.RoleName=="Manager") {
            $scope.LoginUser.DepartmentId = 1;
        }
        $http({
            url: encodeURI('/Counter/GetAllNoUsedCounter?DeptId=' + $scope.LoginUser.DepartmentId),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.CounterList = data;
        });
        $("#myModal").modal('show');
    }

    $scope.ReloadCounter = function () {
        $scope.CounterList = {};
        $scope.CounterId = null;
        GetAllCounter();
    }

    $scope.SelectCounter = function () {
        var IsValid = true;
        if ($scope.CounterId == null || $scope.CounterId == undefined) {
            toastr.error('Counter can not be null or empty');
            IsValid = false;
        }
        if (IsValid) {
            sessionStorage.setItem("CounterData", JSON.stringify($scope.CounterId));
            
            $http({
                url: encodeURI('/Counter/ChangeUsedStatus?Id=' + $scope.CounterId.Id + '&status=' + true),
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.CounterList = data;
            });
            $("#myModal").modal('hide');
        }
       
    }
    PieGraphDashboardAdmin();

    function PieGraphDashboardAdmin() {
        var ctx = document.getElementById("CountPieChartAdminChargingUnit").getContext('2d');
        if (window.MyChartPieCount != undefined) {
            window.MyChartPieCount.destroy();
        }
        window.MyChartPieCount = new Chart(ctx, {
            type: 'pie',
            data: {
                datasets: [{
                    data: [1000, 2000],
                    backgroundColor: [
                        'rgb(30, 202, 184)',
                        'rgb(87, 102, 218)',
                        //'#f39c12',
                        //'#d9534f',
                        //'#d966ff',
                    ],
                }],
                labels: ['This Month Payment','This Month Due Payment'],

            },
            options: {
                title: {
                    display: true,
                   // text: 'Total Payment',
                    position: 'left'
                }

            }

        });
    }

});