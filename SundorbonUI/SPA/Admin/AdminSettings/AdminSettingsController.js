app.controller("AdminSettingsController", function ($scope, $filter) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();
    function Clear() {
        $scope.ddlCurrency = null;
        $scope.Settings = {};
      

        $scope.ddlCharge = null;

    }

    $scope.CurrencyList = [
        { CurrencyId: 1, CurrencyName: "USD" },
        { CurrencyId: 2, CurrencyName: "BTC" },
        { CurrencyId: 3, CurrencyName: "RS" }
    ];

    $scope.SetFillData = function () {
        $scope.ddlCurrency = "USD"
        $scope.ddlCharge = "1";
        $scope.Settings.ChargeAmount = 100;
        $scope.Settings.TaxRate = 10;
        $scope.Settings.Cuttoff = "10 H";
        $scope.Settings.CancelHours = "5 H";
        $scope.Settings.DisallowBooking =true;
        $scope.Settings.AdminEmail ="test@gmail";
    }

    $scope.ResetData = function () {
        $scope.Settings = {};
        $scope.ddlCurrency = null;
        $scope.ddlCharge = "";
        toastr.error('All Data Reset');
      
       
    }
    $scope.Save = function () {
        toastr.success('Admin Settings Saved Successfully.');
    }
});