
var SendMail = (function ($) {
    var _speakerId;
    var postUrl;
    
    var onGetTemplateData = function(data) {
        $("#Subject").val(data.Subject);
        $("#Body").val(data.Body);
    };
    var onTemplateChange = function(evt) {
        evt.stopPropagation();
        var data = {
            '__RequestVerificationToken': $('input[name=__RequestVerificationToken]').val(),
            templateId: $(this).val(),
            speakerId: _speakerId     
        };
        $.post(postUrl, data, onGetTemplateData, "json");
    };

    return function (speakerId, url) {

        $(function () {
            $("#Template").on("change", onTemplateChange);
        });
        
        _speakerId = speakerId;
        postUrl = url;
    };
})(jQuery);