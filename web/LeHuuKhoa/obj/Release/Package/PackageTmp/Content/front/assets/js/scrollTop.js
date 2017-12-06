function scrolltop() {
    var scrollTop = '.scrollTop';

    // Kéo xuống khoảng cách 220px thì xuất hiện button
    var offset = 220;

    // THời gian di trượt là 0.5 giây
    var duration = 500;

    // Thêm vào sự kiện scroll của window, nghĩa là lúc trượt sẽ
    // kiểm tra sự ẩn hiện của button
    jQuery(window).scroll(function() {
        if (jQuery(this).scrollTop() > offset) {
            jQuery(scrollTop).fadeIn(duration);
        } else {
            jQuery(scrollTop).fadeOut(duration);
        }
    });

    // Thêm sự kiện click vào button để khi click là trượt lên top
    jQuery(scrollTop).click(function(event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    });

    jQuery("#goto-comment-box").click(function (event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: $("#comment-box").offset().top }, duration);
        return false;
    });
}
scrolltop();