(function () {
    "use strict";


    var module = angular.module("courses",[])
        .factory("courseData", ["$http", function ($http) {

            var courseData = {};

            courseData.get = function () {
               return $http.get("/api/cource");                 
            };

            courseData.delete = function (id) {
                return $http.delete("/api/cource/" + id);
            };

            return courseData;
    }]);

})();
