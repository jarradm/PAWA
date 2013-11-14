<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <ul class="explist">
    <%
        var actions = typeof (ExpController).GetMethods().Where(o => o.ReturnType == typeof(ActionResult) && !o.GetParameters().Any());

        foreach (var methodInfo in actions)
        {
  %>
        <li>
    <%:Html.ActionLink(methodInfo.Name, methodInfo.Name) %></li>
    <%
        }
    %>
        </ul>

    <style>
        .explist li {
            list-style-type: none;
            line-height: 1.5em;
        }
    </style>
</asp:Content>
