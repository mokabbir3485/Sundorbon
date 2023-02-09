app.controller("UserManageController", function ($scope, $filter) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();
    function Clear() {
        


        $scope.RoleList = [{ RoleId: 1, RoleName: 'Admin' }, { RoleId: 2, RoleName: 'User' }, { RoleId: 3, RoleName: 'Care' }]

        


        $scope.UserList = [
            { UserId: 1, RoleName: 'Admin', FirstName: 'Shuvo', LastName: 'Ahamed', EmailAddress: 'shuvo123@gmail.com', Username: 'Shuvo123', Password: 'Shuvo123' },
            { UserId: 2, RoleName: 'User', FirstName: 'Abir', LastName: 'Hossain', EmailAddress: 'abir69@gmail.com', Username: 'abir69', Password: 'abir69' },
            { UserId: 3, RoleName: 'Care', FirstName: 'Mokabbir', LastName: 'Hossain', EmailAddress: 'mokabbir3485@gmail.com', Username: 'Mokabbir788', Password: 'Mokabbir788' }
        ]

    }

    $scope.FillData = function () {
        $scope.User = {};
        $scope.User.FirstName = 'Shuvo';
        $scope.User.LastName = 'Ahamed';
        $scope.User.EmailAddress = 'shuvo123@gmail.com';
        $scope.User.Username = 'Shuvo123';
        $scope.User.Password = 'Shuvo123';
        $scope.User.ConfirmPassword = 'Shuvo123';
        $scope.ddlRole = { RoleId: 2 };
    }
    $scope.Save = function () {
        toastr.success('User Manage Saved Successfully.');
    }
    $scope.Reset = function () {
        $scope.User = {};
        toastr.error('All Data Reset');
    }
});