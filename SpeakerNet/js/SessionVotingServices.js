
(function() {
    angular.module("SpeakerNet.VotingServices", ['ngResource'])
        .factory('Sessions', function($resource) {
            return $resource('SessionVoting/Sessions', {}, {
                query: { method: 'POST', params: {}, isArray: true }
            });
        })
        .factory("Session", function($resource) {
            return $resource('SessionVoting/session/:id', {}, {
                get: { method: 'POST', params: { id: '0' }, isArray: true }
            });
        });
})();