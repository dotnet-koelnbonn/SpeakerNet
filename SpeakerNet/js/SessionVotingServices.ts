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
        query(data, callback: (sessions :  ISessionVoteModel[])=>void): ISessionVoteModel[];
    }

    export interface IVotingServiceData {
        id?: number;
        points?: number;
    }
    export interface IVoteResult {
        SessionId: number;
        Points: number;
    }

    export interface ISessionVoterModel {
        Name: string;
        Points: number;
    }

    export interface IResultService {
        query(data, callback: (results: IResultModel) => void );
    }
    export interface IResultModel {
        Sessions: ISessionVoteModel[];
        Voters: ISessionVoterModel[];
    }
    export interface IVotingService {
        vote(params: IVotingServiceData, data: IVotingServiceData, callback: any): IVoteResult[];
        votes(data, callback: any): ng.IPromise;
    }

    var appRoot = $("body").data("appRoot");

    angular.module("SpeakerNet.VotingServices", ['ngResource'])
        .factory('Sessions', ($resource) => {
            return $resource(appRoot+ 'SessionVoting/Sessions', {}, {
                query: { method: 'POST', params: {}, isArray: true }
            });
        })
        .factory("VotingService", ($resource) => {
            return $resource(appRoot+'SessionVoting/vote/:id', { id: 0 }, {
                vote: { method: 'POST', params: { id: 0 }, isArray: true },
                votes: { method: 'POST', params: { id: 0 }, isArray: true }
            });
        })
        .factory('ResultService', ($resource) => {
            return $resource(appRoot+'SessionVoting/VotingResults', {}, {
                query: { method: 'POST', params: {} }
            });
        })

}