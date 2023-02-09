
app.controller("AmendDetailsReportController", function ($scope, $filter, $http, $cookieStore) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
        console.log($scope.LoginUser);
        var CounterData = JSON.parse(sessionStorage.getItem("CounterData"));


        var Id = $cookieStore.get("AmendDetailsReport");
        $scope.ApprovalGivenOn = $cookieStore.get("ApprovalGivenOn");
    }
    Clear();

    function Clear() {
        $scope.Name = "Purchase Requisition Report";
        GetAllReportData();
        $scope.PurchaseRequestionDetailList = [];
    }

    function GetAllReportData() {
        var a = $scope.ApprovalGivenOn;
        $http({
            url: "/Ammendment/GetByAmendIdReport?Id=" + Id,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.AmendmentDetailList = data;
            angular.forEach($scope.AmendmentDetailList, function (aData) {
                if (aData.AmendDate != null) {
                    var res1 = aData.AmendDate.substring(0, 5);
                    if (res1 == "/Date") {
                        var parsedDate1 = new Date(parseInt(aData.AmendDate.substr(6)));
                        var date1 = ($filter('date')(parsedDate1, 'MMM dd, yyyy')).toString();
                        aData.AmendDate = date1;
                    }
                }

            })
            $scope.Date = currentdate.getDate() + "/" + currentdate.getMonth() + "/" + currentdate.getFullYear();
            Get12HFormat();
        });
    }
    function Get12HFormat() {
        var currentdate = new Date();
        if (currentdate.getHours() > 12) {
            $scope.time = currentdate.getHours() - 12 + ":" + currentdate.getMinutes() + ":" + currentdate.getSeconds() + "PM";

        }
        else {
            $scope.time = currentdate.getHours() + ":" + currentdate.getMinutes() + ":" + currentdate.getSeconds() + "AM";
        }
    }
    $scope.Export = function () {
        var divReport = document.getElementById("Item_report");
        html2canvas(divReport, {
            onrendered: function (canvas) {
                //var data = canvas.toDataURL();
                var reportName = "AmendmentDetails_"
                reportName += $scope.time + "_" + $scope.Date + ".pdf";
                //reportName += $scope.meeting_ref + ".pdf";
                const imgObj = {
                    image: canvas.toDataURL(),
                    width: 560,
                    style: {
                        alignment: "center"
                    }
                };
                const documentDefinition = {
                    content: [imgObj],
                    defaultStyle: {
                        font: "NimbusSans"
                    },
                    pageSize: "A4",
                    pageOrientation: "portrait",
                    pageMargins: [20, 20, 20, 20]
                };

                pdfMake.createPdf(documentDefinition).download(reportName);
            }
        });
    }
});