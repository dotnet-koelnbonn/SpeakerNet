/// <reference path="ResultController.ts" />
/// <reference path="angular/angular.d.ts" />
/// <reference path="Transformations.ts" />
/// <reference path="VotingController.ts" />

'use strict';
module SpeakerNet {
    
    angular.module('SpeakerNet.Voting', ['SpeakerNet.VotingServices'])
        .config(function ($httpProvider) {
            $httpProvider.defaults.transformRequest.push(Transformations.AddAntiForgeryTokenToRequest);
        })
        .controller("Voting", VotingController)
        .controller("Result", ResultController);
}