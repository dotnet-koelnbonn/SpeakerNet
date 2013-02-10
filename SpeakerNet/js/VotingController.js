var SpeakerNet;
(function (SpeakerNet) {
    var VotingController = (function () {
        function VotingController($scope, Sessions, VotingService) {
            this.$scope = $scope;
            this.VotingService = VotingService;
            var _this = this;
            $scope.maxPoints = 45;
            $scope.currentPoints = 0;
            $scope.orderProperty = "SpeakerName";
            $scope.sessions = Sessions.query(null);
            $scope.showSessionDetails = function (session) {
                return _this.showSessionDetails(session);
            };
            $scope.hideVoting = function (session) {
                return _this.hideVoting(session);
            };
            $scope.showVoting = function (session) {
                return _this.showVoting(session);
            };
            $scope.vote = function (session, points) {
                return _this.vote(session, points);
            };
        }
        VotingController.prototype.showSessionDetails = function (session) {
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                if(session != this.$scope.sessions[i]) {
                    this.$scope.sessions[i].ShowAbstract = false;
                }
            }
            session.ShowAbstract = !session.ShowAbstract;
        };
        VotingController.prototype.showVoting = function (session) {
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                if(session != this.$scope.sessions[i]) {
                    this.$scope.sessions[i].ShowVoting = false;
                }
            }
            session.ShowVoting = true;
        };
        VotingController.prototype.hideVoting = function (session) {
            session.ShowVoting = false;
        };
        VotingController.prototype.vote = function (session, points) {
            var result = this.VotingService.vote({
                id: session.Id,
                points: points
            }, {
                id: session.Id,
                points: points
            });
        };
        return VotingController;
    })();
    SpeakerNet.VotingController = VotingController;    
})(SpeakerNet || (SpeakerNet = {}));
//@ sourceMappingURL=VotingController.js.map
