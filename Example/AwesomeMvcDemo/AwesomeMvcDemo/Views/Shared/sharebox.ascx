<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<table>
    <tr>
        <td style="vertical-align: top;">
            <a href="http://aspnetawesome.com/Download/MvcDemoApp" class="awe-btn" style="font-size: 12px;">download this demo</a>
        </td>
        <td>
            <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://demo.aspnetawesome.com"
                data-text="ASP.net MVC Awesome Demo" data-count="none" data-hashtags="aspnetawesome">
                Tweet</a>
            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
        </td>
        <td>
            <!-- Place this tag where you want the +1 button to render -->
            <div class="g-plusone" data-size="medium" data-annotation="none" data-href="http://demo.aspnetawesome.com">
            </div>
            <!-- Place this render call where appropriate -->
            <script type="text/javascript">
                (function () {
                    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
                    po.src = 'https://apis.google.com/js/plusone.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
                })();
            </script>
        </td>
        <td>
            <iframe src="//www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2Faspnet-mvc-project-awesome%2F145701755486515&amp;send=false&amp;layout=button_count&amp;width=100&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:100px; height:21px;" allowTransparency="true"></iframe>
        </td>
    </tr>
</table>
