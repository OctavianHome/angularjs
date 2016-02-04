var app = angular.module('octavianApp', ['ngRoute']);

app.config(function($routeProvider, $locationProvider) {
    $routeProvider
        .when('/home', {
                templateUrl: 'person/home',
                controller: 'octavianController'
            }
        )
        .when('/edit/:personId', {
                templateUrl: 'person/edit',
                controller: 'octavianController'
            }
        )
        .otherwise({
            redirectTo: '/home'
        });

    $locationProvider.html5Mode(true);
});