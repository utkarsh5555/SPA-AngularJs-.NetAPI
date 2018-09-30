(function (app) {
    var DetailsController = function ($scope, musicService, $routeParams) {
        var id = $routeParams.id;
        musicService.getById(id)  
            .then(function (data) {
                $scope.music = data.data;
            });
        $scope.edit = function () {
            $scope.edit.music = angular.copy($scope.music);
        };  
    };
   
    app.controller("DetailsController", DetailsController);
}(angular.module("theMusic")));
