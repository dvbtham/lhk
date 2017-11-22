﻿$(document).ready(function () {

    var postTypeVal = $("#selectTemplate").val();
    var fileBox = $("#fileBox");
    var contentBox = $("#contentBox");
    var imageBox = $("#imageBox");

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
            imageBox.addClass("hide");
            imageBox.val("");
            if (resetContent)
                CKEDITOR.instances["txtContent"].setData("");

        } else if (postType === "20") {
            contentBox.removeClass("hide");
            goToByScroll(contentBox.attr("id"));
            if (mode === "create")
                $("#file").prop("required", false);
            fileBox.addClass("hide");
            imageBox.addClass("hide");
            $("#file").val("");


        }
        else if (postType === "30") {
            imageBox.removeClass("hide");
            goToByScroll(imageBox.attr("id"));
            if (mode === "create")
                $("#file").prop("required", false);
            fileBox.addClass("hide");
            $("#file").val("");
            contentBox.addClass("hide");

        }
        else {
            contentBox.addClass("hide");
            fileBox.addClass("hide");
            imageBox.addClass("hide");
        }
    }

    $("#toggleImages").on("click",
        function() {
            var imagesSrc = "";
            var finder = new CKFinder();
            finder.selectActionFunction = function (url, file, files) {
                for (var i = 0; i < files.length; i++) {
                    imagesSrc += files[i].url + "|";
                    $("#slideImages").val(imagesSrc);
                }
            };
            
            finder.popup();
        });
    

    CKEDITOR.replace("txtDescription", {
        customConfig: "/Scripts/config.js"
    });
    CKEDITOR.replace("txtContent", {
        customConfig: "/Scripts/config.js"
    });

})