/// <reference path="angular/angular.d.ts" />

module SpeakerNet.Transformations {
    export function AddAntiForgeryTokenToRequest(data, getHeaders) {
        if (angular.isString(data)) {
            data = JSON.parse(data);
        } else if (data == null || !data) {
            data = {};
        }
        var newData = { __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val() };
        $.extend(newData, data);
        var headers = getHeaders();
        headers['Content-Type'] = 'application/x-www-form-urlencoded';
        return $.param(newData);
    }
}