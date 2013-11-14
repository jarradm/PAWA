<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.net Awesome AjaxList Table Layout
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Using Table Layout</h3>
    <%--begin--%>
    <%:Html.Awe().AjaxList("MealsTableLayout")
                        .TableLayout(true) %>
    <%--end--%>
    <pre><%:Html.Source("AjaxListDemo/TableLayout.aspx") %></pre>
    Setting .TableLayout(true) will make the AjaxList use a table tag instead of ul,
    so now you can use 'tr' tags in your custom layout
    <pre><%:Html.Csource("MealsTableLayoutAjaxListController.cs") %></pre>
    isTheadEmpty tells use if the table header is empty or not, this way we set it only
    the first time (not on each subsequent search)
    <br />
    CustomItem.ascx:
    <pre><%:Html.Source("MealsTableLayoutAjaxList/CustomItems.ascx") %></pre>
    TableHeader.ascx:
    <pre><%:Html.Source("MealsTableLayoutAjaxList/TableHeader.ascx") %></pre>
</asp:Content>
