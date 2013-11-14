<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<object>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">ASP.net MVC Awesome Popup Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
  
<h3>Popup</h3>
<div class="expl">
    Use the <code>Html.Awe().PopupActionLink</code> helper to generate a link that opens a popup 
    and <code>Url.Awe().PopupAction</code> to generate just the js function call to open the popup.<br/>
    When there is more Popup helpers declared that have the same <code>.Name(string)</code>,
     they will share the same popup window, so opening one will close the other.
</div>

<h3>Popup with content requested via ajax</h3>
<%--begin1--%>
<%:Html.Awe().PopupActionLink().Name("p2")
            .Url(Url.Action("Meals"))
            .LinkText("Open Popup")
            .Width(500)
            .Height(450)%>
<%--end1--%>
<pre>
<%:Html.Source("PopupDemo/Index.aspx","1") %>
</pre>

<h3>Popup with buttons</h3>

<%--begin2--%>
<%:Html.Awe().PopupActionLink().Name("p3")
    .LinkText("Open")
    .Button("Add Hi", "addHi")
    .Button("Say Hi", "sayHi")
    .Button("Close", "closePopup")
    .Content("Popup with buttons, each button has a js function for the click event")
    .Close("onClose")
%>
<script type="text/javascript">
function closePopup() {
    $(this).dialog('close');
}

function sayHi() {
    alert('hi');
}

function addHi() {
    $(this).prepend('<p>hi</p>');
}

function onClose() {
    alert('popup was closed');
}

</script>
<%--end2--%>
<div class="code">
<pre>
<%:Html.Source("PopupDemo/Index.aspx","2") %>
</pre>
</div>
    
    <h3>Autosize</h3>
    Open any popup and try resizing the browser (try to make it smaller than the popup), work on popups from other helpers as well

<h3>Sending client side paramters to server on content load</h3>
    
    Value sent to the server action that returns the popup's content: 
    <%--begin4--%>
    <input type="text" id="txtParam1" value="hi there"/>  
    
    <br/>
    
<%:Html.Awe().PopupActionLink()
    .Name("p4")
    .Url(Url.Action("PopupWithParameters"))
    .LinkText("Open popup")
    .Parent("txtParam1")
    .Parameter("p1", 15)
    .ParameterFunc("giveParams")%>
    <script>
        function giveParams() {
            return { a: "hi", b: "how are you" };
        }
    </script><%--end4--%>
<div class="code">
<pre>
<%:Html.Source("PopupDemo/Index.aspx","4") %>
</pre>
</div>
    <h3>Modal Popup, position top; using Url helper</h3>

<%--begin3--%>
<button class="awe-btn" onclick="<%:Url.Awe().PopupAction().Name("pm").Position("top").Modal(true)
.Content("Position can be 'center', 'left', 'right', 'top', 'bottom' or [x,y] (e.g. [350,100]) ")%>">
Open
</button>
<%--end3--%>
<pre>
<%:Html.Source("PopupDemo/Index.aspx","3") %>
</pre>
    
    <h3>FullScreen popup</h3>

<%--begin5--%>
<button class="awe-btn" onclick="<%:Url.Awe().PopupAction().Name("pfulls").Fullscreen(true).Content("hi, try resizing the browser window")%>">Open</button>
<%--end5--%>
<pre>
<%:Html.Source("PopupDemo/Index.aspx","5") %>
</pre>

</asp:Content>
