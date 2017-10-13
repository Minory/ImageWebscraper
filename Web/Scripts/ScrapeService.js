//Scrape Service
(function () {
    "use strict";
    angular
        .module('scrapeApp')
        .service('scrapeService', scrapeService);
    scrapeService.$inject = ['$http', '$q'];

    function scrapeService($http, $q) {
        return {
            get: _get,
            post: _post
        };
        //GET call to scrape based on keyword
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
        //POST call for adding keyword and results into local SQL DB
        function _post(keyword) {
            var settings = {
                url: "/api/scrape/" + keyword,
                method: 'POST',
                cache: false,
                responseType: 'json',
                withCredentials: true
            };
            return $http(settings)
                .then(_complete, _fail);
        }
        //Successful promised function returns data
        function _complete(data) {
            return data;
        }
        //Error promised function returns error message
        function _fail(err) {
            return $q.reject(err);
        }
    }
})();