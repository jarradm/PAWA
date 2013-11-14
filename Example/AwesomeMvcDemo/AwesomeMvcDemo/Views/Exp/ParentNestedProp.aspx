<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<ParentNestedPropInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    
    <%:Html.Awe().AjaxDropdownFor(o => o.Intern.Prop1).Url(Url.Action("GetItems","CategoryAjaxDropdown")) %>
    <p>bind to nested property</p>
    <%:Html.Awe().AjaxDropdownFor(o => o.Intern.Prop2).Parent(o => o.Intern.Prop1).Url(Url.Action("GetItems","MealAjaxDropdown")) %>
</asp:Content>
    