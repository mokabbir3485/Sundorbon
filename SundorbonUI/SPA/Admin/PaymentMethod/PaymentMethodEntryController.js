app.controller("PaymentMethodEntryController", function ($scope, $filter) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();
    function Clear() {

       

        $scope.PaymentMethodList = [
            { PaymentMethodId: 1, PaymentMethodName: 'Mobile Banking' },
            { PaymentMethodId: 2, PaymentMethodName: 'Card' }
        ]


    }
    $scope.FillData = function () {
        $scope.PaymentMethod = {};
        $scope.PaymentMethod.PaymentMethodName = 'Card';
    }

    $scope.Save = function () {
        toastr.success('Payment Method Saved Successfully.');
    }

    $scope.ResetData = function () {
        $scope.PaymentMethod = {};
        toastr.error('All Data Reset');


    }
});