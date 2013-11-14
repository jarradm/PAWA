<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    empty grid
    <%:Html.Awe()
    .Grid("Wicked")
    .GroupBarText("my custom gropubartext")
    .Columns(new Column{ Name = "Hi"})%>
</asp:Content>
