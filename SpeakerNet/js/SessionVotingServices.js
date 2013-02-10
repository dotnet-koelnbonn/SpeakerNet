var SpeakerNet;
(function (SpeakerNet) {
    angular.module("SpeakerNet.VotingServices", [
        'ngResource'
    ]).factory('Sessions', function ($resource) {
        return $resource('SessionVoting/Sessions', {
        }, {
            query: {
                method: 'POST',
                params: {
                },
                isArray: true
            }
        });
    }).factory("VotingService", function ($resource) {
        return $resource('SessionVoting/vote/:id', {
            id: 0,
            points: 0
        }, {
            vote: {
                method: 'POST',
                params: {
                    id: 0
                },
                isArray: true
            }
        });
    });
})(SpeakerNet || (SpeakerNet = {}));
//@ sourceMappingURL=SessionVotingServices.js.map
