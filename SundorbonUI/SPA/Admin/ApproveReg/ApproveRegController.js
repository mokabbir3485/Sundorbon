app.controller("ApproveRegController", function ($scope) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.ApproveList = [
        { id: 1, Name: 'Abir', Address: 'Gulshan 1', Email: 'abir@gmail.com', Status: true },
        { id: 2, Name: 'Shuvo', Address: 'Gulshan 2', Email: 'shuvo@gmail.com', Status: false },
        { id: 3, Name: 'Bellal', Address: 'Mirpur 1', Email: 'bellal@gmail.com', Status: true },
    ]

});