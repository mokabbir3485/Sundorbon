app.controller("WorkShopJobApprovalController", function ($scope, $filter, $http, $window, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
        console.log(CounterData);
    }
    var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));
    console.log(CounterData);
    Clear();

    function Clear() {
        $scope.TormDate = "";
        $scope.FormDate = "";
        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        //GetAllPendingJob();
        JobGetPaged(1);
        $scope.JobList = {};
        $scope.JobFilter = {};
        //$scope.JobDetails = {};


    }
    function JobGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "ApprovalStatusId=2";

        if ($scope.SearchItem != undefined && $scope.SearchItem != "" && $scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "(JobDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "') and (Number LIKE '%" + $scope.SearchItem + "%') and (ApprovalStatusId=2)";

        }
        else if ($scope.SearchItem !== undefined && $scope.SearchItem != null && $scope.SearchItem != "") {
            SearchCriteria = "Number LIKE '%" + $scope.SearchItem + "%' and (ApprovalStatusId=2)";

        }
        else if ($scope.FormDate != "" && $scope.TormDate != "") {
            SearchCriteria = "JobDate between '" + $scope.FormDate + "' and '" + $scope.TormDate + "' and (ApprovalStatusId=2)";

        }


        $http({
            url: encodeURI('/Job/JobGetPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.JobList = data.ListData;
            $scope.total_count = data.TotalRecord;

            angular.forEach(data.ListData, function (aData) {
                var res1 = aData.JobDate.substring(0, 5);
                var res2 = aData.CreateDate.substring(0, 5);
                var res3 = aData.UpdateDate.substring(0, 5);
                if (res1 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.JobDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.JobDate = date1;
                }
                if (res2 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.CreateDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.CreateDate = date1;
                }
                if (res3 == "/Date") {
                    var parsedDate1 = new Date(parseInt(aData.UpdateDate.substr(6)));
                    var date1 = ($filter('date')(parsedDate1, 'yyyy-MM-dd')).toString();
                    aData.UpdateDate = date1;
                }
            })
        });
    }




   
    $scope.getData = function (curPage) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            JobGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            JobGetPaged($scope.currentPage);
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            JobGetPaged($scope.currentPage);
        }
    }
    $scope.JobUpdate = function () {
        var NotSelected = true;
        angular.forEach($scope.JobList, function (aData) {
            if (aData.IsCheck == true) {
                var parms = JSON.stringify({ _Job: aData });
                swal.fire({
                    title: "Do you want to save?",
                    icon: 'warning',
                    showCancelButton: true,
                    cancelButtonText: 'Cancel',
                    reverseButtons: true
                }).then((result) => {
                    if (result.value == true) {
                        $http.post('/Job/ApprovalUpdate', parms).success(function (data) {
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
    $scope.SearchBtn = function () {
        JobGetPaged(1);
    }
    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        $scope.TormDate = "";
        $scope.TormDate = "";
        $("#FormDate").val("");
        $("#ToDate").val("");
        JobGetPaged(1);
    }
});