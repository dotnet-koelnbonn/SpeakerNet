'use strict';

(function () {
    var votingController = function($scope, Sessions) {

        $scope.sessions = Sessions.query(null);
        $scope.orderProperty = "SpeakerName";
        $scope.maxPoints = 45;
        $scope.currentPoints = 0;
        
        $scope.showSessionDetails = function(session) {
            for (var i = 0; i < $scope.sessions.length; i++) {
                if (session != $scope.sessions[i])
                    $scope.sessions[i].ShowAbstract = false;
            }
            session.ShowAbstract = !session.ShowAbstract;
        };

        $scope.hideSessionDetails = function(session) {
            session.ShowAbstract = false;
        };
    };
    
    angular.module('SpeakerNet.Voting', ['SpeakerNet.VotingServices'])
        .config(function($httpProvider) {
            var addAntiForgeryToken = function(data, getHeaders) {
                if (angular.isString(data)) {
                    data = JSON.parse(data);
                } else if (data == null || !data) {
                    data = {};
                }
                var newData = { __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val() };
                $.extend(newData, data);
                var headers = getHeaders();
                headers['Content-Type'] = 'application/x-www-form-urlencoded';
                return $.param(newData);
            };
            $httpProvider.defaults.transformRequest.push(addAntiForgeryToken);
        })
        .controller("VotingCtrl", votingController);
})();