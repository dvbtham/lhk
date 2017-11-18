$(document).ready(function () {

    var postTypeVal = $("#selectTemplate").val();
    var fileBox = $("#fileBox");
    var contentBox = $("#contentBox");

    applyPostType(postTypeVal);

    $("#selectTemplate").on("change",
        function (e) {
            var postType = e.target.value;
            applyPostType(postType, true);
        });


    function goToByScroll(id) {
       
        id = id.replace("link", "");
        
        $("html,body").animate({
                scrollTop: $("#" + id).offset().top
            },
            "slow");
    }

    function applyPostType(postType, resetContent = false) {
        var mode = $("#mode").val();
        if (postType === "10") //file
        {
            console.log(mode);
            fileBox.removeClass("hide");
            goToByScroll(fileBox.attr("id"));
            if (mode === "create")
                $("#file").prop("required", true);
            $("#fileBox").css("border", "1px solid red");
            setTimeout(function() {
                $("#fileBox").css("border", "none");
            }, 3000);
            contentBox.addClass("hide");
            if (resetContent)
                CKEDITOR.instances["txtContent"].setData("");

        } else if (postType === "20") {
            contentBox.removeClass("hide");
            goToByScroll(contentBox.attr("id"));
            if (mode === "create")
                $("#file").prop("required", false);
            fileBox.addClass("hide");
            $("#file").val("");


        } else {
            contentBox.addClass("hide");
            fileBox.addClass("hide");
        }
    }

    CKEDITOR.replace("txtDescription", {
        customConfig: "/Scripts/config.js"
    });
    CKEDITOR.replace("txtContent", {
        customConfig: "/Scripts/config.js"
    });

})