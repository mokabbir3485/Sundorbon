app.controller("PaymentRecivedController", function ($scope, $filter) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();
    function Clear() {

        $scope.PaymentReceivedList = [
            { PaymentReceivedId: 1, CustomerNo: 'Cust1', CustomerName: 'Shuvo', PaymentType: 'Mobile Banking', PaymentDate: '20 Apr 2020', PaidAmount: 100 },
            { PaymentReceivedId: 2, CustomerNo: 'Cust2', CustomerName: 'Mokabbir', PaymentType: 'Card', PaymentDate: '20 Apr 2020', PaidAmount: 500 }
        ]

    }


});