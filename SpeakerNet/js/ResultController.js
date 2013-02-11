'use strict';
var SpeakerNet;
(function (SpeakerNet) {
    var ResultController = (function () {
        function ResultController($scope, ResultService) {
            this.$scope = $scope;
            this.ResultService = ResultService;
            var _this = this;
            var hub = $.connection.votingResult;
            hub.client.updateSession = function (result) {
                return _this.updateSessions(result);
            };
            $.connection.hub.start();
            this.loadAllResults();
        }
        ResultController.prototype.loadAllResults = function () {
            var _this = this;
            this.ResultService.query(null, function (result) {
                _this.$scope.sessions = result.Sessions;
                _this.$scope.voters = result.Voters;
            });
        };
        ResultController.prototype.updateSessions = function (result) {
            this.loadAllResults();
            return;
            this.$scope.voters = result.Voters;
            var session = result.Sessions[0];
            if(session.Points == 0) {
                this.removeSession(session.Id);
            } else {
                this.updateSession(session);
            }
        };
        ResultController.prototype.findSessionIndex = function (sessionId) {
            for(var i = 0; i < this.$scope.sessions.length; i++) {
                if(this.$scope.sessions[i].Id === sessionId) {
                    return i;
                }
            }
            return -1;
        };
        ResultController.prototype.findSession = function (sessionId) {
            var i = this.findSessionIndex(sessionId);
            if(i < 0) {
                return null;
            }
            return this.$scope.sessions[i];
        };
        ResultController.prototype.removeSession = function (sessionId) {
            var i = this.findSessionIndex(sessionId);
            this.$scope.sessions = this.$scope.sessions.splice(i);
        };
        ResultController.prototype.updateSession = function (session) {
            var currentSession = this.findSession(session.Id);
            if(currentSession != null) {
                currentSession.Points = session.Points;
            } else {
                this.loadAllResults();
            }
        };
        return ResultController;
    })();
    SpeakerNet.ResultController = ResultController;    
})(SpeakerNet || (SpeakerNet = {}));
