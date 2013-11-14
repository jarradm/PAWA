<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.net Awesome AjaxList Custom Item Template
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h3>Custom Item Template</h3>
    <%--begin--%>
    <%:Html.Awe().AjaxList("MealsCustomItem") %>
    <%--end--%>
    <br/>
    To use custom item template in the controller instead of setting the Items property you have to set the Content property with the prerendered html content
    <br/>
    <pre><%:Html.Source("AjaxListDemo/CustomItemTemplate.aspx") %></pre>
    <pre><%:Html.Csource("MealsCustomItemAjaxListController.cs") %></pre>
    <br/>
    <b>RenderView</b> is a controller extension from Omu.AwesomeMvc that renders a view and returns the result as a string.
    The view that gets rendered must consist from 'li' tags (or 'tr' if using TableLayout) with class="awe-li" and data-val=key attributes:
    <pre><%:Html.Source("MealsCustomItemAjaxList/CustomItem.ascx") %></pre>
</asp:Content>
