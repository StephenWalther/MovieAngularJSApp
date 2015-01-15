(function () {
    'use strict';

    angular
        .module('moviesApp')
        .controller('MoviesListController', MoviesListController)
        .controller('MoviesAddController', MoviesAddController)
        .controller('MoviesEditController', MoviesEditController)
        .controller('MoviesDeleteController', MoviesDeleteController);

    /* Movies List Controller */
    MoviesListController.$inject = ['$scope', 'Movies'];

    function MoviesListController($scope, Movies) {
        $scope.movies = Movies.query();
    }

    /* Movies Create Controller */
    MoviesAddController.$inject = ['$scope', 'Movies'];

    function MoviesAddController($scope, Movies) {
        $scope.movies = Movies.query();
    }

    /* Movies Edit Controller */
    MoviesEditController.$inject = ['$scope', '$routeParams', 'Movies'];

    function MoviesEditController($scope, $routeParams, Movies) {
        $scope.movie = Movies.get({ id: $routeParams.id });
        $scope.edit = function () {
            $scope.movie.$update(function () {
                debugger;
            });
        };
    }

    /* Movies Delete Controller */
    MoviesDeleteController.$inject = ['$scope', 'Movies'];

    function MoviesDeleteController($scope, Movies) {
        $scope.movies = Movies.query();
    }



})();
