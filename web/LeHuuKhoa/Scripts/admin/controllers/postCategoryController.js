$(document).ready(function () {

    $("#toggleFinder").on("click",
        function () {
            var ckFinder = new CKFinder();
            ckFinder.selectActionFunction = function (url) {
                $("#txtImageUrl").val(url);
                $("#bindingImage").attr("src", url);
            }
            ckFinder.popup();
        });
})