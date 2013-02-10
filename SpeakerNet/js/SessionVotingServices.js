'use strict';
var SpeakerNet;
(function (SpeakerNet) {
    var appRoot = $("body").data("appRoot");
    angular.module("SpeakerNet.VotingServices", [
        'ngResource'
    ]).factory('Sessions', function ($resource) {
        return $resource(appRoot + 'SessionVoting/Sessions', {
        }, {
            query: {
                method: 'POST',
                params: {
                },
                isArray: true
            }
        });
    }).factory("VotingService", function ($resource) {
        return $resource(appRoot + 'SessionVoting/vote/:id', {
            id: 0
        }, {
            vote: {
                method: 'POST',
                params: {
                    id: 0
                },
                isArray: true
            },
            votes: {
                method: 'POST',
                params: {
                    id: 0
                },
                isArray: true
            }
        });
    }).factory('ResultService', function ($resource) {
        return $resource(appRoot + 'SessionVoting/VotingResults', {
        }, {
            query: {
                method: 'POST',
                params: {
                }
            }
        });
    });
})(SpeakerNet || (SpeakerNet = {}));
//@ sourceMappingURL=SessionVotingServices.js.map
