(function () {
    'use strict';

    angular
        .module('moviesApp')
        .controller('MoviesListController', MoviesListController)
        .controller('MoviesAddController', MoviesAddController)
        .controller('MoviesEditController', MoviesEditController)
        .controller('MoviesDeleteController', MoviesDeleteController)
        .controller('DatePickerController', DatePickerController);

    /* Movies List Controller  */
    MoviesListController.$inject = ['$scope', 'Movie'];

    function MoviesListController($scope, Movie) {
        $scope.movies = Movie.query();
    }

    /* Movies Create Controller */
    MoviesAddController.$inject = ['$scope', '$location', 'Movie'];

    function MoviesAddController($scope, $location, Movie) {
        $scope.movie = new Movie();
        $scope.add = function () {
        	$scope.movie.$save(
				// success
				function () {
					$location.path('/');
				},
				// error
				function (error) {
					_showValidationErrors($scope, error);
				}
			);
        };

    }

    /* Movies Edit Controller */ 
    MoviesEditController.$inject = ['$scope', '$routeParams', '$location', 'Movie'];

    function MoviesEditController($scope, $routeParams, $location, Movie) {
        $scope.movie = Movie.get({ id: $routeParams.id });
        $scope.edit = function () {
        	$scope.movie.$save(
				// success
				function () {
					$location.path('/');
				},
				// error
				function (error) {
					_showValidationErrors($scope, error);
				}
			);
        };
    }

    /* Movies Delete Controller  */
    MoviesDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Movie'];

    function MoviesDeleteController($scope, $routeParams, $location, Movie) {
        $scope.movie = Movie.get({ id: $routeParams.id });
        $scope.remove = function () {
            $scope.movie.$remove({id:$scope.movie.Id}, function () {
                $location.path('/');
            });
        };
    }

	/* Movies Delete Controller  */
    DatePickerController.$inject = ['$scope'];

    function DatePickerController($scope) {
    	$scope.open = function ($event) {
    		$event.preventDefault();
    		$event.stopPropagation();

    		$scope.opened = true;
    	};
    }


    
	/* Utility Functions */

    function _showValidationErrors($scope, error) {
    	$scope.validationErrors = [];
    	if (error.data && angular.isObject(error.data)) {
    		for (var key in error.data) {
    			$scope.validationErrors.push(error.data[key][0]);
    		}
    	} else {
    		$scope.validationErrors.push('Could not add movie.');
    	};
    }

})();
