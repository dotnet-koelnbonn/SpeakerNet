/// <reference path="angular/angular.d.ts" />
/// <reference path="SessionVotingServices.ts" />
'use strict';
module SpeakerNet {

    export interface IVotingControllerScope {
        maxPoints: number;
        currentPoints: number;
        sessions: ISessionVoteModel[];
        query: string;
        orderProperty: string;
        showSessionDetails(session: ISessionVoteModel);
        hideVoting(session: ISessionVoteModel, e: JQueryEventObject);
        showVoting(session: ISessionVoteModel, e: JQueryEventObject);
        vote(session: ISessionVoteModel, points: number, e: JQueryEventObject);
    }

    export class VotingController {

        constructor(public $scope: IVotingControllerScope, Sessions: ISessionsService, public VotingService: IVotingService) {
            $scope.maxPoints = 45;
            $scope.currentPoints = 0;
            $scope.orderProperty = "SpeakerName";
            $scope.sessions = Sessions.query(null, (result) =>
            {
                this.createSessionIndex(result);
                VotingService.votes(null, (result) => this.setVotes(result));
            });
            $scope.showSessionDetails = (session) => this.showSessionDetails(session);
            $scope.hideVoting = (session, e) => this.hideVoting(session, e);
            $scope.showVoting = (session, e) => this.showVoting(session, e);
            $scope.vote = (session, points, e) => this.vote(session, points, e);
            this.indexSessions = [];
        }

        indexSessions: ISessionVoteModel[];
        createSessionIndex(result: ISessionVoteModel[]) {
            if (this.indexSessions.length > 0)
                return;

            for (var i = 0; i < this.$scope.sessions.length; i++) {
                var session = this.$scope.sessions[i];
                this.indexSessions[session.Id] = session;
            }
        }

        showSessionDetails(session: ISessionVoteModel) {
            for (var i = 0; i < this.$scope.sessions.length; i++) {
                if (session != this.$scope.sessions[i])
                    this.$scope.sessions[i].ShowAbstract = false;
            }
            session.ShowAbstract = !session.ShowAbstract;
        }

        showVoting(session: ISessionVoteModel, e: JQueryEventObject) {
            for (var i = 0; i < this.$scope.sessions.length; i++) {
                if (session != this.$scope.sessions[i])
                    this.$scope.sessions[i].ShowVoting = false;
            }
            session.ShowVoting = true;
        }
        hideVoting(session: ISessionVoteModel, e: JQueryEventObject) {
            session.ShowVoting = false;
        }
        vote(session: ISessionVoteModel, points: number, e: JQueryEventObject) {
            this.VotingService.vote({ id: session.Id, points : points } , result => {
                session.ShowVoting = false;
                if (result.length == 0) {
                } else {
                    this.setVotes(result)
                }
            } );
        }

        setVotes(votes: IVoteResult[]) {
            var points = 0;
            for (var i = 0; i < votes.length; i++) {
                var r = votes[i];
                this.indexSessions[r.SessionId].Points = r.Points;
                this.indexSessions[r.SessionId].ShowVoting = false;
                points += r.Points;
            }
            this.$scope.currentPoints = points;
        }
    }

}

