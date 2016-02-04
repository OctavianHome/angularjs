app.controller("octavianController", function($scope,$location,$routeParams, octavianService) {

    $scope.getAllPersons = function () {
        var getData = octavianService.getPersons();
        getData.then(function(person) {
            $scope.persons = person.data;
        }, function() {
            alert('Error in getting records');
        });
    }

    
    $scope.getPerson = function () {
        var personId = $routeParams.personId;
        var getData = octavianService.getPerson(personId);
        getData.then(function (personData) {
                var person = personData.data;
                $scope.personId = person.Id;
                $scope.personName = person.Name;
                $scope.personRevenue = person.Revenue;
                $scope.personComment = person.Comment;
            },
            function() {
                alert('Error in getting records');
            });
    }
    
    $scope.editPerson = function () {
        var person = {
            Id: $scope.personId,
            Name: $scope.personName,
            Revenue: $scope.personRevenue,
            Comment: $scope.personComment
        };
        octavianService.editPerson(person);
        //$location.path('/').replace();
        //getAllPersons();
        window.location.href = "/";
    }

    $scope.richPerson = function (minvalue) {
        return function(person) {
            return person.Revenue > minvalue;
        }
    };
});