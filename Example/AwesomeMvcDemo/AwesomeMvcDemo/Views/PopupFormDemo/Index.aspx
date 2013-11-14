<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<object>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Popup Form Demos
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

<h3>PopupForm - used to load and post a form in a popup</h3>
<div class="expl">
Used to load form in a popup that will handle the form post using ajax, there are 2 helpers <code>Html.Awe().PopupFormActionLink</code> - that will generate the link and <code>Url.Awe().PopupFormAction</code> - which will generate only the js function call.
 It loads the content from the <code>.Url(string)</code> provided and when the user clicks ok the form will be posted, if the result of the post is view/string (usually when ModelState not valid) the content of the popup will be replaced with the post result,
when the result is a json object the popup will close, if the PopupForm has a success function defined the json object will be passed that function.
</div>
    <%--begin--%>
    <script type="text/javascript">
        function created() {
            alert('meal created');
        }
    </script>
    <h4>PopupForm with Success function assigned</h4>
    <button class="awe-btn" 
    onclick="<%:Url.Awe().PopupFormAction()
                        .Url(Url.Action("create","SimpleMeals"))
                        .Success("created")
                        .Title("create meal") %>">
        Create</button>
    <%--end--%>
    <br/>
    <div class="code">
 <br/>   
view:
<pre>
<%:Html.Source("PopupFormDemo/Index.aspx") %>
</pre>
    <br/>
controller:
<pre><%:Html.Csource("SimpleMealsController.cs") %></pre>
the create view (rendered by the create action):
<pre><%:Html.Source("SimpleMeals/Create.ascx") %></pre>
    </div>
        <h3>Sending client side paramters to server on content load</h3>    
    
    Value sent to the server action that returns the popup's content: <input type="text" id="txtParam1" value="hi there"/>  
    
    <br/>
    
    <%--begin4--%>
    <%:Html.Awe().PopupFormActionLink()
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
    </script>
    <%--end4--%>
    <br/>
<div class="code">
<pre>
<%:Html.Source("PopupFormDemo/Index.aspx","4") %>
</pre>
</div>
</asp:Content>
