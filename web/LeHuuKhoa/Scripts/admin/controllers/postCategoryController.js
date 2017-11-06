$(document).ready(function () {

    $("#toggleFinder").on("click",
        function () {
            var ckFinder = new CKFinder();
            ckFinder.selectActionFunction = function (url) {
                $("#txtImageUrl").val(url);
                $("#bindingImage").attr("src", url);
            };
            ckFinder.popup();
        });
    $("#contentToggle").on('click', function () {
        var x = document.getElementById("content");
        if (x.className === "input-group hide") {
            $("#content").removeClass("hide");
        } else {
            $("#content").addClass("hide");
        }
    });
    

    $("#toggleBackgroundImage").on("click",
        function () {
            var ckFinder = new CKFinder();
            ckFinder.selectActionFunction = function (url) {
                $("#txtBackgroundImage").val(url);
                $("#bindingBgImage").attr("src", url);
            };
            ckFinder.popup();
        });


    CKEDITOR.replace("txtDescription",
        {
            customConfig: '/Scripts/config.js'
        });
   
});