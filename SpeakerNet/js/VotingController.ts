/// <reference path="SessionVotingServices.ts" />

module SpeakerNet {

    export interface IVotingControllerScope {
        maxPoints: number;
        currentPoints: number;
        sessions: ISessionVoteModel[];
        query: string;
        orderProperty: string;
        showSessionDetails(session: ISessionVoteModel);
        hideVoting(session: ISessionVoteModel);
        showVoting(session: ISessionVoteModel);
        vote(session: ISessionVoteModel, points: number);
    }

    export class VotingController {

        constructor(public $scope: IVotingControllerScope, Sessions: ISessionsService, public VotingService : IVotingService) {
            $scope.maxPoints = 45;
            $scope.currentPoints = 0;
            $scope.orderProperty = "SpeakerName";
            $scope.sessions = Sessions.query(null);
            $scope.showSessionDetails = (session) => this.showSessionDetails(session);
            $scope.hideVoting = (session) => this.hideVoting(session);
            $scope.showVoting = (session) => this.showVoting(session);
            $scope.vote = (session, points) => this.vote(session, points);
        }

        showSessionDetails(session: ISessionVoteModel) {
            for (var i = 0; i < this.$scope.sessions.length; i++) {
                if (session != this.$scope.sessions[i])
                    this.$scope.sessions[i].ShowAbstract = false;
            }
            session.ShowAbstract = !session.ShowAbstract;
        }

        showVoting(session: ISessionVoteModel) {
            for (var i = 0; i < this.$scope.sessions.length; i++) {
                if (session != this.$scope.sessions[i])
                    this.$scope.sessions[i].ShowVoting = false;
            }
             session.ShowVoting = true;
        }
        hideVoting(session: ISessionVoteModel) {
            session.ShowVoting = false;
        }

        vote(session: ISessionVoteModel, points: number) {
            var result = this.VotingService.vote({ id: session.Id, points:points }, { id: session.Id, points:points });
        }
    }

}

