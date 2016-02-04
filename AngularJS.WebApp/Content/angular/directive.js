app.directive('customDisplay', function () {
    return {
        //restrict: 'A',
        replace: true,
        scope: { field: '=' },
        template: '<td>{{field}}</td>'
    };
});

app.directive('deleteWarning', function () {
    return {
        restrict: 'E',
        //require: "ngModel",
        replace: true,
        scope: {
            salary: '@'
        },
        template: '<a ng-click="showWarning()" class="btnRed">Delete</a>',
        link: function (scope, element, attrs) {
            scope.showWarning = function () {
                var salary = scope.salary;
                alert('Do you want to delete this person - ' + salary + "$ ?");
            }
        }
    };
});