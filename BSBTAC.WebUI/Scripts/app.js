(function () {
    var app = angular.module("app", []);

    var MainController = function ($scope, $http) {
        $scope.selectedFile = "No file selected";
    }

    app.controller("MainController", ["$scope", "$http", MainController]);

    /*
    app.directive('file', function () {
        return {
            scope: {
                file: '='
            },
            link: function (scope, el, attrs) {
                el.bind('change', function (event) {
                    var files = event.target.files;
                    var file = files[0];
                    scope.file = file ? file.name : undefined;
                    scope.$apply();
                });
            }
        };
    });
    */
}());