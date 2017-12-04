app.service("APIService", function ($http) {

    // GET: api/Departments
    this.getDeptartments = function () {
        var url = 'api/Departments';
        return $http.get(url).then(function (response) {
            return response.data;
        });        
    }

    //POST: api/Employees
    this.getEmployees = function (params) {
        var url = 'api/Employees';
        return $http.post(url, params).then(function (response) {
            return response.data;
        });
    }
});