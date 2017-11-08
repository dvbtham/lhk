$(function () {
    var parallax = $(".parallax");
    var category = $("#right");
    var height = category.height() + parallax.height();

    jQuery(window).scroll(function () {
        if (jQuery(this).scrollTop() > height) {
            $("#left").removeClass("col-md-9");
            $("#left").addClass("col-md-12");
            $("#right").addClass("hide");
        } else {
            $("#left").removeClass("col-md-9");
            $("#left").addClass("col-md-9");
            $("#right").removeClass("hide");
        }
    });

});