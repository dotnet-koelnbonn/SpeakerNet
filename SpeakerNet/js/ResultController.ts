/// <reference path="angular/angular.d.ts" />
/// <reference path="SessionVotingServices.ts" />
'use strict';
module SpeakerNet {
    


    export interface IResultControllerScope {
        maxPoints: number;
        currentPoints: number;
        sessions: ISessionVoteModel[];
        voters: ISessionVoterModel[];
    }

    export class ResultController
    {
        constructor(public $scope: IResultControllerScope, ResultService : IResultService) {
            ResultService.query(null, (result) => {
                $scope.sessions = result.Sessions;
                $scope.voters = result.Voters;
            });
        }
    }
}