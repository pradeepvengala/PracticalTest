app.controller('APIController', function ($scope, APIService) {
    getDeptartments();

    //Get Departments
    function getDeptartments() {
        var servCall = APIService.getDeptartments();
        servCall.then(function (d) {
            $scope.DeptsObject = d;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.')
        });
    }

    //Get Employees based on filters
    $scope.getEmployees = function(){
        
        //Params
        var params = {
            deptId: $scope.deptModel,
            date: $scope.dateModel,
            status: $scope.statusModel
        };

        //Service Call
        var servCall = APIService.getEmployees(params);
        servCall.then(function (e) {
            $scope.EmpsObject = e;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.')
        });
    }

    //Show Employee details on Model
    $scope.showEmployeeDetails = function(id){
         var temp = $scope.EmpsObject.filter(function (emp) {

            return (emp.empId == id);
        });

         var empDetails = temp[0];

         $scope.lblempId = empDetails.empId;
         $scope.lblfirstName = empDetails.firstName;
         $scope.lbllastName = empDetails.lastName;
         $scope.lbldob = empDetails.dob;
         $scope.lbljoiningDate = empDetails.joiningDate;
         $scope.lbldeptName = empDetails.deptName;
         $scope.lblstatus = (empDetails.status == true)? "Present" : "Absent" ;
    };
    
});