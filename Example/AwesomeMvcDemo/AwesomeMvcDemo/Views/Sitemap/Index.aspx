<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">ASP.net MVC Awesome Demo Sitemap</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <div id="sitemap">
    <% foreach (var group in MySiteMap.Items.GroupBy(o => o.GroupId))
       {%>
        <div class="mgroup">
    <h2><%:group.First().GroupTitle %></h2>
    <ul>
    <%foreach(var item in group){%>
        <li>
    <%:Html.ActionLink(item.Title,item.Action, item.Controller) %>
    </li>
        <%} %>
        </ul>
            </div>
    <%} %>
        </div>
    <style>
        #sitemap li{ list-style: none;padding: 5px;}
        .mgroup{display: inline-block;vertical-align: top; margin: 5px;}
    </style>
</asp:Content>
