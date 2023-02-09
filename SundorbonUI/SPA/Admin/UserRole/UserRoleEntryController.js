app.controller("UserRoleEntryController", function ($scope, $filter) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();
    function Clear() {
        
        $scope.Role = {};
        $scope.RoleList = [
            { RoleId: 1, UserRole: 'User' },
            { RoleId: 2, UserRole: 'Care' }
        ]
    }

    $scope.FillData = function () {
     
        $scope.Role.UserRole = 'Admin';
    }
    $scope.Save = function () {
        toastr.success('User Role Saved Successfully.');
    }

    $scope.RoleReset = function () {
     
        toastr.error('All Data Reset');
        $scope.Role = {};
    }
});