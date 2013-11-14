<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
value of the parent: <%:ViewData["parent"] %><br/>
value of the p1 parameter: <%:ViewData["p1"] %><br/>
values sent from the js func set using ParameterFunc: <br/>
a: <%:ViewData["a"] %><br/>
b: <%:ViewData["b"] %><br/>
<% using (Html.BeginForm())
   {
       
   } %>