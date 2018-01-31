(function () {
    "use strict";

    var module = angular.module("courses");

    module.controller("coursesController", ["$scope", "$timeout","courseData",
        function ($scope, $timeout, courseData) {
            getCourses();

            function getCourses() {
                courseData.get()
                    .then(function (found) {
                        $scope.coursesData = found.data;
                    }, function (error) {
                        console.log(error);
                    });
            }

            $scope.delete = function (id) {         
                courseData.delete(id)
                    .then(function () {
                        deleteCourse(id);
                    }, function (error) {
                        console.log(error);
                    });
            };

            $scope.edit = function (id) {
                window.location.pathname = 'course/edit/' + id;
            };

            function deleteCourse(id) {
                var found = $scope.coursesData.filter(function (m) {
                    return (m.courseId === id);
                });
                if (found) {
                    var index = $scope.coursesData.indexOf(found);
                    $scope.coursesData.splice(index, 1);     
                }
            };

            $scope.hoverIn = function (item) {               
                renderSchedule(item);
                $scope.hoverEdit = true; 
            };

            $scope.hoverOut = function () {
                clearSchedule();
                $scope.hoverEdit = false;        
            };
        }
    ]);



})();