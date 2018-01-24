function NavToggle() {
    $(".navbar-minimalize").trigger("click")
}
function SmoothlyMenu() {
    $("body").hasClass("mini-navbar") ? $("body").hasClass("fixed-sidebar") ? ($("#sideMenu").hide(), setTimeout(function () {
        $("#sideMenu").fadeIn(500),
            //适配样式改变
            $(".nav-logo").height(30),
            $(".nav-logo img").attr("height", "25"),
            $(".sys img").attr("height", "35"),
            $(".sys").css("margin-top", "15px"),
            $(".nav-logo").css("background-image", "url(img/nav_top_logo_bg_small.png)"),
            $(".navbar-static-top").height(70)
    },
        300)) : $("#sideMenu").removeAttr("style") : ($("#sideMenu").hide(), setTimeout(function () {
            $("#sideMenu").fadeIn(500),
                //适配样式改变
                $(".nav-logo").height(60),
                $(".nav-logo img").attr("height", "52"),
                $(".sys img").attr("height", "52"),
                $(".sys").css("margin-top", "25px"),
                $(".nav-logo").css("background-image", "url(img/nav_top_logo_bg.png)"),
                $(".navbar-static-top").height(100)
        },
            100))
}
$(document).ready(function () {
    $("#sideMenu").metisMenu(),
        $(".right-sidebar-toggle").click(function () {
            $("#right-sidebar").toggleClass("sidebar-open")
        }),
        $(".sidebar-container").slimScroll({
            height: "100%",
            railOpacity: .4,
            wheelStep: 10
        }),
        $(".open-small-chat").click(function () {
            $(this).children().toggleClass("fa-comments").toggleClass("fa-remove"),
                $(".small-chat-box").toggleClass("active")
        }),
        $(".small-chat-box .content").slimScroll({
            height: "234px",
            railOpacity: .4
        }),
        $(".check-link").click(function () {
            var e = $(this).find("i"),
                a = $(this).next("span");
            return e.toggleClass("fa-check-square").toggleClass("fa-square-o"),
                a.toggleClass("todo-completed"),
                !1
        }),
        $(function () {
            $(".sidebar-collapse").slimScroll({
                height: "100%",
                railOpacity: .9,
                alwaysVisible: !1
            })
        }),
        $(".navbar-minimalize").click(function () {
            $("body").toggleClass("mini-navbar"),
                SmoothlyMenu()
        }),
        $(window).bind("load resize click scroll",
            function () {
                $("body").hasClass("body-small")
            }),
        $(window).scroll(function () {
            $(window).scrollTop() > 0 && !$("body").hasClass("fixed-nav") ? $("#right-sidebar").addClass("sidebar-top") : $("#right-sidebar").removeClass("sidebar-top")
        }),
        $(".full-height-scroll").slimScroll({
            height: "100%"
        }),
        $("#sideMenu>li").click(function () {
            $("body").hasClass("mini-navbar") && NavToggle()
        }),
        $("#sideMenu>li li a").click(function () {
            $(window).width() < 1025 && NavToggle()
        }),
        $(".nav-close").click(NavToggle),
        /(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent) && $("#content-main").css("overflow-y", "auto")
})
$(window).on("load resize", function () {
    $(this).width() < 1025 && ($("body").addClass("mini-navbar"), $(".nav-logo img").attr("height", "25"), $(".navbar-static-side").fadeIn())
    $(this).width() > 1025 && ($("body").removeClass("mini-navbar"), $(".nav-logo img").attr("height", "53"))
});