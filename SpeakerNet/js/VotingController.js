'use strict';
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
            $scope.sessions = Sessions.query(null, function (result) {
                _this.createSessionIndex(result);
                VotingService.votes(null, function (result) {
                    return _this.setVotes(result);
                });
            });
            $scope.showSessionDetails = function (session) {
                return _this.showSessionDetails(session);
            };
            $scope.hideVoting = function (session, e) {
                return _this.hideVoting(session, e);
            };
            $scope.showVoting = function (session, e) {
                return _this.showVoting(session, e);
            };
            $scope.vote = function (session, points, e) {
                return _this.vote(session, points, e);
            };
            this.indexSessions = [];
        }
        VotingController.prototype.createSessionIndex = function (result) {
            if(this.indexSessions.length > 0) {
                return;
            }
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                var session = this.$scope.sessions[i];
                this.indexSessions[session.Id] = session;
            }
        };
        VotingController.prototype.showSessionDetails = function (session) {
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                if(session != this.$scope.sessions[i]) {
                    this.$scope.sessions[i].ShowAbstract = false;
                }
            }
            session.ShowAbstract = !session.ShowAbstract;
        };
        VotingController.prototype.showVoting = function (session, e) {
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                if(session != this.$scope.sessions[i]) {
                    this.$scope.sessions[i].ShowVoting = false;
                }
            }
            session.ShowVoting = true;
        };
        VotingController.prototype.hideVoting = function (session, e) {
            session.ShowVoting = false;
        };
        VotingController.prototype.vote = function (session, points, e) {
            var _this = this;
            this.VotingService.vote({
                id: session.Id,
                points: points
            }, function (result) {
                session.ShowVoting = false;
                if(result.length == 0) {
                } else {
                    _this.setVotes(result);
                }
            });
        };
        VotingController.prototype.setVotes = function (votes) {
            var points = 0;
            for(var i = 0; i < votes.length; i++) {
                var r = votes[i];
                this.indexSessions[r.SessionId].Points = r.Points;
                this.indexSessions[r.SessionId].ShowVoting = false;
                points += r.Points;
            }
            this.$scope.currentPoints = points;
        };
        return VotingController;
    })();
    SpeakerNet.VotingController = VotingController;    
})(SpeakerNet || (SpeakerNet = {}));
//@ sourceMappingURL=VotingController.js.map
