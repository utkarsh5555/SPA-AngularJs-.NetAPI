﻿(function (app) {
    var MusicListController = function ($scope, musicService) {
        musicService.getAll()
            .then(function (data) {
                $scope.musics = data.data;
            });
        $scope.delete = function (music) {
            musicService.delete(music.Id)
                .then(function () {
                    removeMusicById(music.Id);
                });
        };  
        var removeMusicById = function (id) {
            for (var i = 0; i < $scope.musics.length; i++) {
                if ($scope.musics[i].Id == id) {
                    $scope.musics.splice(i, 1);
                    break;
                }
            }
        };  
        $scope.create = function () {
            $scope.edit = {
                music: {
                    Title: "",
                    Singers: "",
                    ReleaseDate: new Date,
                    RunTime: 0
                }
            };
        };  
    };
    app.controller("MusicListController", MusicListController);
}(angular.module("theMusic")));