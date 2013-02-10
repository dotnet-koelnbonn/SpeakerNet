/// <reference path="angular/angular-resource.d.ts" />
/// <reference path="angular/angular.d.ts" />
'use strict';

module SpeakerNet {

    export interface ISessionVoteModel {
        Id: number;
        Name: string;
        Abstract: string;
        Duration: number;
        Points: number;

        ShowAbstract: bool;
        ShowVoting: bool;
    }

    export interface ISessionsService {
        query(data, callback: any): ISessionVoteModel[];
    }

    export interface IVotingServiceData {
        id: number;
        points: number;
    }
    export interface IVoteResult {
        SessionId: number;
        Points: number;
    }

    export interface IVotingService {
        vote(data: IVotingServiceData, callback:any): IVoteResult[];
        votes(data, callback:any): ng.IPromise;
    }
    angular.module("SpeakerNet.VotingServices", ['ngResource'])
        .factory('Sessions', ($resource) => {
            return $resource('SessionVoting/Sessions', {}, {
                query: { method: 'POST', params: {}, isArray: true }
            });
        })
        .factory("VotingService", ($resource) => {
            return $resource('SessionVoting/vote/:id', { id : 0}, {
                vote: { method: 'POST', params: { id: 0 }, isArray: true },
                votes: { method: 'POST', params: { id : 0 }, isArray: true }
            });
        });
}