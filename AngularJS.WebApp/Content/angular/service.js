app.service("octavianService", function ($http) {

    //get All Persons
    this.getPersons = function() {
        return $http.get("Person/GetAll");
    };

    // get Person By Id
    this.getPerson = function (personId) {
        var response = $http({
            method: "GET",
            //url: "Person/Get",
            url: "../Person/Get",
            params: { personId: personId }
        });
        return response;
    }

    // Update Person
    this.editPerson = function (person) {
        var response = $http({
            method: "post",
            url: "../Person/Update",
            data: JSON.stringify(person),
            dataType: "json"
        });
        return response;
    }
});