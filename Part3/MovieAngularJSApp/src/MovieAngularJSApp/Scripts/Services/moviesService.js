(function () {
    'use strict';

    angular
        .module('moviesServices', ['ngResource'])
        .factory('Movie', Movie);

    Movie.$inject = ['$resource'];

    function Movie($resource) {
        return $resource('/api/movies/:id');
    }


})();