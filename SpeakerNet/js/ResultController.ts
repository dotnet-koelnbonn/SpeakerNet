/// <reference path="jquery/jquery.d.ts" />
/// <reference path="angular/angular.d.ts" />
/// <reference path="SessionVotingServices.ts" />
/// <reference path="signalr/signalr.d.ts" />
'use strict';

interface SignalR {
    votingResult: HubConnection;
}

interface IResultHubClient {
    updateSession(result: SpeakerNet.IResultModel);
}
interface HubConnection {
    client: IResultHubClient;
}
module SpeakerNet {

    export interface IResultControllerScope {
        maxPoints: number;
        currentPoints: number;
        sessions: ISessionVoteModel[];
        voters: ISessionVoterModel[];
    }

    export class ResultController {

        constructor(public $scope: IResultControllerScope, public ResultService: IResultService) {
            var hub = $.connection.votingResult;
            hub.client.updateSession = (result) => this.updateSessions(result);
            $.connection.hub.start();
            this.loadAllResults();
        }
        loadAllResults() {
            this.ResultService.query(null, (result) => {
                this.$scope.sessions = result.Sessions;
                this.$scope.voters = result.Voters;
            });
        }
        updateSessions(result: IResultModel) {
            this.loadAllResults();
            return;
            // Uptimize to update only needed
            this.$scope.voters = result.Voters;
            var session = result.Sessions[0];
            if (session.Points == 0) {
                this.removeSession(session.Id);
            } else {
                this.updateSession(session);
            }
        }
        findSessionIndex(sessionId): number {
            for (var i = 0; i < this.$scope.sessions.length; i++) {
                if (this.$scope.sessions[i].Id === sessionId) {
                    return i
                }
            }
            return -1;
        }
        findSession(sessionId: number) {
            var i = this.findSessionIndex(sessionId);
            if (i < 0)
                return null;
            return this.$scope.sessions[i];
        }

        removeSession(sessionId: number) {
            var i = this.findSessionIndex(sessionId);
            this.$scope.sessions = this.$scope.sessions.splice(i);
        }
        updateSession(session: ISessionVoteModel) {
            var currentSession = this.findSession(session.Id);
            if (currentSession != null) {
                currentSession.Points = session.Points;
            } else {
                this.loadAllResults();
            }
        }
    }
}