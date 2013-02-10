'use strict';
var SpeakerNet;
(function (SpeakerNet) {
    var ResultController = (function () {
        function ResultController($scope, ResultService) {
            this.$scope = $scope;
            ResultService.query(null, function (result) {
                $scope.sessions = result.Sessions;
                $scope.voters = result.Voters;
            });
        }
        return ResultController;
    })();
    SpeakerNet.ResultController = ResultController;    
})(SpeakerNet || (SpeakerNet = {}));
//@ sourceMappingURL=ResultController.js.map
