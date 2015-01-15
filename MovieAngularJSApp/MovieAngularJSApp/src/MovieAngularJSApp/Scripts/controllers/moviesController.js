(function () {
    'use strict';

    angular
        .module('moviesApp')
        .controller('moviesController', moviesController);

    moviesController.$inject = ['$scope', 'Movies']; 

    function moviesController($scope, Movies) {
        $scope.title = 'Peanuty butter';

        $scope.movies = Movies.query();
    }
})();
