//Scrape Controller
(function () {
    "use strict";
    angular
        .module('scrapeApp')
        .controller('scrapeController', scrapeController);

    scrapeController.$inject = ['$scope', 'scrapeService', '$window'];

    function scrapeController($scope, scrapeService, $window) {

        var vm = this;
        vm.$scope = $scope;
        vm.scrapeService = scrapeService;
        vm.keyword = "";
        vm.items = [];
        vm.$window = $window;
        vm.search = _search;
        vm.reset = false; //Reset page for new entry
        vm.load = false; //Loading shows or not

        //Search button function
        function _search() {
            vm.load = true;
            if (vm.reset == true) vm.items = [];
            return vm.scrapeService.get(vm.keyword)
                .then(_success, _error);
        }
        //On success, images set to items to show on page
        function _success(data) {
            console.log(data.data);
            vm.items = data.data;
            vm.keyword = null;
            vm.reset = true;
            vm.load = false;
            return 
        }
        //Error logs message in console
        function _error(err) {
            return console.log(err)
        }

    }
})();

