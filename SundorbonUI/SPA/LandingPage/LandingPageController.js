app.controller("LandingPageController", function ($scope) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    window.onpopstate = function (e) { window.history.forward(1); }
    $scope.Log = function () {
        window.location = '/Home/Login#/Login';
    }

    $scope.Register = function () {
        window.location = '/Home/Registration#/Register';
    }
    //$(document).click(function (evt) {
    //    //$('.skiptranslate span').css("display", "none");
    //    $('.skiptranslate span').remove();
    //});
    ////$('.skiptranslate span').css("display", "none");
    //$('.skiptranslate span').remove();
});