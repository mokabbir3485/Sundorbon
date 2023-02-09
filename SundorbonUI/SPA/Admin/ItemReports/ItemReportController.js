app.controller("ItemReportController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }
    $scope.ReportType = "Test Report";
    Clear();
   
    function Clear() {
        $scope.GroupNameToDisplay = 'All'
        $scope.ModelNameToDisplay = 'All'
        GetAllModel();
        GetAllItem();
        GetAllItemGroup();
    }
   
    function GetAllModel() {
        $http({
            url: "/Model/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.ModelList = data;


        });
    }
    function GetAllItemGroup() {
        
       
        $http({
            url: "/ItemGroup/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ItemGroupList = data;
        });
        //$http({
        //    url: encodeURI('/Model/ModelPaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
        //    method: 'GET',
        //    headers: { 'Content-Type': 'application/json' }
        //}).success(function (data) {

        //    $scope.ModelList = data.ListData;
        //    $scope.total_count = data.TotalRecord;

        //});
    }
    function GetAllItem() {
        var GroupName = null;
        var ModelId = null;
        if ($scope.ddlModel != null || $scope.ddlModel != undefined) {
            ModelId = $scope.ddlModel.Id;
            $scope.ModelNameToDisplay = $scope.ddlModel.Name;
        }
        if ($scope.ddlGroup != null || $scope.ddlGroup != undefined) {
            GroupName = $scope.ddlGroup.GroupName;
            $scope.GroupNameToDisplay = $scope.ddlGroup.GroupName;

        }

        $http({
            url: encodeURI('/ItemReports/GetAllItem?ModelId=' + ModelId + '&GroupName=' + GroupName),
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
            $scope.time=currentdate.getHours() + ":" + currentdate.getMinutes() + ":" + currentdate.getSeconds()+"AM";
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
        Clear();
    }
    $scope.ClearBtn = function () {
        $scope.ddlModel = null;
        $scope.ddlGroup = null;
        Clear();
    }

})