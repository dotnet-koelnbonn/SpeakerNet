/// <reference path="SessionVotingServices.ts" />

module SpeakerNet {

    export interface IVotingControllerScope {
        maxPoints: number;
        currentPoints: number;
        sessions: ISessionVoteModel[];
        query: string;
        orderProperty: string;
    }

    export class VotingController {

        constructor(public $scope : IVotingControllerScope, Sessions : ISessionsService) {
            $scope.maxPoints = 45;
            $scope.currentPoints = 0;
            $scope.sessions = Sessions.query(null);
            $scope.orderProperty = "SpeakerName";
        }

        showSessionDetails(session : ISessionVoteModel) {
            for (var i = 0; i < this.$scope.sessions.length; i++) {
                if (session != this.$scope.sessions[i])
                    this.$scope.sessions[i].ShowAbstract = false;
            }
            session.ShowAbstract = !session.ShowAbstract;
        }
    }

}

