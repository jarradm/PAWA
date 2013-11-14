<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
value of the parent: <%:ViewData["parent"] %><br/>
value of the p1 parameter: <%:ViewData["p1"] %><br/>
parameters sent by js function set usin ParameterFunc:<br/>
a: <%:ViewData["a"] %><br/>
b: <%:ViewData["b"] %><br/>