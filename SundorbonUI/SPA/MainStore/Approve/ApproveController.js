app.controller("ApproveController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
        console.log(CounterData);
        Clear();

        function Clear() {
            $scope.btnName = "Save";
            $scope.ApprovalGivenOnList = [];
            $scope.ApprovalList = [];
            ApprovalGivenOnGetAllActive();
          
        }



        function ApprovalGivenOnGetAllActive() {
            $http({
                url: "/ApprovalGivenOn/GetAll",
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                $scope.ApprovalGivenOnList = data;
            });
        }

        $scope.ReloadApprovalGivenOnGet = function () {
            $scope.ApprovalGivenOnList = {};
            $scope.ddlApprovalGivenOn = null;
            ApprovalGivenOnGetAllActive();
        }
      

        $scope.ApprovalGivenOnMethod = function () {
            $scope.ApprovalList = [];
            if ($scope.ddlApprovalGivenOn !=null) {
                $http({
                    url: "/Ammendment/AmendmentGetByApprovalGivenOnId?ApprovalGivenOnId=" + $scope.ddlApprovalGivenOn.Id,
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    $scope.ApprovalList = data;

                    angular.forEach($scope.ApprovalList,function (aData) {
                        var res1 = aData.AmendDate.substring(0, 5);
                        if (res1 == "/Date") {
                            var parsedDate1 = new Date(parseInt(aData.AmendDate.substr(6)));
                            var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
                            aData.AmendDate = date1;
                        }
                    })
                });
            }
            
        }
        $scope.AmmendmentSave = function () {
            var NotSelected = true;
            angular.forEach($scope.ApprovalList, function (aData) {
                if (aData.IsCheck == true) {
                    var parms = JSON.stringify({ _Ammendment: aData });
                    swal.fire({
                        title: "Do you want to save?",
                        icon: 'warning',
                        showCancelButton: true,
                        cancelButtonText: 'Cancel',
                        reverseButtons: true
                    }).then((result) => {
                        if (result.value == true) {
                            $http.post('/Ammendment/Update', parms).success(function (data) {
                                toastr.success('Successfully updated.');
                                Clear();
                            }).error(function (data) {
                                toastr.error('Server Errors!');

                            });
                        }
                        else if (result.dismiss == "cancel") {
                            Swal.DismissReason.cancel;
                        }
                    })
                    NotSelected = false;
                }
            });
           
            if (NotSelected) {
                toastr.error('Please select a data');
            }
        }

    }

 });