//Scrape Service
(function () {
    "use strict";
    angular
        .module('scrapeApp')
        .service('scrapeService', scrapeService);
    scrapeService.$inject = ['$http', '$q'];

    function scrapeService($http, $q) {
        return {
            get: _get
        };
        function _get(keyword) {
            var settings = {
                url: "/api/scrape/" + keyword,
                method: 'GET',
                cache: false,
                responseType: 'json',
                withCredentials: true
            };
            return $http(settings)
                .then(_complete, _fail);
        }
        function _complete(data) {
            return data;
        }
        function _fail(err) {
            return $q.reject(err);
        }
    }
})();