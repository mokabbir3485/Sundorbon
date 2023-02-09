app.controller("EmployeeController", function ($scope, $filter, $http) {
    var UserData = sessionStorage.getItem("UserDataSession");
    if (UserData != null) {
        $scope.LoginUser = JSON.parse(sessionStorage.UserDataSession);
    }

    Clear();


    function Clear() {
        $scope.Name = "Employee Entry";
        $scope.Employeeload = true;
        $scope.Userload = false;
        $scope.EmployeeActive = "active";

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;
        EmployeeGetPaged($scope.currentPage);
        $scope.ddlDepartment = null;

        $scope.Employee = {};
        $scope.User = {};
        $scope.btnName = "Save";

        //List===========>>>
        $scope.SectionList = [];
        $scope.DesignationList = [];
        $scope.EmployeeList = [];
        $scope.Rolelist = [];
        $scope.DepartmentList = [];
        ///Method Call ===>>>

        GetAllContractType();
        GetGradeDynamic();
        GetAllDesignation();
        GetAllSection();
        GetAllRole();
        GetAllDepartment();

    }

    /// Tab Btn ====>>>

    $scope.OnLoadPanel = function () {
        $scope.Employeeload = true;
        $scope.Userload = false;
        $scope.UserActive = "";
        $scope.EmployeeActive = "";
    }

    $scope.OnLoadUsertPanel = function () {
        $scope.EmployeeActive = "";
        $scope.Userload = true;
        $scope.Employeeload = false;
        $scope.UserActive = "active";
        $(".userClass").removeClass("active");
    }


    function GetAllDepartment() {
        $http({
            url: "/Department/GetAll",
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.DepartmentList = data;


        });
    }

    function GetAllContractType() {
        //$http({
        //    url: '/Employee/GetAllContractType',
        //    method: 'get',
        //    headers: { 'Content-Type': 'application/json' }

        //}).success(function (data) {
        //    $scope.GetAllContractTypeList = data;
        //})
        $scope.GetAllContractTypeList = [
            { ContractTypeId: 1, ContractTypeName: "Probation Full-Time" },
            { ContractTypeId: 2, ContractTypeName: "Permanant Full-Time" },
            { ContractTypeId: 3, ContractTypeName: "Permanant Part-Time" }
        ];
    }

    function GetGradeDynamic() {
        //$http({
        //    url: '/Employee/GetGradeDynamic?where=IsActive=1&orderBy=GradeName',
        //    method: 'GET',
        //    headers: { 'Content-Type': 'application/json' }
        //}).success(function (data) {
        //    $scope.GradeList = data;
        //});
        $scope.GradeList = [
            { GradeId: 1, GradeName: "Staff" },
            { GradeId: 2, GradeName: "Labour" },
            { GradeId: 3, GradeName: "Cleaner" },

        ];

    }

    function GetAllDesignation() {
        $http({
            url: '/Designation/GetAllDesignation',
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.DesignationList = data;
        });
    }

    function GetAllSection() {
        $http({
            url: '/Designation/GetAllSection',
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.SectionList = data;
        });
    }

    function GetAllRole() {
        $http({
            url: '/Role/GetAllRole',
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.Rolelist = data;
        });
    }

    //  
    // Reload Section

    $scope.ReloadRole = function () {
        $scope.Rolelist = [];
        $scope.ddlRole = null;
        GetAllRole();
    }
    $scope.ReloadContractType = function () {
        $scope.GetAllContractTypeList = {};
        $scope.ddlContractType = null;
        GetAllContractType();
    }
    $scope.ReloadGradeDynamic = function () {
        $scope.ddlGrade = null;
        $scope.GradeList = {};
        GetGradeDynamic();
    }
    $scope.ReloadDesignation = function () {
        $scope.DesignationList = [];
        $scope.ddlDesignation = null;
        GetAllDesignation();
    }
    $scope.ReloadSection = function () {
        $scope.SectionList = [];
        $scope.ddlSection = null;
        GetAllSection();
    }
    $scope.ReloadDepartment = function () {
        $scope.DepartmentList = [];
        $scope.ddlDepartment = null;
        GetAllDepartment();
    }


    //End Reload Section

    $scope.ConfrimPasswordCheck = function () {
        var PasswordText = "";
        var Passwordval = $scope.User.ConfrimPassword;

        if ($scope.User.Password.length <= Passwordval.length) {
            // if (Passwordval == $scope.User.Password) {
            PasswordText = Passwordval;
            // }
        }

        if (PasswordText != '') {
            if ($scope.User.Password != PasswordText) {
                toastr.error('Password dosen`t  match');
            }

        }
    }

    $scope.SaveEmployee = function () {
        var pattern = "^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";


        var isValid1 = false;
        var isValid2 = false;
        var isValid3 = false;
        var isValid4 = false;
        var isValid5 = false;
        var isValid7 = false;
        var isValid8 = false;
        var isValid9 = false;
        var isValid10 = false;
        var isValid11 = false;
        var isValid12 = false;
        var isValid13 = false;

        var DateTimeValid = false;
        var FinishDateTimeValid = false;
        var DateOfBirth = false;


        if ($scope.Employee.EmployeeCode == '' || $scope.Employee.EmployeeCode == undefined) {
            toastr.error('Employee code can`t  not be empty');
            isValid1 = false;
        } else {
            isValid1 = true;
        }
        if ($scope.Employee.BasicSalary == undefined || $scope.Employee.BasicSalary == 0) {
            toastr.error('Salary can`t  be zero amount');
            isValid2 = false;
        } else {
            isValid2 = true;
        }



        if ($scope.Employee.JoiningDate == '' || $scope.Employee.JoiningDate == undefined) {
            toastr.error('Joining Date can`t  be empty');
            DateTimeValid = false;
        } else {
            DateTimeValid = true;
        }


        if ($scope.ddlDesignation == null || $scope.ddlDesignation == undefined) {
            toastr.error('Designation can`t   be empty');
            isValid3 = false;
        } else {
            isValid3 = true;
        }

        if ($scope.ddlContractType == null || $scope.ddlContractType == undefined) {
            toastr.error('Contract Type can`t  not be empty');
            isValid4 = false;
        } else {
            isValid4 = true;
        }

        if ($scope.ddlGrade == null || $scope.ddlGrade == undefined) {
            toastr.error('Grade can`t  be empty');
            isValid5 = false;
        } else {
            isValid5 = true;
        }
        if ($scope.Employee.Gender == "" || $scope.Employee.Gender == undefined) {
            toastr.error('Gender can`t  be empty');
            isValid7 = false;
        } else {
            isValid7 = true;
        }


        if ($scope.Employee.PresentAddress == '' || $scope.Employee.PresentAddress == undefined) {
            toastr.error('Present Address can`t  be empty');
            isValid8 = false;
        } else {
            isValid8 = true;
        }

        if ($scope.Employee.Email == '' || $scope.Employee.Email == undefined) {
            toastr.error('Email Format not Correct');
            isValid9 = false;
        } else {
            isValid9 = true;
        }

        if ($scope.Employee.ContactNo == '' || $scope.Employee.ContactNo == undefined) {
            toastr.error('Contact no can`t  be empty');
            isValid10 = false;
        } else {
            isValid10 = true;
        }

        if ($scope.Employee.DateOfBirth == '' || $scope.Employee.DateOfBirth == undefined) {
            toastr.error('Date Of Birth can`t  be empty');
            DateOfBirth = false;
        } else {
            DateOfBirth = true;
        }

        if ($scope.Employee.BloodGroup == '' || $scope.Employee.BloodGroup == undefined) {
            toastr.error('Blood Group can`t  be empty');
            DateTimeValid = false;
        } else {
            DateTimeValid = true;
        }

        if ($scope.Employee.MiddleName == '' || $scope.Employee.MiddleName == undefined) {
            toastr.error('Middle Name can`t  be empty');
            isValid11 = false;
        } else {
            isValid11 = true;
        }

        if ($scope.Employee.FinishDate == '' || $scope.Employee.FinishDate == undefined) {
            toastr.error('Finish Date Date can`t  be empty');
            FinishDateTimeValid = false;
        } else {
            FinishDateTimeValid = true;
        }

        if ($scope.Employee.FirstName == '' || $scope.Employee.FirstName == undefined) {
            toastr.error('First Namee can`t  be empty');
            isValid12 = false;
        } else {
            isValid12 = true;
        }
        if ($scope.Employee.Title == '' || $scope.Employee.Title == undefined) {
            toastr.error('Title can`t  be empty');
            isValid13 = false;
        } else {
            isValid13 = true;
        }

        if (DateTimeValid && FinishDateTimeValid && isValid1 && isValid2 && isValid3 && isValid4 && isValid5 && isValid7 && isValid8 && isValid9 && isValid10 && isValid11 && isValid12 && isValid13 && DateOfBirth) {
            EmployeeSave()
        }


    }

    function EmployeeSave() {

        $scope.Employee.SectionId = $scope.ddlSection.Id;
        $scope.Employee.DesignationId = $scope.ddlDesignation.DesignationId;
        $scope.Employee.ContractTypeId = $scope.ddlContractType.ContractTypeId;
        $scope.Employee.GradeId = $scope.ddlGrade.GradeId;
        $scope.Employee.ManagerId = 0;

        $scope.Employee.UpdatorId = $scope.LoginUser.UserId;
        $scope.Employee.CreatorId = $scope.LoginUser.UserId;

        var joinDate = $("#dateOfBirth").val();
        var joinDate1 = joinDate.split("/");
        var date = new Date(+joinDate1[2], joinDate1[1] - 1, +joinDate1[0]);
        var dateOfBirth = $("#joiningDate").val();
        var dateOfBirth1 = dateOfBirth.split("/");
        var dateOfBirth2 = new Date(+dateOfBirth1[2], dateOfBirth1[1] - 1, +dateOfBirth1[0]);
        var FinishDate = $("#finisheDate").val();
        var FinishDate1 = FinishDate.split("/");
        var FinishDate2 = new Date(+FinishDate1[2], FinishDate1[1] - 1, +FinishDate1[0]);

        var titleText = "Do you want to save?";
        if ($scope.btnName == "Update") {
            titleText = "Do you want to update?";
        }
        swal.fire({
            title: titleText,
            icon: 'warning',
            showCancelButton: true,
            cancelButtonText: 'Cancel',
            reverseButtons: true
        }).then((result) => {
            if (result.value == true) {
                $scope.Employee.JoiningDate = date;
                $scope.Employee.DateOfBirth = dateOfBirth2;
                $scope.Employee.FinishDate = FinishDate2;

                ///User data===>>>
                $scope.User.IsActive = $scope.Employee.IsUser;
                $scope.User.UpdatorId = $scope.LoginUser.UserId;
                $scope.User.CreatorId = $scope.LoginUser.UserId;
                if ($scope.ddlRole == null || $scope.ddlRole == undefined) {
                    $scope.User.RoleId = 0;
                    $scope.User = null;
                } else {
                    $scope.User.RoleId = $scope.ddlRole.RoleId;

                }



                var parms = JSON.stringify({ _ad_Employee: $scope.Employee, user: $scope.User });


                $http.post('/Employee/Save', parms).success(function (data) {
                    //  $scope.EmployeeId = data;
                    //console.log($scope.EmployeeId);
                    if (data > 0) {
                        if ($scope.btnName == "Update") {
                            toastr.success('Employee updated successfully.');
                        }
                        else {
                            toastr.success('Employee saved successfully.');
                        }
                        Clear();
                        $(".userClass").removeClass("active");
                    } else {

                    }
                }).error(function (data) {

                });

                //SaveUser($scope.EmployeeId);
            }
            else if (result.dismiss == "cancel") {
                Swal.DismissReason.cancel;
            }
        })
    }


    $scope.EmployeeUpdate = function (emp) {
        $scope.btnName = "Update";
        $scope.Employee = emp;

        var res1 = emp.JoiningDate.substring(0, 5);
        if (res1 == "/Date") {
            var parsedDate1 = new Date(parseInt(emp.JoiningDate.substr(6)));
            var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
            emp.JoiningDate = date1;
        }

        var res1 = emp.FinishDate.substring(0, 5);
        if (res1 == "/Date") {
            var parsedDate1 = new Date(parseInt(emp.FinishDate.substr(6)));
            var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
            emp.FinishDate = date1;
        }
        var res1 = emp.DateOfBirth.substring(0, 5);
        if (res1 == "/Date") {
            var parsedDate1 = new Date(parseInt(emp.DateOfBirth.substr(6)));
            var date1 = ($filter('date')(parsedDate1, 'dd/MM/yyyy')).toString();
            emp.DateOfBirth = date1;
        }



        $scope.ddlSection = { Id: emp.SectionId };
        $scope.ddlDesignation = { DesignationId: emp.DesignationId };
        $scope.ddlContractType = { ContractTypeId: emp.ContractTypeId };
        $scope.ddlGrade = { GradeId: emp.GradeId };
        $scope.Employee.ManagerId = 0;

        //  if (emp.IsUser == false) {
        $http({
            url: '/User/GetUserByEmployeeId?EmployeeId=' + emp.EmployeeId,
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ddlRole = { RoleId: data.RoleId }

            $scope.User = data;
        });
        // }





    }

    function SaveUser() {

        $scope.User.RoleId = $scope.ddlRole.RoleId;


        $http.post('/User/SaveUser', parms).success(function (data) {
            if (data > 0) {
                toastr.success('User saved successfully.');
                Clear();
            } else {

            }
        }).error(function (data) {

        });
    }

    $scope.resetBtn = function () {
        Clear();
    }


    function EmployeeGetPaged(curPage) {

        if (curPage == null) curPage = 1;
        var startRecordNo = ($scope.PerPage * (curPage - 1)) + 1;

        var SearchCriteria = "";


        if ($scope.SearchItem != undefined && $scope.SearchItem != "") {
            SearchCriteria = "[E].[FirstName] LIKE '%" + $scope.SearchItem + "%' OR [E].[LastName] LIKE '%" + $scope.SearchItem + "%' OR [E].[EmployeeCode] LIKE '%" + $scope.SearchItem + "%' OR [E].[ContactNo] LIKE '%" + $scope.SearchItem + "%'";

        }


        $http({
            url: encodeURI('/Employee/EmployeePaged?startRecordNo=' + startRecordNo + '&rowPerPage=' + $scope.PerPage + "&whereClause=" + SearchCriteria + '&rows=' + 0),
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            $scope.EmployeeList = data.ListData;
            $scope.total_count = data.TotalRecord;
            //  $scope.ItemList = data.dTable.results;  


        });
    }


    $scope.getData = function (curPage) {

        // if ($scope.FromDate == "" || $scope.ToDate == "" ) {

        if ($scope.PerPage > 100) {
            $scope.PerPage = 100;
            $scope.currentPage = curPage;
            EmployeeGetPaged($scope.currentPage);
            //  alertify.log('Maximum record  per page is 100', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else if ($scope.PerPage < 1) {
            $scope.PerPage = 1;
            $scope.currentPage = curPage;
            EmployeeGetPaged($scope.currentPage);
            // alertify.log('Minimum record  per page is 1', 'error', '5000');
            toastr.error('Maximum record  per page is 100');
        }
        else {
            $scope.currentPage = curPage;
            EmployeeGetPaged($scope.currentPage);
        }
    }

    $scope.SearchBtn = function () {

        EmployeeGetPaged(1);
    }

    $scope.ClearBtn = function () {
        $scope.SearchItem = "";
        EmployeeGetPaged(1);
    }

});