var SpeakerNet;
(function (SpeakerNet) {
    var VotingController = (function () {
        function VotingController($scope, Sessions) {
            this.$scope = $scope;
            $scope.maxPoints = 45;
            $scope.currentPoints = 0;
            $scope.sessions = Sessions.query(null);
            $scope.orderProperty = "SpeakerName";
        }
        VotingController.prototype.showSessionDetails = function (session) {
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                if(session != this.$scope.sessions[i]) {
                    this.$scope.sessions[i].ShowAbstract = false;
                }
            }
            session.ShowAbstract = !session.ShowAbstract;
        };
        return VotingController;
    })();
    SpeakerNet.VotingController = VotingController;    
})(SpeakerNet || (SpeakerNet = {}));
//@ sourceMappingURL=VotingController.js.map
