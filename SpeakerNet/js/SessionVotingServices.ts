/// <reference path="angular/angular-resource.d.ts" />
/// <reference path="angular/angular.d.ts" />


module SpeakerNet {

    export interface ISessionVoteModel {
        Id: number;
        Name: string;
        Abstract: string;
        ShowAbstract: bool;
        Duration: number;
        Points: number;
    }

    export interface ISessionsService {
        query(data): ISessionVoteModel[];
    }

    angular.module("SpeakerNet.VotingServices", ['ngResource'])
        .factory('Sessions', ($resource) => {
            return $resource('SessionVoting/Sessions', {}, {
                query: { method: 'POST', params: {}, isArray: true }
            });
        })
        .factory("Vote", ($resource) => {
            return $resource('SessionVoting/vote/:id', {}, {
                vote: { method: 'POST', params: { id: 0, points: 0 }, isArray: true }
            });
        });
}