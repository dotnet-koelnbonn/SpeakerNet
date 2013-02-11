'use strict';
var SpeakerNet;
(function (SpeakerNet) {
    (function (Transformations) {
        function AddAntiForgeryTokenToRequest(data, getHeaders) {
            if(angular.isString(data)) {
                data = JSON.parse(data);
            } else if(data == null || !data) {
                data = {
                };
            }
            var newData = {
                __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val()
            };
            $.extend(newData, data);
            var headers = getHeaders();
            headers['Content-Type'] = 'application/x-www-form-urlencoded';
            return $.param(newData);
        }
        Transformations.AddAntiForgeryTokenToRequest = AddAntiForgeryTokenToRequest;
    })(SpeakerNet.Transformations || (SpeakerNet.Transformations = {}));
    var Transformations = SpeakerNet.Transformations;
})(SpeakerNet || (SpeakerNet = {}));
