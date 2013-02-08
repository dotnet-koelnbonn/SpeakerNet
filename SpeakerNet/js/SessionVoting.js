'use strict';

(function() {

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
        .controller("VotingCtrl", SpeakerNet.VotingController);
})();