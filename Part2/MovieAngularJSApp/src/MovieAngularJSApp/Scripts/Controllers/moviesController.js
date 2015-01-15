(function () {
    'use strict';

    angular
        .module('moviesApp')
        .controller('moviesController', moviesController);

    moviesController.$inject = ['$scope', 'Movies'];

    function moviesController($scope, Movies) {
        $scope.movies = Movies.query();
    }
})();
