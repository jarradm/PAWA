//by default jquery.validate 1.9 doesn't validate hidden inputs
if ($.validator) $.validator.setDefaults({
    ignore: []
});

//on document ready
$(function () {
    //parsing the unobtrusive attributes when we get content via ajax
    $(document).ajaxComplete(function () {
        $.validator.unobtrusive.parse(document);
    });
    
    $('pre').addClass('prettyprint');
    prettyPrint();
    
    //fix for IE to trigger change event on enter
    var isMSIE = /*@cc_on!@*/0;
    if(isMSIE){
        $("input[type=text]")
            .on("change", function (e) {
                $.data(this, "value", this.value);
            }).on("keyup", function (e) {
                console.log(e.which);
                if (e.which === 13 && this.value != $.data(this, "value")) {
                    $(this).change();
                }
            });
    }

    //show code directive
    $('.code').hide().before('<br/>').before($('<span class="shcode showCode">show code</span>').click(function () {
        var btn = $(this);
        btn.toggleClass("hideCode showCode");

        if (btn.hasClass("hideCode")) {
            btn.html("hide code");
            $(this).next().fadeIn();
        } else {
            btn.html("show code");
            $(this).next().fadeOut();
        }
    }));

    //changing themes on the client side
    $('#chTheme').change(function () {
        var v = $(this).val().split("|");
        var theme = v[0];
        var jqTheme = v[1];
        
        $('#jqStyle').attr('href', "http://code.jquery.com/ui/1.10.3/themes/" + jqTheme + "/jquery-ui.css");
        $('#aweStyle').attr('href', root + "Content/themes/" + theme + "/AwesomeMvc.css");
        $('#demoStyle').attr('href', root + "Content/themes/" + theme + "/Site.css");
        $.post(root + "ChangeTheme/Change", { s: theme }, function () {
            $('.awe-grid').each(function(_,e) {
                $(e).data('api').lay();
                setTimeout(function () {
                    $(e).data('api').lay();
                }, 1000);
            });
        });
    });
    
    //make background bit darker at night
    var now = new Date();
    var hours = now.getHours();
    var color = '#fff';
    //night
    if (hours < 6 || hours > 22) {
        color = '#f0f0f0';
    } else
        //morning
        if (hours > 5 && hours < 9) {
            color = '#fbfbfb';
        }
    $('body').css('background-color', color);
});

//google analytics
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-27119754-1']);
_gaq.push(['_setDomainName', 'aspnetawesome.com']);
_gaq.push(['_trackPageview']);

(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();