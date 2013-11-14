<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Error handling demo</h2>
    
    When a JavaScript error happens because of server error/incorrect url (500, 404) 
    the only way you would know the reason is by using something like firebug/chrome dev tools 
    (by looking in the console for the execution of ajax requests).
    <br/>
    <br/>
    You can also assign a js function to the <code>awe.err</code>, 
    this way whenever an error will occur your custom function will be executed.
    
    <pre>
    awe.err = function (xhr, textStatus, errorThrown) {
            var msg = "unexpected error occured";
            if (xhr) {
                msg = xhr.responseText;
            }
            msg += "&lt;hr/> you see this message because in Site.Master awe.err is set to a function that shows this popup";
            $('&lt;div/>').dialog(
                {
                    title: 'unexpected error',
                    width: 570,
                    height: 200,
                    position: ["left", "bottom"], 
                    dialogClass: "errPopup"
                }).html(msg);
        };
    </pre>
    <br/>
    clicking on this popup links will throw a server exception, click on them to see how it's handled
    <br/>
    <%:Html.Awe().PopupActionLink().Url(Url.Action("ShowPopup","PopupError")).LinkText("open popup") %>
    <%:Html.Awe().PopupActionLink().Url(Url.Action("ShowPopupForm","PopupError")).LinkText("open popupform") %>
    
</asp:Content>
