app.controller("Inv_PR_Amend_Report", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.ReportType = "Test Report";
    Clear();

    function Clear() {
        $scope.NumberToDisplay = 'ALL'
        $scope.FromDateToDisplay = "ALL";
        $scope.ToDateToDisplay = "ALL";
        $scope.ddlAmmendMend = null;
        GetAllItem();
        GetAllAmmendMend();
    }

    function GetAllAmmendMend() {
        $http({
            url: "/PurchaseRequisition/GetAllNumber",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.AmmendMendList = data;
        });
    }


    function GetAllItem() {
        var Number = "";
        var FromDate = "Not Defined"
        var ToDate = "Not Defined"
        if ($scope.ddlAmmendMend != null || $scope.ddlAmmendMend != undefined) {
            Number = $scope.ddlAmmendMend.Number;
            $scope.NumberToDisplay = Number;
        }
        else if ($scope.FormDate != null && $scope.FormDate != undefined && $scope.FormDate != "" && $scope.TormDate != "" && $scope.TormDate != null && $scope.TormDate != undefined) {
            FromDate = $scope.FormDate;
            ToDate = $scope.TormDate;
            $scope.FromDateToDisplay = FromDate;
            $scope.ToDateToDisplay = ToDate;
        }

        $http({
            url: encodeURI('/PurchaseRequisition/GetAllAmendAndRequisition?Number=' + Number + '&FromDate=' + FromDate + '&ToDate=' + ToDate),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ReportList = data;
            var currentdate = new Date();
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
                var reportName = "ItemReport_"
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
    $scope.SearchBtn = function () {
        GetAllItem();
    }
    $scope.ClearBtn = function () {
        $scope.FormDate = "";
        $scope.TormDate = "";
        $scope.SearchItem = "";
        $("#FormDate").val("");
        $("#ToDate").val("");
        Clear();
    }

})