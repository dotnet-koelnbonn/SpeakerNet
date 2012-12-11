
var SendMail = (function ($) {
    var speakerId;
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
            speakerId: speakerId     
        };
        $.post(postUrl, data, onGetTemplateData, "json");
    };


    return function (speaker, url) {

        $(function () {
            $("#Template").on("change", onTemplateChange);
        });
        
        speakerId = speaker;
        postUrl = url;
    };
})(jQuery);