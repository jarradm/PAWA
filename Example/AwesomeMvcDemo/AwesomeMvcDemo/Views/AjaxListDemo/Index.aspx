<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<object>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    AjaxList Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        AjaxList bound to a textbox</h3>
    <%--begin--%>
    Search:
    <input type="text" name="search" id="txtSearch" />
    <input type="button" class="awe-btn" value="search"/>
    <br/>
    <br/>
    <%:Html.Awe().AjaxList("Meals")
                .Parent("txtSearch")%>
    <%--end--%>
    <pre><%:Html.Source("AjaxListDemo/Index.aspx") %></pre>
    by default the AjaxList will try to get data from the Search action of a controller
    with same name as it + "AjaxList" but a different Url or controller can be specified
    using .Url .Controller
    <pre><%:Html.Csource("MealsAjaxListController.cs") %></pre>
</asp:Content>
